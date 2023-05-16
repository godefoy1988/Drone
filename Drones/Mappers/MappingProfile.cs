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
            opt => opt.MapFrom(src => _unitOfWork.GetMedicationRepo().GetAllAsync(src.Medications).GetAwaiter().GetResult()));
        CreateMap<Load, LoadViewModel>()
            .ForMember(dst => dst.DroneId,
            opt => opt.MapFrom(src => src.Drone.Id))
            .ForMember(dst => dst.Medications,
            opt => opt.MapFrom(src => src.Medications.Select(m => m.Id)));
    }
}
