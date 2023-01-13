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
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Trainer> _passwordHasher;

        public TrainerService(ITrainerRepository trainerRepository, ISpecializationRepository specializationRepository, IMapper mapper, IPasswordHasher<Trainer> passwordHasher)
        {
            _trainerRepository = trainerRepository;
            _specializationRepository = specializationRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task CreateTrainerAsync(TrainerAccountDto trainerDto)
        {
            var specializations = new List<Specialization>();
            foreach (var specializaitonId in trainerDto.SpecializationIds)
            {
                var specialization = await _specializationRepository.GetSpecializationByIdAsync(specializaitonId);
                if (specialization != null)
                {
                    specializations.Add(specialization);
                }
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
            if (trainer != null)
            {
                await _trainerRepository.DeleteTrainerAsync(trainer);
            }
        }

        public async Task<ICollection<TrainerViewDto>> GetAllTrainersAsync()
        {
            return _mapper.Map<ICollection<TrainerViewDto>>(await _trainerRepository.GetAllTrainersAsync());
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
                if (specialization != null)
                {
                    specializations.Add(specialization);
                }
            }
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);
            if (trainer != null)
            {
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
}
