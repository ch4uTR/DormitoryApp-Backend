using Entity.Models;
using Entity.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class IssueRepository : RepositoryBase<Issue>, IIssueRepository
    {
        public IssueRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Issue>> GetClosedIssues(bool trackChanges)
        {
            var query = FindByCondition(i => i.Status.Equals(IssueStatus.Closed), trackChanges);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Issue>> GetPendingIssues(bool trackChanges)
        {
            var query = FindByCondition(i => i.Status.Equals(IssueStatus.Pending), false);

            return await query.ToListAsync();

        }

        
        public async Task<PagedResponse<Issue>> GetIssuesByStudentIdAsync(IssueRequestParameter issueRequestParameter,string studentId, bool trackChanges)
        {
            var query = FindByCondition(i => i.UserId.Equals(studentId), trackChanges)
                .OrderByDescending(i => i.CreatedAt);

            return await PagedResponse<Issue>.ToPagedResponse(query, issueRequestParameter.PageNumber, issueRequestParameter.PageSize);
        }

        public async Task<PagedResponse<Issue>> GetAllIssuesWithDetails(IssueRequestParameter issueRequestParameter,bool trackChanges)
        {
            var query = FindAll(trackChanges)
                .Include(i => i.Room)
                .Include(i => i.User)
                .OrderByDescending(i => i.CreatedAt);

            return await PagedResponse<Issue>.ToPagedResponse(query, issueRequestParameter.PageNumber, issueRequestParameter.PageSize);

        }


        

        public async Task<bool> IsAnyActiveIssueInRoom(int roomId, IssueType type)
        {
            var query = FindByCondition(i => i.RoomId == roomId &&
                                        i.Type == type &&
                                        (i.Status == IssueStatus.Pending || i.Status == IssueStatus.InProgress), false);

            return await query.AnyAsync();
        }

        public async Task<Issue?> GetIssueByIdAsync(int issueId, bool trackChanges)
        {
            return await FindByCondition(i => i.Id.Equals(issueId), trackChanges).FirstOrDefaultAsync();

            
        }
    }
}
