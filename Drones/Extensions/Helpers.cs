using Drones.Model.UnitOfWork;
using Drones.Model.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;

namespace Drones.Extensions;

public static class Helpers
{
    public static async Task<bool> IsDroneAvailableForLoad(int droneId, int medicationId, IUnitOfWork unitOfWork)
    {
        var droneWeightLimit = await GetWeightDrone(droneId, unitOfWork);
        var totalWeightByDrone = await GetTotalWeightByDrone(droneId, unitOfWork);
        var totalWeightByMedications = await GetTotalWeightByMedications(medicationId, unitOfWork);
        return totalWeightByDrone + totalWeightByMedications < droneWeightLimit;
    }

    private static async Task<double> GetWeightDrone(int droneId, IUnitOfWork unitOfWork)
    {
        return (await unitOfWork.GetDroneRepo().GetById(droneId)).Weight;
    }

    private static async Task<double> GetTotalWeightByDrone(int droneId, IUnitOfWork unitOfWork)
    {
        return unitOfWork.GetLoadRepo()
            .Where(load => load.DroneId == droneId, new List<string> { "Medication" })
            .Select(load => load.Medication.Weight).Sum();
    }

    private static async Task<double> GetTotalWeightByMedications(int medicationId, IUnitOfWork unitOfWork)
    {
        return (await unitOfWork.GetMedicationRepo().GetById(medicationId)).Weight;
    }
}