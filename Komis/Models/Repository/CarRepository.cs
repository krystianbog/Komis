using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Data;

namespace Komis.Models
{
    public class CarRepository
    {
        private KomisContext context;

        public CarRepository(KomisContext ctx)
        {
            context = ctx;
        }
       public void SaveCar(Car car)
        {
                context.Cars.Add(car);
                context.SaveChanges();
        }
    }
}
