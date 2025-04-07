using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthManagment_WebAPI_80.DTOs;
using AuthManagment_WebAPI_80.Services;

namespace AuthManagment_WebAPI_80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;
        public PersonaController(PersonaService personaService)
        {
            _personaService = personaService;
        }

       
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetAll()
        {
            var getAllPersons = await _personaService.GetAll();

            return Ok(getAllPersons);
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var getByIdPerson = await _personaService.GetById(id);

            return Ok(getByIdPerson);
        }
        [HttpPut][Route("update/{idPersona}")]
        public async Task<ActionResult> Update([FromRoute] string idPersona, [FromBody] PersonaDTO personaDTO)
        {
            var updatePerson = await _personaService.Update(idPersona, personaDTO);

            return Ok(updatePerson);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var deletePerson = await _personaService.Delete(id);

            return Ok(deletePerson);
        }
    }
}
