﻿using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core.Services.Interfaces
{
    public interface ITrainerService
    {
        public Task CreateTrainerAsync(TrainerAccountDto trainerDto);
        public Task UpdateTrainerAsync(TrainerViewDto trainerDto, int id);
        public Task DeleteTrainerAsync(int id);
        public Task<ICollection<TrainerViewDto>> GetAllTrainersAsync(SearchQuery query);
        public Task<ICollection<TrainerViewDto>> GetOtherTrainersAsync();
        public Task<TrainerViewDto?> GetTrainerByIdAsync(int id);

    }
}
