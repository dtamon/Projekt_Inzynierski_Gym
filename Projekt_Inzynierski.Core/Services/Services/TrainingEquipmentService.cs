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
    public class TrainingEquipmentService : ITrainingEquipmentService
    {
        private readonly ITrainingEquipmentRepository _trainingEquipmentRepository;
        private readonly IMapper _mapper;

        public TrainingEquipmentService(ITrainingEquipmentRepository trainingEquipmentRepository, IMapper mapper)
        {
            _trainingEquipmentRepository = trainingEquipmentRepository;
            _mapper = mapper;
        }

        public async Task CreateTrainingEquipmentAsync(TrainingEquipmentDto trainingEquipmentDto)
        {
            await _trainingEquipmentRepository.CreateTrainingEquipmentAsync(_mapper.Map<TrainingEquipment>(trainingEquipmentDto));
        }

        public async Task DeleteTrainingEquipmentAsync(int id)
        {
            var trainingEquipment = await _trainingEquipmentRepository.GetTrainingEquipmentByIdAsync(id);
            if (trainingEquipment != null)
            {
                await _trainingEquipmentRepository.DeleteTrainingEquipmentAsync(trainingEquipment);
            }
        }

        public async Task<ICollection<TrainingEquipmentDto>> GetAllTrainingEquipmentsAsync()
        {
            return _mapper.Map<ICollection<TrainingEquipmentDto>>(await _trainingEquipmentRepository.GetAllTrainingEquipmentAsync());
        }

        public async Task<TrainingEquipmentDto?> GetTrainingEquipmentByIdAsync(int id)
        {
            return _mapper.Map<TrainingEquipmentDto>(await _trainingEquipmentRepository.GetTrainingEquipmentByIdAsync(id));
        }

        public async Task UpdateTrainingEquipmentAsync(TrainingEquipmentDto trainingEquipmentDto, int id)
        {
            var trainingEquipment = await _trainingEquipmentRepository.GetTrainingEquipmentByIdAsync(id);
            if (trainingEquipment != null)
            {
                trainingEquipment.SerialNr = trainingEquipmentDto.SerialNr;
                trainingEquipment.TechnicalState = trainingEquipmentDto.TechnicalState;

                await _trainingEquipmentRepository.UpdateTrainingEquipmentAsync(trainingEquipment);
            }
        }
    }
}
