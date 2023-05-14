namespace Drones.Services.Interfaces
{
    public interface IDroneService
    {
        Task<bool> Register(DroneViewModel droneView);
    }
}
