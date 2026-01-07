using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs;

public record RegistrationDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string Role { get; init; }

    
    public string? StudentNumber { get; init; }
    public string? Department { get; init; }
}
