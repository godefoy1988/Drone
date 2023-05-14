namespace Drones.Model;

[Table("DRONE")]
public class Drone : EntityBase
{
    public string SerialNumber { get; set; }
    public string Model { get; set; }
    public decimal WeightLimit { get; set; }
    public int BatteryCapacity { get; set; }
    public string State { get; set; }
    public List<Medication> Medication { get; set; }
}
