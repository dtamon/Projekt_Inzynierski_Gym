using AutoMapper;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.Core.Exceptions;
using Projekt_Inzynierski.Core.Services.Interfaces;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;

        public VisitService(IVisitRepository visitRepository, IMapper mapper)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public async Task CreateVisitAsync(VisitDto visitDto)
        {
            visitDto.VisitDate = DateTime.Now;
            await _visitRepository.CreateVisitAsync(_mapper.Map<Visit>(visitDto));
        }

        public async Task DeleteVisitAsync(int id)
        {
            var visit = await _visitRepository.GetVisitByIdAsync(id);
            if (visit == null)
                throw new NotFoundException("Visit not found");

            await _visitRepository.DeleteVisitAsync(visit);
        }

        public async Task<ICollection<VisitDto>> GetAllVisitsAsync(SearchQuery query)
        {
            return _mapper.Map<ICollection<VisitDto>>(await _visitRepository.GetAllVisitsAsync(query));
        }

        public async Task<VisitDto?> GetVisitByIdAsync(int id)
        {
            return _mapper.Map<VisitDto>(await _visitRepository.GetVisitByIdAsync(id));
        }

        public async Task UpdateVisitAsync(VisitDto visitDto, int id)
        {
            var visit = await _visitRepository.GetVisitByIdAsync(id);
            if (visit == null)
                throw new NotFoundException("Visit not found");

            visit.VisitDate = visitDto.VisitDate;

            await _visitRepository.UpdateVisitAsync(visit);
        }
    }
}
