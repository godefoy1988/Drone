using AutoMapper;
using System;
using System.Globalization;

namespace Drones.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DroneViewModel, Drone>();
            CreateMap<MedicationViewModel, Medication>();
        }
    }
}
