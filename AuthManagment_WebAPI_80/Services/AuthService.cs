using AuthManagment_WebAPI_80.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using AuthManagment_WebAPI_80.DTOs;
using AuthManagment_WebAPI_80.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using AuthManagment_WebAPI_80.Utils;

namespace AuthManagment_WebAPI_80.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly Util _util;
        public AuthService(AppDbContext context, Util util)
        {
            _context = context;   
            _util = util;
        }
        public async Task<String> SignUp(AuthDTO authDTO)
        {
            var existingPersona = await _context.Personas.FirstOrDefaultAsync(x => x.Email == authDTO.Email);
            if (existingPersona != null)  throw new Exception("Email already exists");

            var hashPassword = _util.hashText(authDTO.Password);
            var persona = new PersonaModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = authDTO.Name,
                Email = authDTO.Email,
                Password = hashPassword,
                Rol = "User"
            };

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return "Persona created";
        }

        internal async Task<String> LogIn(AuthDTO authDTO)
        {
            var existingPersona = await _context.Personas.FirstOrDefaultAsync(x => x.Email == authDTO.Email);
            if (existingPersona == null) throw new Exception("Email no found");

            var matchPassword = _util.verifyHash(authDTO.Password, existingPersona.Password);
            if (!matchPassword) throw new Exception("Password incoorrect");

            var token = _util.generateJWT(existingPersona);

            return token;
        }
    }
}
