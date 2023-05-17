using Drones.Model;
using Drones.Validations;
using System.ComponentModel.DataAnnotations;

namespace Drones.ViewModel
{
    public class DroneViewModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string SerialNumber { get; set; }
        [OneOfThemValidation(Values = "Lightweight,Middleweight,Cruiserweight,Heavyweight")]
        public string Model { get; set; }
        [Range(1, 500)]
        public double Weight { get; set; }
        public int BatteryCapacity { get; set; }
        [OneOfThemValidation(Values = "IDLE,LOADING,LOADED,DELIVERING,DELIVERED,RETURNING")]
        public string State { get; set; }
    }
}
