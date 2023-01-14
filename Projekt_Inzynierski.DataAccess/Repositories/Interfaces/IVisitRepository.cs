using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IVisitRepository
    {
        public Task<ICollection<Visit>> GetAllVisitsAsync(SearchQuery query);
        public Task CreateVisitAsync(Visit visit);
        public Task<Visit?> GetVisitByIdAsync(int id);
        public Task UpdateVisitAsync(Visit visit);
        public Task DeleteVisitAsync(Visit visit);
    }
}
