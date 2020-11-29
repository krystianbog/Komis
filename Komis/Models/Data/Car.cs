using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Komis.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int YearOfProduction { get; set; }
        public double Price { get; set; }
        public double EngineSize { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string BodyType { get; set; }
        public string Color { get; set; }
        public bool IsArchived { get; set; } = false;
        public byte[] Photo { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [NotMapped]
        public int SearchHitCount { get; set; } = 0;
    }
}
