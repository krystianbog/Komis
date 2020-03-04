using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int Manufacturer { get; set; }
        public int YearOfProduction { get; set; }
        public double Price { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string BodyType { get; set; }
        public string Color { get; set; }
        public bool IsArchived { get; set; } = false;
        public byte[] Photo { get; set; }
    }
}
