using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IGroupTrainingService
    {
        public Task CreateGroupTrainingAsync(GroupTrainingDto groupTrainingDto);
        public Task UpdateGroupTrainingAsync(GroupTrainingDto groupTrainingDto, int id);
        public Task DeleteGroupTrainingAsync(int id);
        public Task<ICollection<GroupTrainingDto>> GetAllGroupTrainingsAsync(SearchQuery query);
        public Task<GroupTrainingDto?> GetGroupTrainingByIdAsync(int id);
        public Task SignUpForTraining(int id);
        public Task SignOutOfTraining(int id);
        public Task<ICollection<GroupTrainingDto>> GetGroupTrainingsByUserId(SearchQuery query);
        public Task<ICollection<GroupTrainingDto>> GetTrainingsWhereClientIsAbsent(SearchQuery query);
    }
}
