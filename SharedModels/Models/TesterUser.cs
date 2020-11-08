using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class TesterUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public IList<Indicators> Indicators { get; set; }
    }
}
