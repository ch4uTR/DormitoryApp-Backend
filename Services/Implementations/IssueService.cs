using AutoMapper;
using Entity.DTOs.Issue;
using Entity.Events;
using Entity.Models;
using Entity.RequestFeatures;
using MediatR;
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
        private readonly IMediator _mediator;
        public IssueService(IMapper mapper, IRepositoryManager manager, UserManager<User> userManager, IMediator mediator)
        {
            _mapper = mapper;
            _repositoryManager = manager;
            _userManager = userManager;
            _mediator = mediator;   
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

        public async Task<PagedResponse<IssueDto>> GetAllIssues(IssueRequestParameter issueRequestParameter, string userId, bool isAdmin)
        {

            PagedResponse<Issue> pagedResponse;

            pagedResponse = isAdmin ?
                await _repositoryManager.Issue.GetAllIssuesWithDetails(issueRequestParameter,false) :
                await _repositoryManager.Issue.GetIssuesByStudentIdAsync(issueRequestParameter,userId, false);
              
            var dtoItems =  pagedResponse.Items.Select(issue =>
            {
                var dto = _mapper.Map<IssueDto>(issue);

                return dto with { IsOwner = issue.UserId == userId };
            }).ToList();

            return new PagedResponse<IssueDto>(dtoItems, pagedResponse.MetaData);


        }

        public async Task<IssueDto> UpdateIssueStatus(UpdateIssueStatusDto updateIssueDto, int issueId)
        {
            var issue = await _repositoryManager.Issue.GetIssueByIdAsync(issueId, true);
            if (issue == null) { throw new Exception($"Idsi {issueId} olan bir issue bulunamadı!"); }

            if (issue.Status == updateIssueDto.Status)
                throw new Exception("Issue already in this status");

            issue.Status = updateIssueDto.Status;
            issue.LastUpdatedAt = DateTime.UtcNow;

            await _repositoryManager.SaveAsync();

            if (!issue.Status.Equals(IssueStatus.Closed))
            {
                await _mediator.Publish(new IssueStatusChangedEvent(issue.UserId, issue.Type, issue.Status, issue.LastUpdatedAt));            }

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
