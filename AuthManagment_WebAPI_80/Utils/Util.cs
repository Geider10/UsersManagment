using AuthManagment_WebAPI_80.DTOs;
using AuthManagment_WebAPI_80.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthManagment_WebAPI_80.Utils
{
    public class Util
    {
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
                new Claim("id", persona.Id),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("laClaveMasLargaDelMundo2025-Asp.Net-Web.API-8.0"));
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
