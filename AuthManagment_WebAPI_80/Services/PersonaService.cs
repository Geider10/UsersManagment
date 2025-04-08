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

        public async Task<List<PersonaDTO>> GetAll()
        {
            var listaDB = await _context.Personas.ToListAsync();
            if (listaDB == null) throw new Exception("The are no persons");

            var listaDTO = new List<PersonaDTO>();
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
            var personaDB = await _context.Personas.FindAsync(id);
            if (personaDB == null) throw new Exception("Person no found");

            var personaDTO = new PersonaDTO()
            {
                Name = personaDB.Name,
                Email = personaDB.Email,
            };

            return personaDTO;
        }

        public async Task<String> Update(string id, PersonaDTO personaDTO)
        {
            var personaDB = await _context.Personas.FindAsync(id);
            if (personaDB == null) throw new Exception("Person no found");

            personaDB.Name = personaDTO.Name;
            personaDB.Email = personaDTO.Email;

            _context.Personas.Update(personaDB);
            await _context.SaveChangesAsync();

            return "Persona updated";
        }

        public async Task<String> Delete(string id)
        {
            var personaDB = await _context.Personas.FindAsync(id);
            if (personaDB == null) throw new Exception("Person no found");

            _context.Personas.Remove(personaDB);
            await _context.SaveChangesAsync();

            return "Persona deleted";
        }
    }
}
