using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRoomAssignmentRepository : IRepositoryBase<RoomAssignment>
    {

        Task<RoomAssignment?> GetRoomAssignmentByStudentId(string studentId);

        Task<RoomAssignment> GetRoomAssignmentWithDetails(int id);

        Task<bool> HasStudentGotRoomAssignment(string studentId);

        
    }
}
