using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Komis.Data;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Komis.Models
{
    public class CarRepository
    {
        private KomisContext context;

        public CarRepository(KomisContext ctx)
        {
            context = ctx;
        }

        public void AddCar(Car car)
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

        public Car GetCar (int carId)
        {
            return context.Cars.FirstOrDefault(c => c.CarId == carId);
        }

        public SearchViewModel SearchResult(string searchString)
        {
            string originalSearchString = searchString;
            List<string> searchList = searchString.ToLower().Split(" ").ToList();
            searchList.RemoveAll(x => x.Equals(string.Empty));
            List<Car> searchResult = SearchEngine(searchList);

            return new SearchViewModel { SearchString = originalSearchString, SearchResult = searchResult, SearchResultCounter = searchResult.Count() };
        }

        public List<Car> SearchEngine(List<string> searchList)
        {
            List<Car> searchResult = new List<Car>();
            List<Car> allCars = context.Cars.Where(car => car.IsArchived == false).ToList();
            foreach (var car in allCars)
            {
                string carDescription = $@"{car.Manufacturer} {car.Model} {car.BodyType} {car.YearOfProduction}".ToLower();
                
                foreach (var word in searchList)
                {
                    if (carDescription.Contains(word))
                    {
                        car.SearchHitCount++;
                    }
                }
                if (car.SearchHitCount == searchList.Count())
                {
                    searchResult.Add(car);
                }
            }
            return searchResult;
        }

        public void AddMeeting(Meeting meeting)
        {
            meeting.DateOfMeeting = meeting.DateOfMeeting.Date;
            context.Meetings.Add(meeting);
            context.SaveChanges();
        }

        public List<Meeting> Meetings()
        {
            return context.Meetings.Include(x => x.Car).Where(x => x.IsArchived == false).ToList();
        }

        public List<Car> ArchivizedCars()
        {
            return context.Cars.Where(x => x.IsArchived == true).ToList();
        }

        public List<Car> Cars()
        {
            return context.Cars.Where(x => x.IsArchived == false).ToList();
        }

        public void ArchivizeMeeting(int meetingId)
        {
            if (meetingId != 0)
            {
                Meeting dbEntry = context.Meetings.FirstOrDefault(x => x.MeetingId == meetingId);
                dbEntry.IsArchived = true;
            }
            context.SaveChanges();
        }
    }
}