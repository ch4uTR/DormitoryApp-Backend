using AutoMapper;
using Entity.DTOs.RoomAssignment;
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
    public class RoomAssignmentService : IRoomAssignmentService
    {

        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RoomAssignmentService(IRepositoryManager repositoryManager, UserManager<User> userManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<RoomAssignmentDto> CreateRoomAssignment(CreateRoomAssignmentDto createRoomAssignmentDto)
        {
            if (createRoomAssignmentDto == null) { throw new Exception("Alanlar boş bırakılamaz!"); }

            //böyle bir user var mı?
            var studentId = createRoomAssignmentDto.StudentId;
            var user = await _userManager.FindByIdAsync(studentId);
            if (user == null) { throw new Exception($"Id nosu: {studentId} olan öğrenci bulunamadı!"); }

            var userRoles = await _userManager.GetRolesAsync(user);

            var isStudent = userRoles.Contains("Student");

            if (!isStudent)
            {
                throw new Exception($"Id nosu: {studentId} olan kullanıcının rolü Student değil!");
            }


            //bu user'ın odası var mı?
            if (await _repositoryManager.RoomAssignment.HasStudentGotRoomAssignment(studentId))
            {
                throw new Exception("Öğrencinin zaten odası bulunmakta!");
            }


            //odada yer var mı?

            if (await _repositoryManager.Room.IsRoomFull(createRoomAssignmentDto.RoomId))
            {
                throw new Exception("Seçilen oda kapasitesi dolu!");
            }


            var roomAssignment = _mapper.Map<RoomAssignment>(createRoomAssignmentDto);
            _repositoryManager.RoomAssignment.Create(roomAssignment);

            await _repositoryManager.SaveAsync();

            var assignmentWithDetails = await _repositoryManager.RoomAssignment.GetRoomAssignmentWithDetails(roomAssignment.Id);
            return _mapper.Map<RoomAssignmentDto>(assignmentWithDetails);

        }

        public async Task<RoomAssignmentDto> GetRoomAssignment(int id)
        {
            var assignmentWithDetails = await _repositoryManager.RoomAssignment.GetRoomAssignmentWithDetails(id);

            if (assignmentWithDetails == null) { throw new Exception($"Id nosu: {id} olan oda ataması bulunamadı"); }

            return _mapper.Map<RoomAssignmentDto>(assignmentWithDetails);
        }
    }
}
