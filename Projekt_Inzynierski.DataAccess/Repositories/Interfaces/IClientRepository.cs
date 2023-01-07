using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Repositories.Interfaces
{
    public interface IClientRepository
    {
        public Task CreateClientAsync(Client client);
        public Task DeleteClientAsync(Client client);
        public Task<ICollection<Client>> GetAllClientsAsync();
        public Task<Client?> GetClientByIdAsync(int id);
        public Task UpdateClientAsync(Client client);

    }
}
