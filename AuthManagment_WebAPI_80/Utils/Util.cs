﻿using AuthManagment_WebAPI_80.DTOs;
using AuthManagment_WebAPI_80.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthManagment_WebAPI_80.Utils
{
    public class Util
    {
        private readonly IConfiguration _configuration;
        public Util(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string hashText(string text)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(text);
            return hash;
        }

        public bool verifyHash(string text, string hash)
        {
            var match = BCrypt.Net.BCrypt.Verify(text, hash);
            return match;
        }

        public string generateJWT(PersonaModel persona)
        {
            //body and securityKey of token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, persona.Id),
                new Claim(ClaimTypes.Role, persona.Rol)
            };
            var secret_Key = _configuration.GetRequiredSection("SECRET_KEY").Value;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret_Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //create token
            var token = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
