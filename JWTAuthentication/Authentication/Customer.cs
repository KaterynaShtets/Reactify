using Microsoft.AspNetCore.Identity;

namespace JWTAuthentication.Authentication
{
    public class Customer: IdentityUser
    {
        public string CompanyName { get; set; }
    }
}
