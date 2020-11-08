
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Shared.Models
{
    public class Customer : IdentityUser<int>, IEntity
    {
        public string CompanyName { get; set; }
        public IList<Product> Products { get; set; }
    }
}
