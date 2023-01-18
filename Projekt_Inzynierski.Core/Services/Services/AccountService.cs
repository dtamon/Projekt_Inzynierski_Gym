using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Exceptions;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPasswordHasher<Person> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IPersonRepository personRepository, IPasswordHasher<Person> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _personRepository = personRepository;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<UserSession?> GenerateJwt(LoginDto dto)
        {
            var user = await _personRepository.GetUserByEmail(dto.Email);

            if (user == null)
                throw new BadRequestException("Invalid username or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid username or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            var userSession = new UserSession
            {
                UserId = user.Id,
                UserName = $"{user.FirstName} {user.LastName}",
                Role = user.Role,
                Token = tokenHandler.WriteToken(token),
                ExpiresIn = (int)expires.Subtract(DateTime.Now).TotalSeconds
            };

            return userSession;
        }
    }
}
