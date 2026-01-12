using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MockController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;

        public MockController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }



        [HttpGet("admin-only")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminTest()
        {
            return Ok();
        }

        [HttpGet("student-only")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> StudentTest()
        {
            return Ok();
        }



    }
}
