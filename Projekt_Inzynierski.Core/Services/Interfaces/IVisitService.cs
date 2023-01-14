using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface IVisitService
    {
        public Task CreateVisitAsync(VisitDto visitDto);
        public Task UpdateVisitAsync(VisitDto visitDto, int id);
        public Task DeleteVisitAsync(int id);
        Task<ICollection<VisitDto>> GetAllVisitsAsync(SearchQuery query);
        Task<VisitDto?> GetVisitByIdAsync(int id);
    }
}
