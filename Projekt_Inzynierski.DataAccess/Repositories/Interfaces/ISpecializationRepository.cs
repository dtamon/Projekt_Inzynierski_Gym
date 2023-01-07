using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface ISpecializationRepository
    {
        public Task<ICollection<Specialization>> GetAllSpecializationsAsync();
        public Task CreateSpecializationAsync(Specialization specialization);
        public Task<Specialization?> GetSpecializationByIdAsync(int id);
        public Task UpdateSpecializationAsync(Specialization specialization);
        public Task DeleteSpecializationAsync(Specialization specialization);
    }
}
