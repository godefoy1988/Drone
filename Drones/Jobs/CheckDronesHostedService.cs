using Drones.Model.UnitOfWork.Interfaces;

namespace Drones.Jobs
{
    public class CheckDronesHostedService : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CheckDronesHostedService> _logger;
        

        public CheckDronesHostedService(IServiceProvider serviceProvider, ILogger<CheckDronesHostedService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckDronesBatteryLevels, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private void CheckDronesBatteryLevels(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                _unitOfWork.GetDroneRepo()
                    .GetAllAsync()
                    .GetAwaiter()
                    .GetResult()
                    .ToList()
                    .ForEach(d => _logger.LogInformation($"Battery Level for drone {d.Id} is {d.BatteryCapacity}"));              
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
}
