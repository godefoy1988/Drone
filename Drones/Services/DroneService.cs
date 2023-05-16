﻿using AutoMapper;
using Drones.Model.Repository.Interface;
using Drones.Model.UnitOfWork.Interfaces;
using Drones.Services.Interfaces;

namespace Drones.Services;

public class DroneService : IDroneService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DroneService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Register(DroneViewModel droneView)
    {
        var droneEntity = _mapper.Map<Drone>(droneView);
        _unitOfWork.GetDroneRepo().Update(droneEntity);
        await _unitOfWork.SaveChangesAsync();
        return droneEntity.Id;
    }

    public async Task<IEnumerable<int>> GetAvailableDronesForLoading()
    {
        return (await _unitOfWork.GetDroneRepo().GetAllAsync()).ToList().Where(drone => Helpers.Helpers.IsDroneAvailableForLoad(drone.Id, _unitOfWork)).Select(drone => drone.Id);     
    }

    public async Task<int> GetBatteryLevel(int droneId)
    {
        return (await _unitOfWork.GetDroneRepo().GetById(droneId)).BatteryCapacity;
    }
}

