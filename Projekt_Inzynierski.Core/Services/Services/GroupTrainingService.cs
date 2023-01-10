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
    public class GroupTrainingService : IGroupTrainingService
    {
        private readonly IGroupTrainingRepository _groupTrainingRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public GroupTrainingService(IGroupTrainingRepository groupTrainingRepository, IClientRepository clientRepository, ITrainerRepository trainerRepository, IMapper mapper)
        {
            _groupTrainingRepository = groupTrainingRepository;
            _clientRepository = clientRepository;
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task CreateGroupTrainingAsync(GroupTrainingDto groupTrainingDto)
        {
            var trainers = new List<Trainer>();
            foreach (var trainerId in groupTrainingDto.TrainerIds)
            {
                var trainer = await _trainerRepository.GetTrainerByIdAsync(trainerId);
                if (trainer != null)
                {
                    trainers.Add(trainer);
                }
            }

            var newGroupTraining = new GroupTraining()
            {
                MaxCLients = groupTrainingDto.MaxClients,
                StartDate = groupTrainingDto.StartDate,
                Trainers = trainers,
            };
            
            await _groupTrainingRepository.CreateGroupTrainingAsync(newGroupTraining);
        }

        public async Task DeleteGroupTrainingAsync(int id)
        {
            var groupTraining = await _groupTrainingRepository.GetGroupTrainingByIdAsync(id);
            if (groupTraining != null)
            {
                await _groupTrainingRepository.DeleteGroupTrainingAsync(groupTraining);
            }
        }

        public async Task<ICollection<GroupTrainingDto>> GetAllGroupTrainingsAsync()
        {
            return _mapper.Map<ICollection<GroupTrainingDto>>(await _groupTrainingRepository.GetAllGroupTrainingsAsync());
        }

        public async Task<GroupTrainingDto?> GetGroupTrainingByIdAsync(int id)
        {
            return _mapper.Map<GroupTrainingDto>(await _groupTrainingRepository.GetGroupTrainingByIdAsync(id));
        }

        public async Task UpdateGroupTrainingAsync(GroupTrainingDto groupTrainingDto, int id)
        {
            var trainers = new List<Trainer>();
            var clients = new List<Client>();

            foreach (var trainerId in groupTrainingDto.TrainerIds)
            {
                var trainer = await _trainerRepository.GetTrainerByIdAsync(trainerId);
                if (trainer != null)
                {
                    trainers.Add(trainer);
                }
            }

            foreach (var clientId in groupTrainingDto.ClientIds)
            {
                var client = await _clientRepository.GetClientByIdAsync(clientId);
                if (client != null)
                {
                    clients.Add(client);
                }
            }

            var groupTraining = await _groupTrainingRepository.GetGroupTrainingByIdAsync(id);

            if (groupTraining != null)
            {
                groupTraining.MaxCLients = groupTrainingDto.MaxClients;
                groupTraining.StartDate = groupTrainingDto.StartDate;
                groupTraining.Clients = clients;
                groupTraining.Trainers = trainers;

                await _groupTrainingRepository.UpdateGroupTrainingAsync(groupTraining);
            }


        }
    }
}
