using Entity.DTOs.Issue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] //Sadece token'ı olanlar!
    public class IssuesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public IssuesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllIssues()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var isAdmin = User.IsInRole("Admin");

            var issues = await _serviceManager.IssueService.GetAllIssues(userId, isAdmin);

            return Ok(issues);
        }


        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromBody] CreateIssueDto createIssueDto)
        {
         
            if (createIssueDto == null) { return BadRequest("Create Dto boş olamaz!"); }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var isAdmin= User.IsInRole("Admin");

            var studentId = isAdmin ? createIssueDto.StudentId : userId;

            var result =  await _serviceManager.IssueService.CreateIssue(createIssueDto, userId, isAdmin, studentId);

            return StatusCode(201, result);

        }



        [HttpPatch("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateIssue([FromBody] UpdateIssueStatusDto updateIssueDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _serviceManager.IssueService.UpdateIssueStatus(updateIssueDto, id);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteIssue([FromRoute] int id)
        {
            var result = await _serviceManager.IssueService.DeleteIssue(id);
            
            return Ok(result);
        }

    }
}
