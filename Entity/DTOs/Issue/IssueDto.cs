using Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Issue
{
    public record IssueDto
    {

        public int Id { get; init; }
        public IssueType Type { get; init; }
        public string? Description { get; init; }
        public IssueStatus Status { get; init; }
        public int VoteCount { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime LastUpdatedAt { get; init; }
        
        public bool IsOwner { get; init; }

    }
}
