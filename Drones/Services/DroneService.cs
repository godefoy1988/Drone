using AutoMapper;
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
        await _unitOfWork.GetDroneRepo().AddAsync(droneEntity);
        await _unitOfWork.SaveChangesAsync();
        return droneEntity.Id;
    }

    public Task<bool> LoadMedication(int droneId, List<int> medicationIds)
    {
        throw new NotImplementedException();
    }
}

