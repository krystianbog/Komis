using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class DashboardViewModel
    {
        public List<Car> cars { get; set; }
        public int allCars { get; set; }
        public int avalibleCars { get; set; }
        public int historyCars { get; set; }
        public int priceVeryLowCars { get; set; }
        public int priceLowCars { get; set; }
        public int priceMediumCars { get; set; }
        public int priceHighCars { get; set; }
        public int priceVeryHighCars { get; set; }
        public int meetings { get; set; }
    }
}
