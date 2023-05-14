namespace Drones.Model;

[Table("MEDICATION")]
public class Medication : EntityBase
{
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public string Code { get; set; }
    public string PathImage { get; set; }
}

