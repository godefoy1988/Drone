namespace Drones.Services.Interfaces
{
    public interface ILoadService
    {
        Task<bool> Register(LoadViewModel loadView);
    }
}
