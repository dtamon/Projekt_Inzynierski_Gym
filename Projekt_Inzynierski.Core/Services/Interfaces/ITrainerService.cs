using Projekt_Inzynierski.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface ITrainerService
    {
        public Task CreateTrainerAsync(TrainerDto trainerDto);
        public Task UpdateTrainerAsync(TrainerDto trainerDto, int id);
        public Task DeleteTrainerAsync(int id);
        public Task<ICollection<TrainerDto>> GetAllTrainersAsync();
        public Task<TrainerDto?> GetTrainerByIdAsync(int id);

    }
}
