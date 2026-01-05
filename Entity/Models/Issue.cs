using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Issue
    {

        public int Id { get; set; }
        public IssueType Type { get; set; }
        public string? Description { get; set; }
        public IssueStatus Status { get; set; } = IssueStatus.Pending;

        public ICollection<IssueVote> Votes { get; set; }
        public int VoteCount => Votes?.Count ?? 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; }

        public string UserId { get; set; }  
        public User User { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }



    }

    public enum IssueType
    {
        Refrigerator,
        Electricity,
        Internet,
        Radiator,
        Plumbing,
        Furniture
    }

    public enum IssueStatus
    {
        Pending,
        InProgress,
        Resolved,
        Closed
    }



}

