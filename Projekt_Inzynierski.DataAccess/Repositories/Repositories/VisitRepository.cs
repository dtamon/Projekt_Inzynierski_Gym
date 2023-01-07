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
    public class VisitRepository : IVisitRepository
    {
        private readonly GymDbContext _context;

        public VisitRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task CreateVisitAsync(Visit visit)
        {
            await _context.Visit.AddAsync(visit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVisitAsync(Visit visit)
        {
            _context.Visit.Remove(visit);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Visit>> GetAllVisitsAsync()
        {
            return await _context.Visit.Include(v => v.Client).ToListAsync();
        }

        public async Task<Visit?> GetVisitByIdAsync(int id)
        {
            return await _context.Visit.Include(v => v.Client).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateVisitAsync(Visit visit)
        {
            _context.Visit.Update(visit);
            await _context.SaveChangesAsync();
        }
    }
}
