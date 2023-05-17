using Drones.Validations;

namespace Drones.ViewModel
{
    public class DroneChangeStateViewModel
    {
        public int Id { get; set; }
        [OneOfThemValidation(Values = "IDLE,LOADING,LOADED,DELIVERING,DELIVERED,RETURNING")]
        public string State { get; set; }
    }
}
