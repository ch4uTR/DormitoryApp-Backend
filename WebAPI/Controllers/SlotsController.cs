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
    public class SlotsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public SlotsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetAvailableSlots()
        {
            var slots = await _serviceManager.LaundryService.GetSlotsWithin24HoursAsync(false);
            return Ok(slots);

        }

        [HttpGet("staff")]
        [Authorize(Roles = "LaundryMan")]
        public async Task<IActionResult> GetStaffSlots([FromQuery] DateTime? date)
        {
            var queryDate = date ?? DateTime.Today;

            var slots = await _serviceManager.LaundryService.GetSlotsByDateAsync(queryDate, false);

            return Ok(slots);
        }

        [HttpPost("generate")]
        [Authorize(Roles = "LaundryMan")]
        public async Task<IActionResult> GenerateSlots([FromQuery] DateTime date)
        {
            await _serviceManager.LaundryService.GenerateDailySlotsAsync(date);
            return Ok($"{date.ToShortDateString()} tarihi için slotlar kontrol edildi/oluşturuldu.");
        }

        

    }
}
