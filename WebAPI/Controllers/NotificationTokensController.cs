using Entity.DTOs.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationTokensController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public NotificationTokensController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }



        [HttpPost("register/{userId}")]
        public async Task<IActionResult> RegisterNotificationToken([FromRoute] string userId, [FromBody] NotificationTokenDto notificationTokenDto)
        {
            var result = await _serviceManager.NotificationService.SaveUserToken(userId, notificationTokenDto);

            return StatusCode(201, result);
        }


    }
}
