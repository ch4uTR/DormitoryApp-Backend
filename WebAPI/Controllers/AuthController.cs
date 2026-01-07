using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        

        public AuthController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }



        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationDto registrationDto)
        {
            var result = await _serviceManager.AuthService.RegisterUser(registrationDto);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);                    
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {

            var tokenDto = await _serviceManager.AuthService.Login(loginDto);

            if (tokenDto == null)
            {
                return Unauthorized();
            }
            return Ok(tokenDto);
             

        }




    }
}
