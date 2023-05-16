namespace Drones.Services.Interfaces
{
    public interface ILoadService
    {
        Task<int> Register(LoadViewModel loadView);
        Task<IEnumerable<LoadViewModel>> GetLoadedMedicationsByDrone(int droneId);
    }
}
