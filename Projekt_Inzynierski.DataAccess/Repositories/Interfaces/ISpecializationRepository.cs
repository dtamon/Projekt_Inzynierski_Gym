using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface ISpecializationRepository
    {
        public Task<ICollection<Specialization>> GetAllSpecializationsAsync(SearchQuery query);
        public Task CreateSpecializationAsync(Specialization specialization);
        public Task<Specialization?> GetSpecializationByIdAsync(int id);
        public Task UpdateSpecializationAsync(Specialization specialization);
        public Task DeleteSpecializationAsync(Specialization specialization);
    }
}
