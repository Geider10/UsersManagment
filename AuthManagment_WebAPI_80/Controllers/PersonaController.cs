using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthManagment_WebAPI_80.Data;
using AuthManagment_WebAPI_80.Models;
using AuthManagment_WebAPI_80.DTOs;

namespace AuthManagment_WebAPI_80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PersonaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] PersonaDTO personaDTO)
        {
            if (personaDTO == null) return BadRequest("Persona is null");
            var persona = new PersonaModel()
            {
                Id = "111",
                Name = personaDTO.Name,
                Email = personaDTO.Email,
                Password = personaDTO.Password,
                Rol = Role.User,
            };
  
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { id = persona.Id }, persona);
        }
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetAll()
        {
            var listaDTO = new List<PersonaDTO>();
            var listaDB = await _context.Personas.ToListAsync();

            if(listaDB == null) return NotFound("No personas found");
            foreach (var item in listaDB)
            {
                listaDTO.Add(new PersonaDTO
                {
                    Name = item.Name,
                    Email = item.Email,
                });
            }

            return Ok(listaDTO);
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var personaDTO = new PersonaDTO();
            var personaDB = await _context.Personas.FindAsync(id);
            if (personaDB == null) return NotFound("Persona no found");

            personaDTO.Name = personaDB.Name;
            personaDTO.Email = personaDB.Email;

            return Ok(personaDTO);
        }
        [HttpPut][Route("update/{idPersona}")]
        public async Task<ActionResult> Update([FromRoute] string idPersona, [FromBody] PersonaDTO personaDTO)
        {
            var personaDB = await _context.Personas.FindAsync(idPersona);
            if(personaDB == null) return NotFound("Persona not found");

            personaDB.Name = personaDTO.Name;
            personaDB.Email = personaDTO.Email;

            _context.Personas.Update(personaDB);    
            await _context.SaveChangesAsync();

            return Ok("Persona Updated");

        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if(persona == null) return NotFound("Persona not found");

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return Ok("Persona deleted");
        }
    }
}
