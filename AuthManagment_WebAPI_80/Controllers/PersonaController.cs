using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthManagment_WebAPI_80.Data;
using AuthManagment_WebAPI_80.Models;

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
        public async Task<ActionResult> Create([FromBody] PersonaModel persona)
        {
            Console.WriteLine(persona);
            if (persona == null)
            {
                return BadRequest("Persona is null");
            }
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = persona.Id }, persona);
        }
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetAll()
        {
            var personas = await _context.Personas.ToListAsync();
            if(personas == null)
            {
                return NotFound("No personas found");
            }
            return Ok(personas);
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound("Persona no found");
            }
            return Ok(persona);
        }
        [HttpPut][Route("update/{idPersona}")]
        public async Task<ActionResult> Update([FromRoute] string idPersona, [FromBody] PersonaModel persona)
        {
            var personaDB = await _context.Personas.FindAsync(idPersona);
            if(personaDB == null)
            {
                return NotFound("Persona not found");
            } 
            personaDB.Name = persona.Name;
            personaDB.Email = persona.Email;
            personaDB.Password = persona.Password;

            await _context.SaveChangesAsync();
            return Ok("Persona Updated");

        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if(persona == null)
            {
                return NotFound("Persona not found");
            }
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return Ok("Persona deleted");
        }
    }
}
