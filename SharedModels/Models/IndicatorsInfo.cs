using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class IndicatorsInfo : IEntity
    {
        public int Id { get; set; }
        public int IndicatorsId { get; set; }
        public DateTime Time { get; set; }
        public int Pulse { get; set; }
        public double Temperature { get; set; }
        public int BloodOxygenLevel { get; set; }
        public int BloodPressure { get; set; }
    }
}
