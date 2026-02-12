using Entity.DTOs.Issue;
using Entity.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Services.Contracts;
using System.Security.Claims;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] //Sadece token'ı olanlar!
    [EnableRateLimiting("fixed")]
    public class IssuesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public IssuesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllIssues([FromQuery] IssueRequestParameter issueRequestParameter)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var isAdmin = User.IsInRole("Admin");

            var pagedResponse = await _serviceManager.IssueService.GetAllIssues(issueRequestParameter,userId, isAdmin);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResponse.MetaData));

            return Ok(pagedResponse.Items);
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
