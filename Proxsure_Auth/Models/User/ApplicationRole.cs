using Microsoft.AspNetCore.Identity;

namespace Proxsure_Auth.Models.User {
    public class ApplicationRole : IdentityRole {
        public string Admin { get; set; }
        public string Mentee { get; set; }
        public string Mentor { get; set; }
    }
}