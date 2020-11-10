using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class Deviation
    {
        public double Pulse { get; set; }
        public double Temperature { get; set; }
        public double BloodOxygenLevel { get; set; }
        public double BloodPressure { get; set; }
    }
}
