using Entity.DTOs.Announcement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AnnouncementsController : Controller
    {   
        private readonly IServiceManager _serviceManager;

        public AnnouncementsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementDto createAnnouncementDto)
        {
            var adminId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (adminId == null) { return Unauthorized("Kullanıcı bilgileri doğrulanamadı!"); }

            var result = await _serviceManager.AnnouncementService.CreateAnnouncementAsync(adminId, createAnnouncementDto);

            return StatusCode(201, result);


        }

        [HttpGet]   
        public async Task<IActionResult> GetAllAnnouncements()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) { return Unauthorized("Kullanıcı bilgileri doğrulanamadı!"); }

            var isAdmin = User.IsInRole("Admin") ? true : false;

            if (isAdmin)
            {
                var adminResult = await _serviceManager.AnnouncementService.GetAllForAdminAsync(true, false);
                return Ok(adminResult);
            }


            var studentResult = await _serviceManager.AnnouncementService.GetAnnouncementsForStudentAsync(userId, false);
            return Ok(studentResult);


        }
    }
}
