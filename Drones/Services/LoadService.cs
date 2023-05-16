using AutoMapper;
using Drones.Model.Repository.Interface;
using Drones.Model.UnitOfWork.Interfaces;
using Drones.Services.Interfaces;
using System.Linq;
using Drones.Helpers;

namespace Drones.Services;

public class LoadService : ILoadService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LoadService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<int> Register(LoadViewModel loadView)
    {
        var loadEntity = _mapper.Map<Load>(loadView);
        loadEntity.Creation = DateTime.Now;

        if (await Helpers.Helpers.IsDroneAvailableForThisLoad(loadView.DroneId, loadView.MedicationId, _unitOfWork))
        {
            _unitOfWork.GetLoadRepo().Update(loadEntity);
            await _unitOfWork.SaveChangesAsync();
            return loadEntity.Id;
        }
        return -1;
    }

    private async Task<double> GetWeightDrone(int droneId)
    {
        return (await _unitOfWork.GetDroneRepo().GetById(droneId)).Weight;
    }

    private async Task<double> GetTotalWeightByDrone(int droneId)
    {
        return _unitOfWork.GetLoadRepo()
            .Where(load => load.DroneId == droneId, new List<string> { "Medication" })
            .Select(load => load.Medication.Weight).Sum();
    }

    private async Task<double> GetTotalWeightByMedications(int medicationId)
    {
        return (await _unitOfWork.GetMedicationRepo().GetById(medicationId)).Weight;
    }

    public async Task<IEnumerable<LoadViewModel>> GetLoadedMedicationsByDrone(int droneId)
    {
        var load = _unitOfWork.GetLoadRepo().Where(load => load.DroneId == droneId).ToList();
        return load.Select(l => _mapper.Map<LoadViewModel>(l));
    }
}

