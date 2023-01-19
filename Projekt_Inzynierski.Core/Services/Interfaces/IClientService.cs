using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Queries;

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
