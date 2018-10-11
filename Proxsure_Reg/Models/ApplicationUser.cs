using System;
using Microsoft.AspNetCore.Identity;

namespace Proxsure_Reg.Models {
    public class ApplicationUser : IdentityUser {
        // Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
        public int SuscriptionId { get; set; }
        public Suscription Suscription { get; set; }

        public DateTime SuscriptionStartDate { get; set; }

        public DateTime SuscriptionExpiryDate { get; set; }
    }
}