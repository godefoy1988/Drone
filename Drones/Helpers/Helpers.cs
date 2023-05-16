using Drones.Model.UnitOfWork;
using Drones.Model.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;

namespace Drones.Helpers;

public static class Helpers
{
    public static bool IsDroneAvailableForLoad(int droneId, IUnitOfWork unitOfWork)
    {
        var droneWeightLimit = GetWeightDrone(droneId, unitOfWork).GetAwaiter().GetResult();
        var totalWeightByDrone = GetTotalWeightByDrone(droneId, unitOfWork).GetAwaiter().GetResult();
        return droneWeightLimit > totalWeightByDrone;
    }
    public static async Task<bool> IsDroneAvailableForThisLoad(int droneId, int medicationId, IUnitOfWork unitOfWork)
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