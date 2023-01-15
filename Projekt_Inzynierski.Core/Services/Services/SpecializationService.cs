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
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IMapper _mapper;

        public SpecializationService(ISpecializationRepository specializationRepository, IMapper mapper)
        {
            _specializationRepository = specializationRepository;
            _mapper = mapper;
        }
        public async Task CreateSpecializationAsync(SpecializationDto specializationDto)
        {
            await _specializationRepository.CreateSpecializationAsync(_mapper.Map<Specialization>(specializationDto));
        }

        public async Task DeleteSpecializationAsync(int id)
        {
            var specialization = await _specializationRepository.GetSpecializationByIdAsync(id);
            if (specialization == null)
                throw new NotFoundException("Specialization not found");

            await _specializationRepository.DeleteSpecializationAsync(specialization);
        }

        public async Task<ICollection<SpecializationDto>> GetAllSpecializationsAsync(SearchQuery query)
        {
            return _mapper.Map<ICollection<SpecializationDto>>(await _specializationRepository.GetAllSpecializationsAsync(query));
        }

        public async Task<SpecializationDto?> GetSpecializationByIdAsync(int id)
        {
            return _mapper.Map<SpecializationDto>(await _specializationRepository.GetSpecializationByIdAsync(id));
        }

        public async Task UpdateSpecializationAsync(SpecializationDto specializationDto, int id)
        {
            var specialization = await _specializationRepository.GetSpecializationByIdAsync(id);
            if (specialization == null)
                throw new NotFoundException("Specialization not found");

            specialization.SpecName = specializationDto.SpecName;

            await _specializationRepository.UpdateSpecializationAsync(_mapper.Map<Specialization>(specialization));
        }
    }
}
