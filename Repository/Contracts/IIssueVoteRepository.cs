using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IIssueVoteRepository : IRepositoryBase<IssueVote>
    {
        Task<IssueVote?> GetVoteAsync(int issueId, string userId, bool trackChanges);

        Task<IEnumerable<IssueVote>> GetUserVotesByUserId(string userId, bool trackChanges);
    }
}
