using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;

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

        public async Task<ICollection<GroupTraining>> GetAllGroupTrainingsAsync(SearchQuery query)
        {
            return await _context.GroupTraining.Include(x => x.Trainers).ThenInclude(x => x.Specializations).Include(x => x.Trainer).Include(x => x.Clients).Where(x => x.StartDate > DateTime.Now)
                .Where(x => query.SearchPhrase == null || (x.TrainingType.ToLower().Contains(query.SearchPhrase.ToLower())))
                .OrderBy(x => x.StartDate)
                .ToListAsync();
        }

        public async Task<GroupTraining?> GetGroupTrainingByIdAsync(int id)
        {
            return await _context.GroupTraining.Include(x => x.Trainers).ThenInclude(x => x.Specializations).Include(x => x.Trainer).Include(x => x.Clients).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateGroupTrainingAsync(GroupTraining groupTraining)
        {
            _context.GroupTraining.Update(groupTraining);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GroupTraining>> GetTrainingsByTrainerId(int id, SearchQuery query)
        {
            var trainer = await _context.Trainer.FirstOrDefaultAsync(x => x.Id == id);
            return await _context.GroupTraining.Include(x => x.Trainers).ThenInclude(x => x.Specializations).Include(x => x.Trainer).Include(x => x.Clients)
                .Where(x => (x.TrainerId == id || x.Trainers.Contains(trainer)) && (query.SearchPhrase == null || (x.TrainingType.ToLower().Contains(query.SearchPhrase.ToLower()))))
                .OrderBy(x => x.StartDate)
                .ToListAsync();
        }
        public async Task<ICollection<GroupTraining>> GetTrainingsByClientId(int id, SearchQuery query)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.Id == id);
            return await _context.GroupTraining.Include(x => x.Trainers).ThenInclude(x => x.Specializations).Include(x => x.Trainer).Include(x => x.Clients)
                .Where(x => x.Clients.Contains(client) && (query.SearchPhrase == null || (x.TrainingType.ToLower().Contains(query.SearchPhrase.ToLower()))))
                .OrderBy(x => x.StartDate)
                .ToListAsync();
        }

        //Get group training list where client is not signed up
        public async Task<ICollection<GroupTraining>> GetTrainingsWhereClientIsAbsent(int clientId, SearchQuery query)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.Id == clientId);
            return await _context.GroupTraining.Include(x => x.Trainers).ThenInclude(x => x.Specializations).Include(x => x.Trainer).Include(x => x.Clients)
                .Where(x => !x.Clients.Contains(client) && (x.MaxCLients - x.Clients.Count() > 0) && (query.SearchPhrase == null || (x.TrainingType.ToLower().Contains(query.SearchPhrase.ToLower()))))
                .OrderBy(x => x.StartDate)
                .ToListAsync();
        }
    }
}
