using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Auth
{
    public record TokenDto
    {
        public string AccessToken { get; init; }
        public string UerId { get; init; }
        
        public string FullName { get; init; }
        public string Role {  get; init; }  
        public DateTime ExpiresAt { get; init; }
    }
}
