using Drones.Services.Interfaces;

namespace Drones.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicationController : Controller
{
    private readonly ILogger<DroneController> _logger;
    private readonly IMedicationService _medicationService;

    public MedicationController(ILogger<DroneController> logger, IMedicationService medicationService)
    {
        _logger = logger;
        _medicationService = medicationService;
    }

    [HttpPost("[action]")]
    public async Task<bool> Register([FromForm] MedicationViewModel medicationView)
    {
        return await _medicationService.Register(medicationView);
    }    
}