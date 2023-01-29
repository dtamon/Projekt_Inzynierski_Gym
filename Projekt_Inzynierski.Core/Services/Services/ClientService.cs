using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Exceptions;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;

namespace Projekt_Inzynierski.Core.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Client> _passwordHasher;

        public ClientService(IClientRepository clientRepository, IMapper mapper, IContractRepository contractRepository, IPasswordHasher<Client> passwordHasher, IPersonRepository personRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _contractRepository = contractRepository;
            _passwordHasher = passwordHasher;
            _personRepository = personRepository;
        }

        public async Task<DataToGeneratePdfDto> CreateClientAsync(ClientAccountDto clientDto)
        {
            if (await _personRepository.IsEmailTaken(clientDto.Id, clientDto.Email))
                throw new EmailIsTakenException("Email jest zajęty");
            if (await _personRepository.IsPhoneNrTaken(clientDto.Id, clientDto.PhoneNr))
                throw new PhoneNrIsTakenException("Numer telefonu jest zajęty");
            if (await _personRepository.IsPeselTaken(clientDto.Id, clientDto.Pesel))
                throw new PeselIsTakenException("Pesel jest zajęty");
            

            clientDto.ContractStart = DateTime.Today;
            var contract = await _contractRepository.GetContractByIdAsync(clientDto.ContractId);
            if (contract == null)
                throw new NotFoundException("Contract not found");

            clientDto.ContractEnd = clientDto.ContractStart.AddMonths(contract.Months);

            var newClient = _mapper.Map<Client>(clientDto);
            var hashedPassword = _passwordHasher.HashPassword(newClient, clientDto.Password);
            newClient.PasswordHash = hashedPassword;

            await _clientRepository.CreateClientAsync(newClient);

            var dataToPdf = new DataToGeneratePdfDto()
            {
                Client = clientDto,
                Contract = _mapper.Map<ContractDto>(contract)
            };

            return dataToPdf;
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
                throw new NotFoundException("Client not found");

            await _clientRepository.DeleteClientAsync(client);

        }

        public async Task<ICollection<ClientViewDto>> GetAllClientsAsync(SearchQuery query)
        {
            return _mapper.Map<ICollection<ClientViewDto>>(await _clientRepository.GetAllClientsAsync(query));
        }

        public async Task<ClientViewDto?> GetClientByIdAsync(int id)
        {
            return _mapper.Map<ClientViewDto>(await _clientRepository.GetClientByIdAsync(id));
        }

        public async Task<DataToGeneratePdfDto> UpdateClientAsync(ClientViewDto clientDto, int id)
        {
            if (await _personRepository.IsEmailTaken(clientDto.Id, clientDto.Email))
                throw new EmailIsTakenException("Email jest zajęty");
            if (await _personRepository.IsPhoneNrTaken(clientDto.Id, clientDto.PhoneNr))
                throw new PhoneNrIsTakenException("Numer telefonu jest zajęty");
            if (await _personRepository.IsPeselTaken(clientDto.Id, clientDto.Pesel))
                throw new PeselIsTakenException("Pesel jest zajęty");

            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
                throw new NotFoundException("Client not found");

            var contract = await _contractRepository.GetContractByIdAsync(clientDto.ContractId);
            if (contract == null)
                throw new NotFoundException("Contract not found");

            if (client.ContractId != clientDto.ContractId)
            {
                clientDto.ContractStart = DateTime.Today;
                clientDto.ContractEnd = clientDto.ContractStart.AddMonths(contract.Months);
            }

            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.PhoneNr = clientDto.PhoneNr;
            client.Email = clientDto.Email;
            client.Pesel = clientDto.Pesel;
            client.ContractId = clientDto.ContractId;
            client.ContractStart = clientDto.ContractStart;
            client.ContractEnd = clientDto.ContractEnd;

            await _clientRepository.UpdateClientAsync(client);

            var dataToPdf = new DataToGeneratePdfDto()
            {
                Client = _mapper.Map<ClientAccountDto>(client),
                Contract = _mapper.Map<ContractDto>(contract)
            };

            return dataToPdf;
        }
    }
}
