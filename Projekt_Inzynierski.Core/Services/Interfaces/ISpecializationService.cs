using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface ISpecializationService
    {
        public Task CreateSpecializationAsync(SpecializationDto specializationDto);
        public Task UpdateSpecializationAsync(SpecializationDto specializationDto, int id);
        public Task DeleteSpecializationAsync(int id);
        public Task<ICollection<SpecializationDto>> GetAllSpecializationsAsync(SearchQuery query);
        public Task<SpecializationDto?> GetSpecializationByIdAsync(int id);
    }
}
