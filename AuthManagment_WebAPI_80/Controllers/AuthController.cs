using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthManagment_WebAPI_80.Services;
using AuthManagment_WebAPI_80.DTOs;
namespace AuthManagment_WebAPI_80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("singup")]
        public async Task<ActionResult> SignUp([FromBody] AuthDTO authDTO)
        {
            try
            {
                var signUp = await _authService.SignUp(authDTO);
                return CreatedAtAction(nameof(SignUp), signUp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LogIn([FromBody] AuthDTO authDTO)
        {
            try
            {
                var logIn = await _authService.LogIn(authDTO);
                return Ok(logIn);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
