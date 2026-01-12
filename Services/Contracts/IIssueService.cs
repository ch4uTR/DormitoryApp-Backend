using Entity.DTOs.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IIssueService
    {
        Task<IssueDto> CreateIssue(CreateIssueDto createIssue, string userId, bool isAdmin, string studentId);


        Task<IEnumerable<IssueDto>> GetAllIssues(string userId, bool isAdmin);

        Task<IssueDto> UpdateIssue(UpdateIssueDto updateIssueDto, int issueId);

        Task<AdminIssueDto> DeleteIssue(int issueId);

    }
}
