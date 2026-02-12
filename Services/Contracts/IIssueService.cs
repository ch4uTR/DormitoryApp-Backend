using Entity.DTOs.Issue;
using Entity.Models;
using Entity.RequestFeatures;
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


        Task<PagedResponse<IssueDto>> GetAllIssues(IssueRequestParameter issueRequestParameter,string userId, bool isAdmin);

        Task<IssueDto> UpdateIssueStatus(UpdateIssueStatusDto updateIssueDto, int issueId);

        Task<AdminIssueDto> DeleteIssue(int issueId);

    }
}
