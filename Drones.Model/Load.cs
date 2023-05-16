using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model
{
    public class Load:EntityBase
    {
        public Drone Drone { get; set; }
        public List<Medication> Medications { get; set; }
        public DateTime Creation { get; set; }
    }
}
