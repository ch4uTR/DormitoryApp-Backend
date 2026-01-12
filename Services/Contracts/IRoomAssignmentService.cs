using Entity.DTOs.RoomAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRoomAssignmentService
    {

        Task<RoomAssignmentDto> CreateRoomAssignment(CreateRoomAssignmentDto createRoomAssignmentDto);

        Task<RoomAssignmentDto> GetRoomAssignment(int id);

    }
}
    