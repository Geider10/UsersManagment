using AuthManagment_WebAPI_80.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using AuthManagment_WebAPI_80.DTOs;
using AuthManagment_WebAPI_80.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthManagment_WebAPI_80.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;   
        }
        public async Task<String> SignUp(AuthDTO authDTO)
        {
            var existingPersona = await _context.Personas.FirstOrDefaultAsync(x => x.Email == authDTO.Email);
            if (existingPersona != null)  throw new Exception("Email already exists");
            

            var persona = new PersonaModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = authDTO.Name,
                Email = authDTO.Email,
                Password = authDTO.Password,
                Rol = "User"
            };

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return "Persona created";
        }
   
    }
}
