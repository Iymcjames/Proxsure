using System;
using Microsoft.AspNetCore.Identity;
using Proxsure_API.Models.Suscriptions;

namespace Proxsure_API.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int suscriptionId { get; set; }
        public virtual Suscription Suscription {get; set;}

        public DateTime Sus_StartDate { get; set; }

        public DateTime Sus_ExpirationDate {
            get {
                return Suscription.Duration.ToLower () == "monthly" ? Sus_StartDate.AddMonths (1) : Sus_StartDate.AddYears (1);
            }
        }
        public string profileUrl { get; set; }
    }
}