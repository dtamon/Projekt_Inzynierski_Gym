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
        public Task CreateClientAsync(ClientDto clientDto);
        public Task UpdateClientAsync(ClientDto clientDto, int id);
        public Task DeleteClientAsync(int id);
        Task<ICollection<ClientDto>> GetAllClientsAsync();
        Task<ClientDto?> GetClientByIdAsync(int id);
    }
}
