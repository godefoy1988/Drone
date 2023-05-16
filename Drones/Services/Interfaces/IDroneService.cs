namespace Drones.Services.Interfaces
{
    public interface IDroneService
    {
        Task<int> Register(DroneViewModel droneView);        
    }
}
