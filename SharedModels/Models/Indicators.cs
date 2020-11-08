using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class Indicators : IEntity
    {
        public int Id { get; set; }
        public int TesterUserId { get; set; }
        public int ProductId { get; set; }
        public IList<IndicatorsInfo> IndicatorsInfo { get; set; }
    }
}
