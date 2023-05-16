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

    [HttpPost("[action]/droneId")]
    public async Task<bool> LoadMedication(int droneId, [FromBody] List<int> medicationIds)
    {
        return await _droneService.LoadMedication(droneId, medicationIds);
    }
}
