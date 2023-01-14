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

namespace Projekt_Inzynierski.DataAccess.Repositories.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly GymDbContext _context;

        public SpecializationRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task CreateSpecializationAsync(Specialization specialization)
        {
            await _context.Specialization.AddAsync(specialization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpecializationAsync(Specialization specialization)
        {
            _context.Specialization.Remove(specialization);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Specialization>> GetAllSpecializationsAsync(SearchQuery query)
        {
            return await _context.Specialization
                .Where(x => query.SearchPhrase == null || (x.SpecName.ToLower().Contains(query.SearchPhrase.ToLower())))
                .ToListAsync();
        }

        public async Task<Specialization?> GetSpecializationByIdAsync(int id)
        {
            return await _context.Specialization.Include(t => t.Trainers).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateSpecializationAsync(Specialization specialization)
        {
            _context.Specialization.Update(specialization);
            await _context.SaveChangesAsync();
        }
    }
}
