using Projekt_Inzynierski.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IContractService
    {
        public Task CreateContractAsync(ContractDto contractDto);
        public Task UpdateContractAsync(ContractDto contractDto, int id);
        public Task DeleteContractAsync(int id);
        public Task<ICollection<ContractDto>> GetAllContractsAsync();
        public Task<ContractDto?> GetContractByIdAsync(int id);
    }
}
