using System.ComponentModel.DataAnnotations;

namespace Drones.Model;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
}

