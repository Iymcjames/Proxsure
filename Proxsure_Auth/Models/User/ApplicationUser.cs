using System;
using Microsoft.AspNetCore.Identity;
using Proxsure_Auth.Models.SuscriptionModels;

namespace Proxsure_Auth.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int SuscriptionId { get; set; }
        public virtual Suscription Suscription { get; set; }

        public DateTime SuscriptionStartDate { get; set; }

        public DateTime SuscriptionExpiryDate {get;set; }
    }
}