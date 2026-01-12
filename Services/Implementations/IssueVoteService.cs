using Entity.Models;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class IssueVoteService : IIssueVoteService
    {
        private readonly IRepositoryManager _repositoryManager;

        public IssueVoteService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> ToggleVoteAsync(int issueId, string userId)
        {

            var issue = await _repositoryManager.Issue.GetIssueByIdAsync(issueId, false);
            if (issue == null || issue.IsDeleted || issue.Status.Equals(IssueStatus.Closed)) { throw new Exception($"Idsi: {issueId} olan issue bulunamadı!"); }



            var existingVote = await _repositoryManager.IssueVote.GetVoteAsync(issueId, userId, true);
            bool isVoted; 

            if (existingVote != null)
            {
                _repositoryManager.IssueVote.Delete(existingVote);
                isVoted = false;
            }
            else
            {
                var newVote = new IssueVote
                {
                    IssueId = issueId,
                    UserId = userId
                };
                _repositoryManager.IssueVote.Create(newVote);
                isVoted = true;
            }

            await _repositoryManager.SaveAsync();

            return isVoted;

        }
    }
}
