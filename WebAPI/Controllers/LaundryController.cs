using Entity.DTOs.Laundry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LaundryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public LaundryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("slots")]
        public async Task<IActionResult> GetAvailableSlots([FromQuery] DateTime? date)
        {
            var queryDate = date ?? DateTime.Today;

            var slots = await _serviceManager.LaundryService.GetSlotsByDateAsync(queryDate, false);
            return Ok(slots);
        }

        [HttpPost("reserve")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) { return Unauthorized("Kullanıcı kimliği doğrulanamadı!"); }

            var result = await _serviceManager.LaundryService.CreateReservationAsync(userId, createReservationDto);
            return StatusCode(201, result);

        }

        [HttpPost("generate-slots")]
        [Authorize(Roles = "Admin, LaundryMan")]
        public async Task<IActionResult> GenerateSlots([FromQuery] DateTime date)
        {
            await _serviceManager.LaundryService.GenerateDailySlotsAsync(date);
            return Ok($"{date.ToShortDateString()} tarihi için slotlar kontrol edildi/oluşturuldu.");
        }


    }
}
