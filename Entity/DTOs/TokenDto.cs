using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public record TokenDto
    {
        public string AccessToken { get; init; }
        public DateTime ExpiresAt { get; init; }
    }
}
