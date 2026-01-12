using AutoMapper;
using Entity.DTOs.Announcement;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AnnouncementService : IAnnouncementService
    {

        private readonly IRepositoryManager _repositoriesManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AnnouncementService(IRepositoryManager repositoriesManager, IMapper mapper, UserManager<User> userManager)
        {
            _repositoriesManager = repositoriesManager;
            _mapper = mapper;   
            _userManager = userManager;
        }

        public async Task<AdminAnnouncementDto> CreateAnnouncementAsync(string adminId, CreateAnnouncementDto createAnnouncementDto)
        {
            var admin = await _userManager.FindByIdAsync(adminId);
            if (admin == null) { throw new Exception($"Id nosu: {adminId} olan admin kullanıcısı bulunamadı!"); }

            //admin mi role'ü?

            var entity = _mapper.Map<Announcement>(createAnnouncementDto);
            entity.AdminId = adminId;

            _repositoriesManager.Announcement.Create(entity);
            await _repositoriesManager.SaveAsync();

            return _mapper.Map<AdminAnnouncementDto>(entity);
        }

        public async Task<IEnumerable<AdminAnnouncementDto>> GetAllForAdminAsync(bool newAnnouncementFirst, bool trackChanges)
        {
            var announcements = await _repositoriesManager.Announcement.GetAllAnnouncementAsync(newAnnouncementFirst, trackChanges);
            
            return _mapper.Map<IEnumerable<AdminAnnouncementDto>>(announcements);
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAnnouncementsForStudentAsync(string studentId, bool trackChanges)
        {
            var assignment = await _repositoriesManager.RoomAssignment.GetRoomAssignmentByStudentId(studentId);

            if (assignment == null) { throw new Exception($"Öğrenci nosu: {studentId} olan öğrenciye ait oda bulunamadı!"); }

            var announcements = await _repositoriesManager
                .Announcement.
                GetAnnouncementsForStudentAsync(
                    assignment.Room?.Floor?.BlockId,
                    assignment.Room?.FloorId, trackChanges);

            return _mapper.Map<IEnumerable<AnnouncementDto>>(announcements);
        }

    }
 
}
