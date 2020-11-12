using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Product : IEntity
    {
        public int Id { get; set;  }
        public string Name { get; set;  }
        public int CustomerId { get; set;  }
        //public virtual IList<Indicators> Indicators { get; set; }
    }
}
