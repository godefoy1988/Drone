using AutoMapper;
using Drones.Model.UnitOfWork.Interfaces;
using System;
using System.Globalization;

namespace Drones.Mappers;

public class MappingProfile : Profile
{    
    public MappingProfile()
    {
        CreateMap<DroneViewModel, Drone>().ReverseMap();
        CreateMap<MedicationViewModel, Medication>();
        CreateMap<LoadViewModel, Load>().ReverseMap();        
    }
}
