using AutoMapper;
using Projekt_Inzynierski.Core.DTOs;
using Projekt_Inzynierski.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski.Core
{
    public class GymMappingProfile : Profile
    {
        public GymMappingProfile()
        {

            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>()
                .ForMember(d => d.ContractMonths, o => o.MapFrom(s => s.Contract.Months))
                .ForMember(d => d.ContractMonthlyCost, o => o.MapFrom(s => s.Contract.MonthlyCost));

            CreateMap<ContractDto, Contract>();
            CreateMap<Contract, ContractDto>();

            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<SpecializationDto, Specialization>();
            CreateMap<Specialization, SpecializationDto>();

            CreateMap<Specialization, int>().ConvertUsing(source => source.Id);
            CreateMap<int, Specialization>().ForMember(d => d.Id, o => o.MapFrom(src => src));

            CreateMap<TrainerDto, Trainer>()
                .ForMember(d => d.Specializations, o => o.MapFrom(s => s.SpecializationIds.ToList()));
            CreateMap<Trainer, TrainerDto>()
                .ForMember(d => d.SpecializationIds, o => o.MapFrom(s => s.Specializations))
                .ForMember(d => d.Specializations, o => o.MapFrom(s => s.Specializations));

            CreateMap<TrainingEquipmentDto, TrainingEquipment>();
            CreateMap<TrainingEquipment, TrainingEquipmentDto>();

            CreateMap<VisitDto, Visit>();
            CreateMap<Visit, VisitDto>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Client.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.Client.LastName))
                .ForMember(d => d.PhoneNr, o => o.MapFrom(s => s.Client.PhoneNr))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Client.Email))
                .ForMember(d => d.Pesel, o => o.MapFrom(s => s.Client.Pesel));

            CreateMap<GroupTrainingDto, GroupTraining>()
                .ForMember(d => d.Clients, o => o.MapFrom(s => s.ClientIds.ToList()))
                .ForMember(d => d.Trainers, o => o.MapFrom(s => s.TrainerIds.ToList()));
            CreateMap<GroupTraining, GroupTrainingDto>()
                .ForMember(d => d.FreeSpots, o => o.MapFrom(s => s.MaxCLients - s.Clients.Count()))
                .ForMember(d => d.ClientIds, o => o.MapFrom(s => s.Clients))
                .ForMember(d => d.Clients, o => o.MapFrom(s => s.Clients))
                .ForMember(d => d.TrainerIds, o => o.MapFrom(s => s.Trainers))
                .ForMember(d => d.Trainers, o => o.MapFrom(s => s.Trainers));
        }
    }
}
