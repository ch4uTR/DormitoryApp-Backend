using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class IssueVoteRepository : RepositoryBase<IssueVote>, IIssueVoteRepository
    {
        public IssueVoteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<IssueVote>> GetUserVotesByUserId(string userId, bool trackChanges)
        {
            var query = FindByCondition(vote => vote.UserId.Equals(userId), trackChanges)
                .OrderByDescending(vote => vote.VotedAt);

            return await query.ToListAsync();
        }

        public async Task<IssueVote?> GetVoteAsync(int issueId, string userId, bool trackChanges)
        {
            return await FindByCondition(
                vote => vote.IssueId.Equals(issueId) &&
                vote.UserId.Equals(userId),
                trackChanges)
                .SingleOrDefaultAsync();
        }
    }
}
