using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Issue
{
    public record AdminIssueDto : IssueDto
    {
        public required string UserId { get; init; }
        public bool IsDeleted { get; init; }
    }
}
