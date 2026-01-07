using AutoMapper;
using Entity.DTOs;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
       

        public AuthService(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {   
            _configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
        }

       

        public async Task<IdentityResult> RegisterUser(RegistrationDto registrationDto)
        {
            User user;

            if (registrationDto.Role.Equals("Student", StringComparison.OrdinalIgnoreCase))
            {
                user = _mapper.Map<Student>(registrationDto);
            }

            else if (registrationDto.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                user = _mapper.Map<Admin>(registrationDto);
            }

            else
            {
                user = _mapper.Map<LaundryMan>(registrationDto);
            }



            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registrationDto.Role);
            }

            return result;


        }

        public async Task<TokenDto?> Login(LoginDto logindDto)
        {
            var user = await _userManager.FindByNameAsync(logindDto.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, logindDto.Password))
            {
                var tokenString = await CreateToken(user);

                return new TokenDto
                {
                    AccessToken = tokenString,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(60),
                };
            }

            return null;
        }


        private async Task<string> CreateToken(User user)
        {

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["key"];
            var expires =  Convert.ToInt32(jwtSettings["expires"]);


            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }


            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));


            var token = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                expires: DateTime.UtcNow.AddMinutes(expires),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );

            return  new JwtSecurityTokenHandler().WriteToken(token);    
        }
    }
}
