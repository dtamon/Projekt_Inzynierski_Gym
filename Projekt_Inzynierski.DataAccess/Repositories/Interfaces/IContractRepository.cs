using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IContractRepository
    {
        public Task CreateContractAsync(Contract contract);
        public Task DeleteContractAsync(Contract contract);
        public Task<ICollection<Contract>> GetAllContractsAsync(SearchQuery query);
        public Task<Contract?> GetContractByIdAsync(int id);
        public Task UpdateContractAsync(Contract contract);
    }
}
