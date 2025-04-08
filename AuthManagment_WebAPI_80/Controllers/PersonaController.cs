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
            try
            {
                var getAllPersons = await _personaService.GetAll();
                return Ok(getAllPersons);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var getByIdPerson = await _personaService.GetById(id);
                return Ok(getByIdPerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPut]
        [Route("update/{idPersona}")]
        public async Task<ActionResult> Update([FromRoute] string idPersona, [FromBody] PersonaDTO personaDTO)
        {
            try
            {
                var updatePerson = await _personaService.Update(idPersona, personaDTO);
                return Ok(updatePerson);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var deletePerson = await _personaService.Delete(id);
                return Ok(deletePerson);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
    }
}
