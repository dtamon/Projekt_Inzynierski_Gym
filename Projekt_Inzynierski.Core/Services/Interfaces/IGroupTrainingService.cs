using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IGroupTrainingService
    {
        public Task CreateGroupTrainingAsync(GroupTrainingDto groupTrainingDto);
        public Task UpdateGroupTrainingAsync(GroupTrainingDto groupTrainingDto, int id);
        public Task DeleteGroupTrainingAsync(int id);
        public Task<ICollection<GroupTrainingDto>> GetAllGroupTrainingsAsync();
        public Task<GroupTrainingDto?> GetGroupTrainingByIdAsync(int id);
        public Task AddClientToGroupTrainingAsync(int id);
    }
}
