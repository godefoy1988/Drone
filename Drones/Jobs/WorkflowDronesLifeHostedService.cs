using Drones.Model.UnitOfWork.Interfaces;
namespace Drones.Jobs;
using Drones.Extensions;

public class WorkflowDronesLifeHostedService : IHostedService, IDisposable
{
    private Timer? _timer = null;
    private IUnitOfWork _unitOfWork;
    private readonly IServiceProvider _serviceProvider;   

    public WorkflowDronesLifeHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;       
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(WorkFlowDronesLife, null, TimeSpan.Zero,
        TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }
    private void WorkFlowDronesLife(object? state)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            _unitOfWork.GetDroneRepo()
                .GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .ToList()
                .ForEach(drone => drone.ShitfState());
            _unitOfWork.SaveChangesAsync().GetAwaiter().GetResult();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
    public void Dispose()
    {
        _timer?.Dispose();
    }
}