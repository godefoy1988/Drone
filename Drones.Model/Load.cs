using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model
{
    [Table("LOAD")]
    public class Load:EntityBase
    {        
        public int DroneId { get; set; }
        public Drone Drone { get; set; }
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
        public DateTime Creation { get; set; }
    }
}
