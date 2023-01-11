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
    public class GroupTrainingRepository : IGroupTrainingRepository
    {
        private readonly GymDbContext _context;

        public GroupTrainingRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task CreateGroupTrainingAsync(GroupTraining groupTraining)
        {
            await _context.GroupTraining.AddAsync(groupTraining);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupTrainingAsync(GroupTraining groupTraining)
        {
            _context.GroupTraining.Remove(groupTraining);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GroupTraining>> GetAllGroupTrainingsAsync()
        {
            return await _context.GroupTraining.Include(x => x.Trainers).ThenInclude(x => x.Specializations).Include(x => x.Clients).ToListAsync();
        }

        public async Task<GroupTraining?> GetGroupTrainingByIdAsync(int id)
        {
            return await _context.GroupTraining.Include(x => x.Trainers).ThenInclude(x => x.Specializations).Include(x => x.Clients).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateGroupTrainingAsync(GroupTraining groupTraining)
        {
            _context.GroupTraining.Update(groupTraining);
            await _context.SaveChangesAsync();
        }
    }
}
