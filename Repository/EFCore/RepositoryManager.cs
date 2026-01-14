using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IBlockRepository> _blockRepository;
        private readonly Lazy<IFloorRepository> _floorRepository;
        private readonly Lazy<IIssueRepository> _issueRepository;
        private readonly Lazy<IIssueVoteRepository> _issueVoteRepository;
        private readonly Lazy<IRoomRepository> _roomRepository;
        private readonly Lazy<IRoomAssignmentRepository> _roomAssignmentRepository;
        private readonly Lazy<IAnnouncementRepository> _announcementRepository;
        private readonly Lazy<ILaundrySlotRepository> _laundrySlotRepository;
        private readonly Lazy<ILaundryReservationRepository> _laundryReservationRepository;
        private readonly Lazy<INotificationTokenRepository> _notificationTokenRepository;



        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _blockRepository = new Lazy<IBlockRepository>(() => new BlockRepository(_repositoryContext));
            _floorRepository = new Lazy<IFloorRepository>(() => new FloorRepository(_repositoryContext));
            _issueRepository = new Lazy<IIssueRepository>(() => new IssueRepository(_repositoryContext));
            _issueVoteRepository = new Lazy<IIssueVoteRepository>(() => new IssueVoteRepository(_repositoryContext));
            _roomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(_repositoryContext));
            _roomAssignmentRepository = new Lazy<IRoomAssignmentRepository>(() => new RoomAssignmentRepository(_repositoryContext));
            _announcementRepository = new Lazy<IAnnouncementRepository>(() => new AnnouncementRepository(_repositoryContext));
            _laundrySlotRepository = new Lazy<ILaundrySlotRepository>(() => new LaundrySlotRepository(_repositoryContext));
            _laundryReservationRepository = new Lazy<ILaundryReservationRepository>(() => new LaundryReservationRepository(_repositoryContext));
            _notificationTokenRepository = new Lazy<INotificationTokenRepository>(() => new NotificationTokenRepository(_repositoryContext));
        }   


        public IBlockRepository Block => _blockRepository.Value;
        public IFloorRepository Floor => _floorRepository.Value;
        public IIssueRepository Issue => _issueRepository.Value;
        public IIssueVoteRepository IssueVote => _issueVoteRepository.Value;
        public IRoomRepository Room => _roomRepository.Value;
        public IRoomAssignmentRepository RoomAssignment => _roomAssignmentRepository.Value;
        public IAnnouncementRepository Announcement => _announcementRepository.Value;
        public ILaundrySlotRepository LaundrySlot => _laundrySlotRepository.Value;
        public ILaundryReservationRepository LaundryReservation => _laundryReservationRepository.Value;

        public INotificationTokenRepository NotificationToken => _notificationTokenRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

    }
}
