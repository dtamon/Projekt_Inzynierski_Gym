using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ICollection<TrainingEquipment>> GetAllTrainingEquipmentAsync()
        {
            return await _context.TrainingEquipment.ToListAsync();
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
