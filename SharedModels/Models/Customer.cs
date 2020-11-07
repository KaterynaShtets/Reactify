
using Microsoft.AspNetCore.Identity;

namespace Shared.Models
{
    public class Customer : IdentityUser
    {
        public string CompanyName { get; set; }
    }
}
