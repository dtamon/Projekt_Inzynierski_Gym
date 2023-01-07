using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        public Task<ICollection<Trainer>> GetAllTrainersAsync();
        public Task CreateTrainerAsync(Trainer trainer);
        public Task<Trainer?> GetTrainerByIdAsync(int id);
        public Task UpdateTrainerAsync(Trainer trainer);
        public Task DeleteTrainerAsync(Trainer trainer);
    }
}
