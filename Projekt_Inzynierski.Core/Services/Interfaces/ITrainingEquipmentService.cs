using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface ITrainingEquipmentService
    {
        public Task CreateTrainingEquipmentAsync(TrainingEquipmentDto trainingEquipmentDto);
        public Task UpdateTrainingEquipmentAsync(TrainingEquipmentDto trainingEquipmentDto, int id);
        public Task DeleteTrainingEquipmentAsync(int id);
        Task<ICollection<TrainingEquipmentDto>> GetAllTrainingEquipmentsAsync(SearchQuery query);
        Task<TrainingEquipmentDto?> GetTrainingEquipmentByIdAsync(int id);
    }
}
