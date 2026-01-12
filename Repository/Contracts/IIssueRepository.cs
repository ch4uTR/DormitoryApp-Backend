using Entity.Models;
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
        Task<IEnumerable<Issue>> GetIssuesByStudentIdAsync(string studentId, bool trackChanges);

        Task<IEnumerable<Issue>> GetAllIssuesWithDetails(bool trackChanges);
        Task<IEnumerable<Issue>> GetPendingIssues(bool trackChanges);

        Task<IEnumerable<Issue>> GetClosedIssues(bool trackChanges);

        Task<bool> IsAnyActiveIssueInRoom(int roomId, IssueType type);

        Task<Issue?> GetIssueByIdAsync(int issueId, bool trackChanges);



    }
}
