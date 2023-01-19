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
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Trainer> _passwordHasher;
        private readonly IUserContextService _userContextService;

        public TrainerService(ITrainerRepository trainerRepository, ISpecializationRepository specializationRepository, IMapper mapper, IPasswordHasher<Trainer> passwordHasher, IUserContextService userContextService)
        {
            _trainerRepository = trainerRepository;
            _specializationRepository = specializationRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _userContextService = userContextService;
        }
        public async Task CreateTrainerAsync(TrainerAccountDto trainerDto)
        {
            var specializations = new List<Specialization>();
            foreach (var specializaitonId in trainerDto.SpecializationIds)
            {
                var specialization = await _specializationRepository.GetSpecializationByIdAsync(specializaitonId);
                if (specialization == null)
                    throw new NotFoundException("Specialization not found");

                specializations.Add(specialization);
            }
            var newTrainer = new Trainer()
            {
                FirstName = trainerDto.FirstName,
                LastName = trainerDto.LastName,
                PhoneNr = trainerDto.PhoneNr,
                Email = trainerDto.Email,
                Pesel = trainerDto.Pesel,
                Role = trainerDto.Role,
                EmployedFrom = DateTime.Today,
                Salary = trainerDto.Salary,
                Specializations = specializations
            };
            var hashedPassword = _passwordHasher.HashPassword(newTrainer, trainerDto.Password);
            newTrainer.PasswordHash = hashedPassword;

            await _trainerRepository.CreateTrainerAsync(newTrainer);
        }

        public async Task DeleteTrainerAsync(int id)
        {
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);
            if (trainer == null)
                throw new NotFoundException("Trainer not found");

            await _trainerRepository.DeleteTrainerAsync(trainer);
        }

        public async Task<ICollection<TrainerViewDto>> GetAllTrainersAsync(SearchQuery query)
        {
            return _mapper.Map<ICollection<TrainerViewDto>>(await _trainerRepository.GetAllTrainersAsync(query));
        }

        public async Task<ICollection<TrainerViewDto>> GetOtherTrainersAsync()
        {
            var trainerId = (int)_userContextService.GetUserId;
            return _mapper.Map<ICollection<TrainerViewDto>>(await _trainerRepository.GetOtherTrainersAsync(trainerId));
        }

        public async Task<TrainerViewDto?> GetTrainerByIdAsync(int id)
        {
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);
            return _mapper.Map<TrainerViewDto>(await _trainerRepository.GetTrainerByIdAsync(id));
        }

        public async Task UpdateTrainerAsync(TrainerViewDto trainerDto, int id)
        {
            var specializations = new List<Specialization>();
            foreach (var specializaitonId in trainerDto.SpecializationIds)
            {
                var specialization = await _specializationRepository.GetSpecializationByIdAsync(specializaitonId);
                if (specialization == null)
                    throw new NotFoundException("Specialization not found");

                specializations.Add(specialization);
            }
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);
            if (trainer == null)
                throw new NotFoundException("Trainer not found");

            trainer.FirstName = trainerDto.FirstName;
            trainer.LastName = trainerDto.LastName;
            trainer.PhoneNr = trainerDto.PhoneNr;
            trainer.Email = trainerDto.Email;
            trainer.Pesel = trainerDto.Pesel;
            trainer.Salary = trainerDto.Salary;
            trainer.Specializations = specializations;
            trainer.EmployedTo = trainerDto.EmployedTo;

            await _trainerRepository.UpdateTrainerAsync(trainer);
        }
    }
}
