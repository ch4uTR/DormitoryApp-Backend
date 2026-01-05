using Entity.Models;
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
    }
}
