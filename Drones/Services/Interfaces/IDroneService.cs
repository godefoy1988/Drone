namespace Drones.Services.Interfaces;

public interface IDroneService
{
    Task<int> Register(DroneViewModel droneView);
    Task<IEnumerable<int>> GetAvailableDronesForLoading();
    Task<int> GetBatteryLevel(int droneId);
    Task<DroneViewModel> ChangeState(DroneChangeStateViewModel droneChangeState);
}