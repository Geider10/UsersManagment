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
    }
}
