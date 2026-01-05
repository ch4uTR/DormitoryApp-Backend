using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class IssueVote
    {
        public int Id { get; set; }

        public int IssueId { get; set; }
        public Issue Issue {get; set;}
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime VotedAt { get; set; } = DateTime.UtcNow;

    }
}
