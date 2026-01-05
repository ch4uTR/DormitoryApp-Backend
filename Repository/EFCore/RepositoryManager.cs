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



        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _blockRepository = new Lazy<IBlockRepository>(() => new BlockRepository(_repositoryContext));
            _floorRepository = new Lazy<IFloorRepository>(() => new FloorRepository(_repositoryContext));
            _issueRepository = new Lazy<IIssueRepository>(() => new IssueRepository(_repositoryContext));
            _issueVoteRepository = new Lazy<IIssueVoteRepository>(() => new IssueVoteRepository(_repositoryContext));
            _roomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(_repositoryContext));
            _roomAssignmentRepository = new Lazy<IRoomAssignmentRepository>(() => new RoomAssignmentRepository(_repositoryContext));
        }   


        public IBlockRepository Block => _blockRepository.Value;
        public IFloorRepository Floor => _floorRepository.Value;
        public IIssueRepository Issue => _issueRepository.Value;
        public IIssueVoteRepository IssueVote => _issueVoteRepository.Value;
        public IRoomRepository Room => _roomRepository.Value;
        public IRoomAssignmentRepository RoomAssignment => _roomAssignmentRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();

    }
}
