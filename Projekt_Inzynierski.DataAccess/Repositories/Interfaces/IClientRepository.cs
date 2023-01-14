using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
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
        public Task<ICollection<Client>> GetAllClientsAsync(SearchQuery query);
        public Task<Client?> GetClientByIdAsync(int id);
        public Task UpdateClientAsync(Client client);

    }
}
