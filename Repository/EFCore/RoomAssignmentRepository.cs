using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RoomAssignmentRepository : RepositoryBase<RoomAssignment>, IRoomAssignmentRepository
    {
        public RoomAssignmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<RoomAssignment?> GetRoomAssignmentByStudentId(string studentId)
        {
            var query =  FindByCondition(ra => ra.StudentId == studentId, false);
            return await query.SingleOrDefaultAsync();
        }

        public async Task<RoomAssignment?> GetRoomAssignmentWithDetails(int id)
        {
            return await FindByCondition(x => x.Id == id, false)
                .Include(ra => ra.Room)
                    .ThenInclude(r => r.Floor)
                        .ThenInclude(f => f.Block)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> HasStudentGotRoomAssignment(string studentId)
        {
            var query = FindByCondition(ra => ra.StudentId == studentId && ra.IsActive, false);
            return await query.AnyAsync();
        }

        
    }
}
