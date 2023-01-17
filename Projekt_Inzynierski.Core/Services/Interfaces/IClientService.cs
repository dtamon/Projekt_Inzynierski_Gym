using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IClientService
    {
        public Task<DataToGeneratePdfDto> CreateClientAsync(ClientAccountDto clientDto);
        public Task UpdateClientAsync(ClientViewDto clientDto, int id);
        public Task DeleteClientAsync(int id);
        Task<ICollection<ClientViewDto>> GetAllClientsAsync(SearchQuery query);
        Task<ClientViewDto?> GetClientByIdAsync(int id);
    }
}
