using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Projekt_Inzynierski.Client.Authentication;
using Projekt_Inzynierski.Core.DTOs;
using System.Security.Claims;

namespace Projekt_Inzynierski.Client.Extensions
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = await _sessionStorageService.ReadEncryptedItemAsync<UserSession>("UserSession");
                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "JwtAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

        }

        public async Task UpdateAuthenticationState(UserSession? userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
                userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpiresIn);
                await _sessionStorageService.SaveItemEncryptedAsync("UserSession", userSession);
            }
            else
            {
                claimsPrincipal = _anonymous;
                await _sessionStorageService.RemoveItemAsync("UserSession");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetToken()
        {
            var result = string.Empty;

            try
            {
                var userSession = await _sessionStorageService.ReadEncryptedItemAsync<UserSession>("UserSession");
                if (userSession != null & DateTime.Now < userSession.ExpiryTimeStamp)
                    result = userSession.Token;
            }
            catch { }
            return result;
        }

        public async Task<string> GetRole()
        {
            var result = string.Empty;
            try
            {
                var userSession = await _sessionStorageService.ReadEncryptedItemAsync<UserSession>("UserSession");
                if (userSession != null & DateTime.Now < userSession.ExpiryTimeStamp)
                    result = userSession.Role;
            }
            catch { }
            return result;
        }

        public async Task<int> GetId()
        {
            var result = 0;
            try
            {
                var userSession = await _sessionStorageService.ReadEncryptedItemAsync<UserSession>("UserSession");
                if (userSession != null & DateTime.Now < userSession.ExpiryTimeStamp)
                    result = userSession.UserId;

            }
            catch { }
            return result;
        }
    }
}
