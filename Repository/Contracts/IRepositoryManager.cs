using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryManager
    {

        IBlockRepository Block {  get; }
        IFloorRepository Floor { get; }
        IIssueRepository Issue { get; }
        IIssueVoteRepository IssueVote { get; }
        IRoomAssignmentRepository RoomAssignment { get; }
        IRoomRepository Room { get; }
        IAnnouncementRepository Announcement { get; }
        ILaundrySlotRepository LaundrySlot { get; }
        ILaundryReservationRepository LaundryReservation { get; }   



        void Save();

        Task SaveAsync();

    }
}
