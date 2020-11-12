
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    public class Customer : IdentityUser<int>, IEntity
    {
        public string CompanyName { get; set; }

        //[JsonIgnore]
        //public virtual IList<Product> Products { get; set; }
    }
}
