using Microsoft.AspNetCore.Identity;

namespace Proxsure_API.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int suscriptionId { get; set; }
        public virtual Suscription Suscription {get; set;}
        public string profileUrl { get; set; }
    }
}