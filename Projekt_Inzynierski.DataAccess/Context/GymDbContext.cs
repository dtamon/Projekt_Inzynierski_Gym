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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>(eb =>
            //{
            //    eb.Property(x => x.FirstName).IsRequired().HasColumnType("varchar2(30)");
            //    eb.Property(x => x.LastName).IsRequired().HasColumnType("varchar2(50)");
            //    eb.Property(x => x.PhoneNr).IsRequired().HasColumnType("varchar2(9)");
            //    eb.Property(x => x.Email).IsRequired().HasColumnType("varchar2(50)");
            //    eb.Property(x => x.Pesel).IsRequired().HasColumnType("varchar2(11)");
            //    eb.Property(x => x.PasswordHash).IsRequired().HasColumnType("varchar2(max)");
            //    eb.Property(x => x.Role).IsRequired().HasColumnType("varchar2(max)");
            //});

            //modelBuilder.Entity<Client>(eb =>
            //{
            //    eb.Property(x => x.ContractStart).IsRequired().HasColumnType("datetime2");
            //    eb.Property(x => x.ContractEnd).HasColumnType("datetime2");
            //});

            modelBuilder.Entity<Trainer>(eb =>
            {
                eb.HasMany(x => x.CreatedGroupTrainings).WithOne(x => x.Trainer).HasForeignKey(x => x.TrainerId).OnDelete(DeleteBehavior.ClientCascade);
                eb.HasMany(x => x.GroupTrainings).WithMany(x => x.Trainers);
            });
        }
    }
}
