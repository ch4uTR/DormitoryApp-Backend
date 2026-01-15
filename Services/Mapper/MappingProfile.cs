using AutoMapper;
using Entity.DTOs.Announcement;
using Entity.DTOs.Auth;
using Entity.DTOs.Issue;
using Entity.DTOs.Laundry;
using Entity.DTOs.Notification;
using Entity.DTOs.RoomAssignment;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<RegistrationDto, Student>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.StudentNumber));

            CreateMap<RegistrationDto, Admin>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<RegistrationDto, LaundryMan>()
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));


            /* -------------------- ISSUE MAPPING --------------------  */

            CreateMap<Issue, IssueDto>()
                .ForMember(dest => dest.IsOwner, opt => opt.Ignore());
            CreateMap<Issue, AdminIssueDto>();
            CreateMap<CreateIssueDto, Issue>();
            CreateMap<UpdateIssueDto, Issue>();


            /* -------------------- RoomAssignment MAPPING --------------------  */

            CreateMap<CreateRoomAssignmentDto, RoomAssignment>();
            CreateMap<RoomAssignment, RoomAssignmentDto>()

                .ForMember(dest => dest.RoomNumber,
                    opt => opt.MapFrom(src => src.Room.RoomNumber))

                .ForMember(dest => dest.FloorNumber,
                    opt => opt.MapFrom(src => src.Room.Floor.FloorNumber))

                .ForMember(dest => dest.BlockName,
                    opt => opt.MapFrom(src => src.Room.Floor.Block.BlockName));

            CreateMap<RoomAssignment, AdminRoomAssignmentDto>()
                .IncludeBase<RoomAssignment, RoomAssignmentDto>();

            /* -------------------- Announcement MAPPING --------------------  */

            CreateMap<Announcement, AnnouncementDto >();
            CreateMap<Announcement, AdminAnnouncementDto>();
            CreateMap<CreateAnnouncementDto, Announcement>();
            CreateMap<UpdateAnnouncementDto, Announcement>();

            /* -------------------- Laundry MAPPING --------------------  */
            CreateMap<LaundrySlot, LaundrySlotDto>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString(@"hh\:mm")))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(@"hh\:mm")))
                .ForMember(dest => dest.AvailableCapacity, opt => opt.MapFrom(src => src.TotalCapacity - src.ReservedCount))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<LaundryReservation, LaundryReservationDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName)) // User entity'sinden çekiyoruz
            .ForMember(dest => dest.SlotDate, opt => opt.MapFrom(src => src.Slot.Date))
            .ForMember(dest => dest.TimeInterval, opt => opt.MapFrom(src =>
                $"{src.Slot.StartTime.ToString(@"hh\:mm")} - {src.Slot.EndTime.ToString(@"hh\:mm")}"))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateReservationDto, LaundryReservation>();

            /* -------------------- Notification Token MAPPING --------------------  */

            CreateMap<NotificationToken, NotificationTokenDto>();
            CreateMap<NotificationTokenDto, NotificationToken>();



        }


    }
}
