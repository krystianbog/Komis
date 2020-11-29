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
            context = komisContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(new CarViewModel { Cars = repository.Cars() });
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            try
            {
                repository.SaveCar(car);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("List");
            }
        }

        public ViewResult Edit(int editCarId)
        {
            return View(repository.GetCar(editCarId));
        }

        public ViewResult SearchResult(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return View(repository.SetSearchViewModel(searchString));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Car editCar)
        {
            try
            {
                repository.EditCar(editCar);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("List");
            }
        }

        public ViewResult Archivized()
        {
            return View(new CarViewModel { Cars = repository.ArchivizedCars() });
        }

        [HttpGet]
        public IActionResult Archivize(int carId)
        {
            try
            {
                repository.ArchivizeCar(carId);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        public IActionResult UnArchivize(int carId)
        {
            try
            {
                repository.UnArchivizeCar(carId);
                return RedirectToAction("Archivized");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Archivized");
            }
        }

        [HttpPost]
        public IActionResult AddMeetingPost(int modelCarId, DateTime dateOfMeeting, string clientData)
        {
            repository.AddMeeting(new Meeting { CarId = modelCarId, DateOfMeeting = dateOfMeeting, ClientData = clientData, IsArchived = false });
            return RedirectToAction("Meetings");
        }

        public ViewResult Meetings()
        {
            return View(new MeetingsViewModel { Meetings = repository.Meetings()});
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
    }
}