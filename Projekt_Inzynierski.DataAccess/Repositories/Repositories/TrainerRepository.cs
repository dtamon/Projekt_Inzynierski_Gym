using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
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

        public async Task<ICollection<Trainer>> GetAllTrainersAsync(SearchQuery query)
        {
            return await _context.Trainer.Include(t => t.Specializations)
                .Where(x => query.SearchPhrase == null || (x.FirstName.ToLower().Contains(query.SearchPhrase.ToLower())
                                                        || x.LastName.ToLower().Contains(query.SearchPhrase.ToLower())
                                                        //|| x.Specializations.ToList().ForEach(x => x.SpecName.ToLower().Contains(query.SearchPhrase.ToLower()))
                                                        || x.Pesel.ToLower().Contains(query.SearchPhrase.ToLower())))
                .ToListAsync();
        }

        public async Task<ICollection<Trainer>> GetOtherTrainersAsync(int id)
        {
            return await _context.Trainer.Include(t => t.Specializations).Where(t => t.Id != id).ToListAsync();
        }

        public async Task<Trainer?> GetTrainerByIdAsync(int id)
        {
            return await _context.Trainer.Include(t => t.Specializations).Include(t => t.GroupTrainings).ThenInclude(t => t.Trainers).Include(t => t.CreatedGroupTrainings).ThenInclude(t => t.Trainers).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateTrainerAsync(Trainer trainer)
        {
            _context.Trainer.Update(trainer);
            await _context.SaveChangesAsync();
        }
    }
}
