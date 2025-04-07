using AuthManagment_WebAPI_80.Data;
using AuthManagment_WebAPI_80.DTOs;
using AuthManagment_WebAPI_80.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthManagment_WebAPI_80.Services
{
    public class PersonaService
    {
        private readonly AppDbContext _context;

        public PersonaService(AppDbContext context )
        {
            _context = context;
        }
        public async Task<String> Create( PersonaDTO personaDTO)
        {
            //if (personaDTO == null) throw Error("Persona is null");
            var persona = new PersonaModel()
            {
                Id = "111",
                Name = personaDTO.Name,
                Email = personaDTO.Email,
                Password = personaDTO.Password,
                Rol = "User",
            };

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            
            return "Persona created";
        }
        public async Task<List<PersonaDTO>> GetAll()
        {
            var listaDTO = new List<PersonaDTO>();
            var listaDB = await _context.Personas.ToListAsync();

            //if (listaDB == null) return NotFound("No personas found");
            foreach (var item in listaDB)
            {
                listaDTO.Add(new PersonaDTO
                {
                    Name = item.Name,
                    Email = item.Email,
                });
            }

            return listaDTO;
        }

        public async Task<PersonaDTO> GetById(string id)
        {
            var personaDTO = new PersonaDTO();
            var personaDB = await _context.Personas.FindAsync(id);
            //if (personaDB == null) return NotFound("Persona no found");

            personaDTO.Name = personaDB.Name;
            personaDTO.Email = personaDB.Email;

            return personaDTO;
        }

        public async Task<String> Update(string id, PersonaDTO personaDTO)
        {
            var personaDB = await _context.Personas.FindAsync(id);
            //if (personaDB == null && personaDTO == null) return NotFound("Persona not found");

            personaDB.Name = personaDTO.Name;
            personaDB.Email = personaDTO.Email;

            _context.Personas.Update(personaDB);
            await _context.SaveChangesAsync();

            return "Persona updated";
        }

        public async Task<String> Delete(string id)
        {
            var personaDB = await _context.Personas.FindAsync(id);
            //if (persona == null) return NotFound("Persona not found");

            _context.Personas.Remove(personaDB);
            await _context.SaveChangesAsync();

            return "Persona deleted";
        }
    }
}
