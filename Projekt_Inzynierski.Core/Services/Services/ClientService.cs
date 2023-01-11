using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Client> _passwordHasher;

        public ClientService(IClientRepository clientRepository, IMapper mapper, IContractRepository contractRepository, IPasswordHasher<Client> passwordHasher)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _contractRepository = contractRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateClientAsync(ClientAccountDto clientDto)
        {
            clientDto.ContractStart = DateTime.Today;
            var contract = await _contractRepository.GetContractByIdAsync(clientDto.ContractId);
            if (contract != null)
            {
                clientDto.ContractEnd = clientDto.ContractStart.AddMonths(contract.Months);
            }
            var newClient = _mapper.Map<Client>(clientDto);
            var hashedPassword = _passwordHasher.HashPassword(newClient, clientDto.Password);
            newClient.PasswordHash = hashedPassword;

            await _clientRepository.CreateClientAsync(newClient);
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client != null)
            {
                await _clientRepository.DeleteClientAsync(client);
            }
        }

        public async Task<ICollection<ClientViewDto>> GetAllClientsAsync()
        {
            return _mapper.Map<ICollection<ClientViewDto>>(await _clientRepository.GetAllClientsAsync());
        }

        public async Task<ClientViewDto?> GetClientByIdAsync(int id)
        {
            return _mapper.Map<ClientViewDto>(await _clientRepository.GetClientByIdAsync(id));
        }

        public async Task UpdateClientAsync(ClientViewDto clientDto, int id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client != null)
            {
                client.FirstName = clientDto.FirstName;
                client.LastName = clientDto.LastName;
                client.PhoneNr = clientDto.PhoneNr;
                client.Email = clientDto.Email;
                client.Pesel = clientDto.Pesel;
                client.ContractId = clientDto.ContractId;

                await _clientRepository.UpdateClientAsync(client);
            }
        }
    }
}
