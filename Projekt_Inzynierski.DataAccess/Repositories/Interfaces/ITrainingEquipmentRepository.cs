using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface ITrainingEquipmentRepository
    {
        public Task<ICollection<TrainingEquipment>> GetAllTrainingEquipmentAsync();
        public Task CreateTrainingEquipmentAsync(TrainingEquipment trainingEquipment);
        public Task<TrainingEquipment?> GetTrainingEquipmentByIdAsync(int id);
        public Task UpdateTrainingEquipmentAsync(TrainingEquipment trainingEquipment);
        public Task DeleteTrainingEquipmentAsync(TrainingEquipment trainingEquipment);
    }
}
