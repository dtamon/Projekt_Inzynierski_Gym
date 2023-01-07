using Microsoft.EntityFrameworkCore;
using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.DataAccess.Context
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Visit> Visit { get; set; }
        public DbSet<GroupTraining> GroupTraining { get; set; }
        public DbSet<TrainingEquipment> TrainingEquipment { get; set; }
    }
}
