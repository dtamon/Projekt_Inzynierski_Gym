using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly GymDbContext _context;

        public TrainerRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task CreateTrainerAsync(Trainer trainer)
        {
            await _context.Trainer.AddAsync(trainer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainerAsync(Trainer trainer)
        {
            _context.Trainer.Remove(trainer);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Trainer>> GetAllTrainersAsync()
        {
            return await _context.Trainer.Include(t => t.Specializations).ToListAsync();
        }

        public async Task<Trainer?> GetTrainerByIdAsync(int id)
        {
            return await _context.Trainer.Include(t => t.Specializations).Include(t => t.GroupTrainings).ThenInclude(t => t.Trainers).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateTrainerAsync(Trainer trainer)
        {
            _context.Trainer.Update(trainer);
            await _context.SaveChangesAsync();
        }
    }
}
