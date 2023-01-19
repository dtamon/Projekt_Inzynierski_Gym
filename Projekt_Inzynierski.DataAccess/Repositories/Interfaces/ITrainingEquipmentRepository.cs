using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface ITrainingEquipmentRepository
    {
        public Task<ICollection<TrainingEquipment>> GetAllTrainingEquipmentAsync(SearchQuery query);
        public Task CreateTrainingEquipmentAsync(TrainingEquipment trainingEquipment);
        public Task<TrainingEquipment?> GetTrainingEquipmentByIdAsync(int id);
        public Task UpdateTrainingEquipmentAsync(TrainingEquipment trainingEquipment);
        public Task DeleteTrainingEquipmentAsync(TrainingEquipment trainingEquipment);
    }
}
