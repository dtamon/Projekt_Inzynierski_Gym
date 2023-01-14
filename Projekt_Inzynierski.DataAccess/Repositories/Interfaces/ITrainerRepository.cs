﻿using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        public Task<ICollection<Trainer>> GetAllTrainersAsync(SearchQuery query);
        public Task<ICollection<Trainer>> GetOtherTrainersAsync(int id);
        public Task CreateTrainerAsync(Trainer trainer);
        public Task<Trainer?> GetTrainerByIdAsync(int id);
        public Task UpdateTrainerAsync(Trainer trainer);
        public Task DeleteTrainerAsync(Trainer trainer);
    }
}
