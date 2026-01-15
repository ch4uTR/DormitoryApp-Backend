using AutoMapper;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ServiceManager : IServiceManager
    {

        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<IIssueService> _issueService;
        private readonly Lazy<IRoomAssignmentService> _roomAssignmentService;
        private readonly Lazy<IIssueVoteService> _voteService;
        private readonly Lazy<IAnnouncementService> _announcementService;
        private readonly Lazy<ILaundryService> _laundryService;
        private readonly Lazy<INotificationService> _notificationService;

        

        public ServiceManager(
            IRepositoryManager repositoryManager,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration
            )
        {   

            _issueService = new Lazy<IIssueService>(
                () => new IssueService(mapper, repositoryManager, userManager));

            _authService = new Lazy<IAuthService>(
                () => new AuthService(userManager, mapper, configuration));

            _roomAssignmentService = new Lazy<IRoomAssignmentService>(
                () => new RoomAssignmentService(repositoryManager, userManager, mapper));

            _voteService = new Lazy<IIssueVoteService>(
                () => new IssueVoteService(repositoryManager));

            _announcementService = new Lazy<IAnnouncementService>(
                () => new AnnouncementService(repositoryManager, mapper, userManager));

            _laundryService = new Lazy<ILaundryService>(
                () => new LaundryService(repositoryManager, mapper));

            _notificationService = new Lazy<INotificationService>(
                () => new NotificationService(repositoryManager, mapper));
        }
        


        public IAuthService AuthService => _authService.Value;
        public IIssueService IssueService => _issueService.Value;    
        public IRoomAssignmentService RoomAssignmentService => _roomAssignmentService.Value;
        public IIssueVoteService VoteService => _voteService.Value;
        public IAnnouncementService AnnouncementService => _announcementService.Value;

        public ILaundryService LaundryService => _laundryService.Value;

        public INotificationService NotificationService => _notificationService.Value;
    }
}
