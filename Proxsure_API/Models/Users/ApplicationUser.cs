using System;
using Microsoft.AspNetCore.Identity;
using Proxsure_API.Models.SuscriptionModels;
using static System.Net.Mime.MediaTypeNames;

namespace Proxsure_API.Models.Users {
    public class ApplicationUser : IdentityUser {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int SuscriptionId { get; set; }
        public virtual Suscription Suscription { get; set; }

        public DateTime SuscriptionStartDate { get; set; }

        public DateTime SuscriptionExpiryDate {get;set; }
    }
}