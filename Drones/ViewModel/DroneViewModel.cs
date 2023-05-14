using Drones.Model;

namespace Drones.ViewModel
{
    public class DroneViewModel
    {
        public string SerialNumber { get; set; }
        public string? Model { get; set; }
        public decimal WeightLimit { get; set; }
        public int BatteryCapacity { get; set; }
        public string? State { get; set; }        
    }
}
