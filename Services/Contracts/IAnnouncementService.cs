using Entity.DTOs.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface  IAnnouncementService
    {
        Task<IEnumerable<AnnouncementDto>> GetAnnouncementsForStudentAsync(string studentId, bool trackChanges);

        Task<IEnumerable<AdminAnnouncementDto>> GetAllForAdminAsync(bool newAnnouncementFirst, bool trackChanges);

        Task<AdminAnnouncementDto> CreateAnnouncementAsync(string adminId, CreateAnnouncementDto createAnnouncementDto);



    }
}
