using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
