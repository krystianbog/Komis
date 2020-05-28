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
            CarViewModel model = new CarViewModel();
            model.Cars = context.Cars.Where(c=>c.IsArchived == false).ToList();
            return View(model);
        }

        public ViewResult Archivized()
        {
            CarViewModel model = new CarViewModel();
            model.Cars = context.Cars.Where(c => c.IsArchived == true).ToList();
            return View(model);
        }

        public ViewResult Edit(int editCarId)
        {
            Car model = context.Cars.FirstOrDefault(c => c.CarId == editCarId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create (Car car)
        {
            try
            {
                repository.SaveCar(car);
                return RedirectToAction("List");
            }            
            catch(Exception ex)
            {
                return RedirectToAction("List");
            }
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
    }
}