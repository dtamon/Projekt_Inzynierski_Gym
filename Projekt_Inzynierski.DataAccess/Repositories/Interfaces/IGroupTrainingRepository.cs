using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IGroupTrainingRepository
    {
        public Task<ICollection<GroupTraining>> GetAllGroupTrainingsAsync();
        public Task CreateGroupTrainingAsync(GroupTraining groupTraining);
        public Task<GroupTraining?> GetGroupTrainingByIdAsync(int id);
        public Task UpdateGroupTrainingAsync(GroupTraining groupTraining);
        public Task DeleteGroupTrainingAsync(GroupTraining groupTraining);
    }
}
