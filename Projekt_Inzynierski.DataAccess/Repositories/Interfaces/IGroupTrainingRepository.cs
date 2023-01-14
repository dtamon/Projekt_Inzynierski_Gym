using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IGroupTrainingRepository
    {
        public Task<ICollection<GroupTraining>> GetAllGroupTrainingsAsync(SearchQuery query);
        public Task CreateGroupTrainingAsync(GroupTraining groupTraining);
        public Task<GroupTraining?> GetGroupTrainingByIdAsync(int id);
        public Task UpdateGroupTrainingAsync(GroupTraining groupTraining);
        public Task DeleteGroupTrainingAsync(GroupTraining groupTraining);
        public Task<ICollection<GroupTraining>> GetTrainingsByTrainerId(int id, SearchQuery query);
        public Task<ICollection<GroupTraining>> GetTrainingsByClientId(int id, SearchQuery query);
        public Task<ICollection<GroupTraining>> GetTrainingsWhereClientIsAbsent(int clientId, SearchQuery query);
    }
}
