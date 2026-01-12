using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/issues/{issueId:int}/votes")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class IssueVotesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public IssueVotesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> ToogleIssueVote([FromRoute] int issueId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized("Kullanıcı kimliği doğrulanamadı!");
            }

            var isVoted = await _serviceManager.VoteService.ToggleVoteAsync(issueId, userId);

            return Ok(new {
                Message = isVoted ? "Arıza başarıyla desteklendi!" : "Destek geri çekildi!",
                Status = isVoted
            });

        }

    }
}
