using Microsoft.AspNetCore.Http;
using Projekt_Inzynierski.Core.Services.Interfaces;
using System.Security.Claims;

namespace Projekt_Inzynierski.Core.Services.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int? GetUserId => User is null ? null : int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public string? GetUserRole => User is null ? null : User.FindFirst(c => c.Type == ClaimTypes.Role).Value;
    }
}
