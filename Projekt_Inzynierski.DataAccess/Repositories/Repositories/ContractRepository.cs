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
    public class ContractRepository : IContractRepository
    {
        private readonly GymDbContext _context;

        public ContractRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task CreateContractAsync(Contract contract)
        {
            await _context.Contract.AddAsync(contract);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContractAsync(Contract contract)
        {
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Contract>> GetAllContractsAsync()
        {
            return await _context.Contract.ToListAsync();
        }

        public async Task<Contract?> GetContractByIdAsync(int id)
        {
            return await _context.Contract.Include(c => c.Clients).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateContractAsync(Contract contract)
        {
            _context.Contract.Update(contract);
            await _context.SaveChangesAsync();
        }
    }
}
