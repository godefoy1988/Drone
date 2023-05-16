namespace Drones.Services.Interfaces
{
    public interface IDroneService
    {
        Task<int> Register(DroneViewModel droneView);
        Task<bool> LoadMedication(int droneId, List<int> medicationIds);
    }
}
