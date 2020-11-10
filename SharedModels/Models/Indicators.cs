using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class Indicators : IEntity
    {
        public int Id { get; set; }
        public virtual TesterUser TesterUser { get; set; }
        public virtual Product Product { get; set; }
        public virtual IList<IndicatorsInfo> IndicatorsInfo { get; set; }
    }
}
