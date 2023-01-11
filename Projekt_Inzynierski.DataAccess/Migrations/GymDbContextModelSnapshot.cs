﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_Inzynierski.DataAccess.Context;

#nullable disable

namespace ProjektInzynierski.DataAccess.Migrations
{
    [DbContext(typeof(GymDbContext))]
    partial class GymDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientGroupTraining", b =>
                {
                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<int>("GroupTrainingsId")
                        .HasColumnType("int");

                    b.HasKey("ClientsId", "GroupTrainingsId");

                    b.HasIndex("GroupTrainingsId");

                    b.ToTable("ClientGroupTraining");
                });

            modelBuilder.Entity("GroupTrainingTrainer", b =>
                {
                    b.Property<int>("GroupTrainingsId")
                        .HasColumnType("int");

                    b.Property<int>("TrainersId")
                        .HasColumnType("int");

                    b.HasKey("GroupTrainingsId", "TrainersId");

                    b.HasIndex("TrainersId");

                    b.ToTable("GroupTrainingTrainer");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MonthlyCost")
                        .HasColumnType("int");

                    b.Property<int>("Months")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.GroupTraining", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxCLients")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GroupTraining");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SpecName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.TrainingEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SerialNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TechnicalState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TrainingEquipment");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Visit");
                });

            modelBuilder.Entity("SpecializationTrainer", b =>
                {
                    b.Property<int>("SpecializationsId")
                        .HasColumnType("int");

                    b.Property<int>("TrainersId")
                        .HasColumnType("int");

                    b.HasKey("SpecializationsId", "TrainersId");

                    b.HasIndex("TrainersId");

                    b.ToTable("SpecializationTrainer");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Client", b =>
                {
                    b.HasBaseType("Projekt_Inzynierski.DataAccess.Entities.Person");

                    b.Property<DateTime>("ContractEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ContractStart")
                        .HasColumnType("datetime2");

                    b.HasIndex("ContractId");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Employee", b =>
                {
                    b.HasBaseType("Projekt_Inzynierski.DataAccess.Entities.Person");

                    b.Property<DateTime>("EmployedFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EmployedTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Trainer", b =>
                {
                    b.HasBaseType("Projekt_Inzynierski.DataAccess.Entities.Employee");

                    b.HasDiscriminator().HasValue("Trainer");
                });

            modelBuilder.Entity("ClientGroupTraining", b =>
                {
                    b.HasOne("Projekt_Inzynierski.DataAccess.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Inzynierski.DataAccess.Entities.GroupTraining", null)
                        .WithMany()
                        .HasForeignKey("GroupTrainingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupTrainingTrainer", b =>
                {
                    b.HasOne("Projekt_Inzynierski.DataAccess.Entities.GroupTraining", null)
                        .WithMany()
                        .HasForeignKey("GroupTrainingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Inzynierski.DataAccess.Entities.Trainer", null)
                        .WithMany()
                        .HasForeignKey("TrainersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Visit", b =>
                {
                    b.HasOne("Projekt_Inzynierski.DataAccess.Entities.Client", "Client")
                        .WithMany("Visits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SpecializationTrainer", b =>
                {
                    b.HasOne("Projekt_Inzynierski.DataAccess.Entities.Specialization", null)
                        .WithMany()
                        .HasForeignKey("SpecializationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Inzynierski.DataAccess.Entities.Trainer", null)
                        .WithMany()
                        .HasForeignKey("TrainersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Client", b =>
                {
                    b.HasOne("Projekt_Inzynierski.DataAccess.Entities.Contract", "Contract")
                        .WithMany("Clients")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Contract", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Projekt_Inzynierski.DataAccess.Entities.Client", b =>
                {
                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
