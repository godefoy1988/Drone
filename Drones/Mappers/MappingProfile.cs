using AutoMapper;
using Drones.Model.UnitOfWork.Interfaces;
using System;
using System.Globalization;

namespace Drones.Mappers;

public class MappingProfile : Profile
{
    private readonly IUnitOfWork _unitOfWork;
    public MappingProfile(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        CreateMap<DroneViewModel, Drone>();
        CreateMap<MedicationViewModel, Medication>();
        CreateMap<LoadViewModel, Load>()
            .ForMember(dst => dst.Drone,
            opt => opt.MapFrom(src => _unitOfWork.GetDroneRepo().GetById(src.DroneId).GetAwaiter().GetResult()))
            .ForMember(dst => dst.Medications,
            opt => opt.MapFrom(src => _unitOfWork.GetLoadRepo().GetAll(src.Medications).GetAwaiter().GetResult()));
    }
}
