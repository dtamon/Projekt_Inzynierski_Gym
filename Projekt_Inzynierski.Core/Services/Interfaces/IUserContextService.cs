using System.Security.Claims;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? GetUserId { get; }
        string? GetUserRole { get; }
    }
}
