using Entity.DTOs.RoomAssignment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoomAssignmentsController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;

        public RoomAssignmentsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAssignment([FromBody] CreateRoomAssignmentDto createRoomAssignmentDto)
        {
            var roomAssignmentDto = await _serviceManager.RoomAssignmentService.CreateRoomAssignment(createRoomAssignmentDto);
            return StatusCode(201, roomAssignmentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAssignment([FromRoute] int id)
        {
            var roomAssignment = await _serviceManager.RoomAssignmentService.GetRoomAssignment(id);
            return Ok(roomAssignment);
        }
    }
}
