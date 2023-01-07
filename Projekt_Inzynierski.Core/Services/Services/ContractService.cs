using AutoMapper;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task CreateContractAsync(ContractDto contractDto)
        {
            await _contractRepository.CreateContractAsync(_mapper.Map<Contract>(contractDto));
        }

        public async Task DeleteContractAsync(int id)
        {
            var contract = await _contractRepository.GetContractByIdAsync(id);
            if (contract != null)
            {
                await _contractRepository.DeleteContractAsync(contract);
            }
        }

        public async Task<ICollection<ContractDto>> GetAllContractsAsync()
        {
            return _mapper.Map<ICollection<ContractDto>>(await _contractRepository.GetAllContractsAsync());
        }

        public async Task<ContractDto?> GetContractByIdAsync(int id)
        {
            return _mapper.Map<ContractDto>(await _contractRepository.GetContractByIdAsync(id));
        }

        public async Task UpdateContractAsync(ContractDto contractDto, int id)
        {
            var contract = await _contractRepository.GetContractByIdAsync(id);
            if (contract != null)
            {
                contract.Months = contractDto.Months;
                contract.MonthlyCost = contractDto.MonthlyCost;

                await _contractRepository.UpdateContractAsync(contract);
            }
        }
    }
}
