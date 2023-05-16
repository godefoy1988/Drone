namespace Drones.Services.Interfaces
{
    public interface ILoadService
    {
        Task<int> Register(LoadViewModel loadView);
    }
}
