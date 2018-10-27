using System;

namespace Proxsure_API.Models.SuscriptionModels
{
    public class SuscriptionDTO
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Duration { get; set; }
    }
}