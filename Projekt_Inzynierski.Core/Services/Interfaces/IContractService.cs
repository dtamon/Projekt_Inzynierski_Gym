using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IContractService
    {
        public Task CreateContractAsync(ContractDto contractDto);
        public Task UpdateContractAsync(ContractDto contractDto, int id);
        public Task DeleteContractAsync(int id);
        public Task<ICollection<ContractDto>> GetAllContractsAsync(SearchQuery query);
        public Task<ContractDto?> GetContractByIdAsync(int id);
    }
}
