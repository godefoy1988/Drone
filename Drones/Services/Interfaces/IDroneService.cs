namespace Drones.Services.Interfaces
{
    public interface IDroneService
    {
        Task<bool> Register(DroneViewModel droneView);
        Task<bool> LoadMedication(int droneId, [FromBody] List<Medication> medications);
    }
}
