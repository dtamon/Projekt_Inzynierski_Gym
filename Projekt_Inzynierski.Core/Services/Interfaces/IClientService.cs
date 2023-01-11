using Projekt_Inzynierski.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IClientService
    {
        public Task CreateClientAsync(ClientAccountDto clientDto);
        public Task UpdateClientAsync(ClientViewDto clientDto, int id);
        public Task DeleteClientAsync(int id);
        Task<ICollection<ClientViewDto>> GetAllClientsAsync();
        Task<ClientViewDto?> GetClientByIdAsync(int id);
    }
}
