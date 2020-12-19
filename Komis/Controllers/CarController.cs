using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Komis.Data;
using Komis.Models;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Komis.Controllers
{
    public class CarController : Controller
    {
        private KomisContext context;
        private CarRepository repository;

        public CarController(CarRepository repo, KomisContext komisContext)
        {
            this.repository = repo;
            this.context = komisContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Cars()
        {
            return View(new CarViewModel { Cars = repository.Cars() });
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            try
            {
                repository.AddCar(car);
                return RedirectToAction("Cars");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Cars");
            }
        }

        public ViewResult EditCar(int editCarId)
        {
            return View(repository.GetCar(editCarId));
        }

        [HttpPost]
        public IActionResult EditCar(Car editCar)
        {
            try
            {
                repository.EditCar(editCar);
                return RedirectToAction("Cars");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Cars");
            }
        }

        public ViewResult ArchivizedCars()
        {
            return View(new CarViewModel { Cars = repository.ArchivizedCars() });
        }

        [HttpGet]
        public IActionResult ArchivizeCar(int carId)
        {
            try
            {
                repository.ArchivizeCar(carId);
                return RedirectToAction("Cars");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Cars");
            }
        }

        [HttpGet]
        public IActionResult UnArchivizeCar(int carId)
        {
            try
            {
                repository.UnArchivizeCar(carId);
                return RedirectToAction("ArchivizedCars");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ArchivizedCars");
            }
        }

        public ViewResult Meetings()
        {
            return View(new MeetingsViewModel { Meetings = repository.Meetings() });
        }

        [HttpPost]
        public IActionResult AddMeeting(int modelCarId, DateTime dateOfMeeting, string clientData)
        {
            repository.AddMeeting(new Meeting { CarId = modelCarId, DateOfMeeting = dateOfMeeting, ClientData = clientData, IsArchived = false });
            return RedirectToAction("Meetings");
        }

        [HttpGet]
        public IActionResult ArchivizeMeeting(int meetingId)
        {
            try
            {
                repository.ArchivizeMeeting(meetingId);
                return RedirectToAction("Meetings");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Meetings");
            }
        }

        public ViewResult SearchResult(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return View(repository.SearchResult(searchString));
            }
            return View();
        }
    }
}