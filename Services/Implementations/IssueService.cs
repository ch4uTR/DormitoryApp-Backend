using AutoMapper;
using Entity.DTOs.Issue;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class IssueService : IIssueService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<User> _userManager;

        public IssueService(IMapper mapper, IRepositoryManager manager, UserManager<User> userManager)
        {
            _mapper = mapper;
            _repositoryManager = manager;
            _userManager = userManager;
        }

        public async  Task<IssueDto> CreateIssue(CreateIssueDto createIssue, string userId, bool isAdmin, string studentId)
        {

            var student = await _userManager.FindByIdAsync(studentId);
            if (student == null) { throw new Exception($"Idsi {studentId} olan öğrenci bulunamadı!"); }


            var assignment = await _repositoryManager.RoomAssignment.GetRoomAssignmentByStudentId(studentId);
            if (assignment == null) { throw new Exception("Öğrenciye atanmış oda bulunamadı!"); }


            var isDuplicate = await _repositoryManager.Issue.IsAnyActiveIssueInRoom(assignment.RoomId, createIssue.Type);
            if (isDuplicate) { throw new Exception("Bu sorun zaten bildirilmiş"); }


            var issueEntity = _mapper.Map<Issue>(createIssue);

            issueEntity.RoomId = assignment.RoomId;
            if (isAdmin)
            {
                issueEntity.UserId = studentId;
            }
            else
            {
                issueEntity.UserId = userId;
            }

            _repositoryManager.Issue.Create(issueEntity);
            await _repositoryManager.SaveAsync();

            return isAdmin ?
                _mapper.Map<AdminIssueDto>(issueEntity) :
                _mapper.Map<IssueDto>(issueEntity);

        }

        public async Task<IEnumerable<IssueDto>> GetAllIssues(string userId, bool isAdmin)
        {

            IEnumerable<Issue> issues;

            issues = isAdmin ?
                await _repositoryManager.Issue.GetAllIssuesWithDetails(false) :
                await _repositoryManager.Issue.GetIssuesByStudentIdAsync(userId, false);
              
            return issues.Select(issue =>
            {
                var dto = _mapper.Map<IssueDto>(issue);

                return dto with { IsOwner = issue.UserId == userId };
            }).ToList();


        }

        public async Task<IssueDto> UpdateIssue(UpdateIssueDto updateIssueDto, int issueId)
        {
            var issue = await _repositoryManager.Issue.GetIssueByIdAsync(issueId, true);
            if (issue == null) { throw new Exception($"Idsi {issueId} olan bir issue bulunamadı!"); }

            issue.Status = updateIssueDto.Status;
            issue.LastUpdatedAt = DateTime.UtcNow;

            await _repositoryManager.SaveAsync();

            return _mapper.Map<IssueDto>(issue);
        }

        public async Task<AdminIssueDto> DeleteIssue(int issueId)
        {
            var issue = await _repositoryManager.Issue.GetIssueByIdAsync(issueId, true);
            if (issue == null) { throw new Exception($"Idsi {issueId} olan bir issue bulunamadı!"); }

            issue.IsDeleted = true;
            issue.LastUpdatedAt = DateTime.UtcNow;

            await _repositoryManager.SaveAsync();

            return _mapper.Map<AdminIssueDto>(issue);
        }

        
    
    
    }
}
