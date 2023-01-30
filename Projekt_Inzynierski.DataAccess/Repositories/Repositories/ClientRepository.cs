using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Queries;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;

namespace Projekt_Inzynierski.DataAccess.Repositories.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly GymDbContext _context;
        public ClientRepository(GymDbContext context)
        {
            _context = context;
        }
        public async Task CreateClientAsync(Client client)
        {
            await _context.Client.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(Client client)
        {
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Client>> GetAllClientsAsync(SearchQuery query)
        {
            return await _context.Client.Include(c => c.Contract).Include(v => v.Visits)
                .Where(x => query.SearchPhrase == null || (x.FirstName.ToLower().Contains(query.SearchPhrase.ToLower())
                                                        || x.LastName.ToLower().Contains(query.SearchPhrase.ToLower())
                                                        || x.Pesel.ToLower().Contains(query.SearchPhrase.ToLower())))
                .ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _context.Client.Include(c => c.Contract).Include(v => v.Visits.OrderByDescending(x => x.VisitDate)).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Client.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
