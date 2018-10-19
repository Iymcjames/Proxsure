using System;

namespace Proxsure_API.Models.Users {
    public class Suscription {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Duration { get; set; }
    }
}