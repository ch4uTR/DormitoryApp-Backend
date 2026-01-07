using Entity.DTOs;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(RegistrationDto registrationDto);
        Task<TokenDto?> Login(LoginDto loginDto);


    }
}
