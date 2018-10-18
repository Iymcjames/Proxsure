using System;

namespace Proxsure_API.Models.Users {
    public class Suscription {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Duration { get; set; }
        public DateTime SuscriptionStartDate { get; set; }

        public DateTime SuscriptionExpirationDate {
            get {
                return Duration.ToLower () == "monthly" ? SuscriptionExpirationDate.AddMonths (1) : SuscriptionExpirationDate.AddYears (1);
            }
        }
    }
}