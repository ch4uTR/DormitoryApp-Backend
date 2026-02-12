using Entity.Models;
using Entity.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IIssueRepository : IRepositoryBase<Issue>
    {
        //Benim şikayetlerim ne durumda?
        Task<PagedResponse<Issue>> GetIssuesByStudentIdAsync(IssueRequestParameter isssueRequestParameter, string studentId, bool trackChanges);

        Task<PagedResponse<Issue>> GetAllIssuesWithDetails(IssueRequestParameter issueRequestParameter,bool trackChanges);
        Task<IEnumerable<Issue>> GetPendingIssues(bool trackChanges);

        Task<IEnumerable<Issue>> GetClosedIssues(bool trackChanges);

        Task<bool> IsAnyActiveIssueInRoom(int roomId, IssueType type);

        Task<Issue?> GetIssueByIdAsync(int issueId, bool trackChanges);



    }
}
