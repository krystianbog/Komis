using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Komis.Data;
using Microsoft.CodeAnalysis.Differencing;

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
            if (car.Image != null)
            {
                using (var stream = new MemoryStream())
                {
                    car.Image.CopyTo(stream);
                    car.Photo = stream.ToArray();
                }
            }            
            context.Cars.Add(car);
            context.SaveChanges();            
        }

        public void EditCar(Car editCar)
        {
            Car dbCar = context.Cars.FirstOrDefault(c => c.CarId == editCar.CarId);

            dbCar.BodyType = editCar.BodyType;
            dbCar.Color = editCar.Color;
            dbCar.EngineSize = editCar.EngineSize;
            dbCar.FuelType = editCar.FuelType;
            dbCar.Manufacturer = editCar.Manufacturer;
            dbCar.Model = editCar.Model;
            dbCar.Price = editCar.Price;
            dbCar.Transmission = editCar.Transmission;
            dbCar.YearOfProduction = editCar.YearOfProduction;

            if (editCar.Image != null)
            {
                using (var stream = new MemoryStream())
                {
                    editCar.Image.CopyTo(stream);
                    dbCar.Photo = stream.ToArray();
                }
            }
            context.SaveChanges();
        }

        public void ArchivizeCar(int carId)
        {
            if (carId != 0)
            {
                Car dbEntry = context.Cars.FirstOrDefault(c => c.CarId == carId);
                dbEntry.IsArchived = true;
            }
            context.SaveChanges();
        }

        public void UnArchivizeCar(int carId)
        {
            if (carId != 0)
            {
                Car dbEntry = context.Cars.FirstOrDefault(c => c.CarId == carId);
                dbEntry.IsArchived = false;
            }
            context.SaveChanges();
        }  
    }
}