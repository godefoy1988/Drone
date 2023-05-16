using Drones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Drones.Controllers
{
    public class LoadController : Controller
    {
        private readonly ILogger<DroneController> _logger;
        private readonly ILoadService _loadService;

        public LoadController(ILogger<DroneController> logger, ILoadService loadService)
        {
            _logger = logger;
            _loadService = loadService;
        }

        [HttpPost("[action]")]
        public async Task<bool> Register([FromBody] LoadViewModel loadView)
        {
            return await _loadService.Register(loadView);
        }
    }
}
