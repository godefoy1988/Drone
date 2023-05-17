namespace Drones.Extensions
{
    public static class DroneExtension
    {
        public static Drone ShitfState(this Drone drone)
        {
            var droneStates = new List<string> { "IDLE","LOADING","LOADED","DELIVERING","DELIVERED","RETURNING" };
            if (drone.State == "LOADED")
            {
                var currentIndex = droneStates.IndexOf(drone.State);
                var nextIndex = (currentIndex + 1) % droneStates.Count;
                drone.State = droneStates[nextIndex];
                drone.BatteryCapacity--;                
            }
            return drone;
        }
    }
}
