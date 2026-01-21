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
    public class ReservationsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReservationsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }



        [HttpGet("my")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentsReservations()
        { 

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) { return Unauthorized("Kulllanıcı bilgileri doğrulanamadı!"); }

            var reservations = await _serviceManager.LaundryService.GetUserReservations(userId);
            return Ok(reservations);

        }

        [HttpGet("staff")]
        [Authorize(Roles = "LaundryMan")]
        public async Task<IActionResult> GetReservations([FromQuery]DateTime? date)
        {

            var reservations = await _serviceManager.LaundryService.GetReservationsForStaff(date, false);
            return Ok(reservations);

        }



        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) { return Unauthorized("Kullanıcı kimliği doğrulanamadı!"); }

            var result = await _serviceManager.LaundryService.CreateReservationAsync(userId, createReservationDto);
            return StatusCode(201, result);

        }

        [HttpPatch("{reservationId}")]
        [Authorize(Roles = "LaundryMan")]
        public async Task<IActionResult> UpdateReservationStatus([FromRoute] int reservationId, [FromBody] UpdateReservationStatusDto dto)
        {
            await _serviceManager.LaundryService.UpdateReservationStatus(reservationId, dto);
            return NoContent();
        }





    }
}
