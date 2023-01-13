using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Context;
using Projekt_Inzynierski.DataAccess.Entities;
using Projekt_Inzynierski.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ICollection<Client>> GetAllClientsAsync()
        {
            return await _context.Client.Include(c => c.Contract).Include(v => v.Visits).ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _context.Client.Include(c => c.Contract).Include(v => v.Visits).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Client.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
