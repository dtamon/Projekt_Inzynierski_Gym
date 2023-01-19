using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;

namespace Projekt_Inzynierski.DataAccess.Repositories.Repositories
{
    public class TrainingEquipmentRepository : ITrainingEquipmentRepository
    {
        private readonly GymDbContext _context;

        public TrainingEquipmentRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task CreateTrainingEquipmentAsync(TrainingEquipment trainingEquipment)
        {
            await _context.TrainingEquipment.AddAsync(trainingEquipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainingEquipmentAsync(TrainingEquipment trainingEquipment)
        {
            _context.TrainingEquipment.Remove(trainingEquipment);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TrainingEquipment>> GetAllTrainingEquipmentAsync(SearchQuery query)
        {
            return await _context.TrainingEquipment
                .Where(x => query.SearchPhrase == null || (x.SerialNr.ToLower().Contains(query.SearchPhrase.ToLower())))
                .ToListAsync();
        }

        public async Task<TrainingEquipment?> GetTrainingEquipmentByIdAsync(int id)
        {
            return await _context.TrainingEquipment.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateTrainingEquipmentAsync(TrainingEquipment trainingEquipment)
        {
            _context.TrainingEquipment.Update(trainingEquipment);
            await _context.SaveChangesAsync();
        }
    }
}
