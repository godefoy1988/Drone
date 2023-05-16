using Drones.Model.Repository.Interface;
using Drones.Services.Interfaces;

namespace Drones.Controllers;

[ApiController]
[Route("[controller]")]
public class DroneController : ControllerBase
{
    private readonly ILogger<DroneController> _logger;    
    private readonly IDroneService _droneService;

    public DroneController(ILogger<DroneController> logger, IDroneService droneService)
    {
        _logger = logger;
        _droneService = droneService;
    }

    [HttpPost("[action]")]
    public async Task<int> Register([FromBody] DroneViewModel droneView)
    {
        return await _droneService.Register(droneView);
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<int>> GetAvailableDronesForLoading()
    {
        return await _droneService.GetAvailableDronesForLoading();
    }

    [HttpGet("[action]/{droneId}")]
    public async Task<int> GetBatteryLevel(int droneId)
    {
        return await _droneService.GetBatteryLevel(droneId);
    }
}
