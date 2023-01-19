using Projekt_Inzynierski.Core.DTOs;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserSession?> GenerateJwt(LoginDto dto);
    }
}
