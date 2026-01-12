using Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Issue
{
    public record CreateIssueDto
    {
        public string? StudentId { get; init; }

        [Required(ErrorMessage = "Lütfen sorun tipini seçiniz.")]
        public IssueType Type { get; init; }
        public string? Description { get; init; }

    }
}
