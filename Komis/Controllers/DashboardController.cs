using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Data;
using Komis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private KomisContext context;

        public DashboardController (KomisContext komisContext)
        {
            context = komisContext;
        }
        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            model.cars = context.Cars.ToList();
            model.allCars = model.cars.Count();
            model.avalibleCars = model.cars.Where(x => x.IsArchived == false).Count();
            model.historyCars = model.cars.Where(x => x.IsArchived == true).Count();
            model.priceVeryLowCars = model.cars.Where(x => x.Price > 1 && x.Price < 10000).Count();
            model.priceLowCars = model.cars.Where(x => x.Price >= 10000 && x.Price < 25000).Count();
            model.priceMediumCars = model.cars.Where(x => x.Price >= 25000 && x.Price < 50000).Count();
            model.priceHighCars = model.cars.Where(x => x.Price >= 50000 && x.Price < 100000).Count();
            model.priceVeryHighCars = model.cars.Where(x => x.Price >= 100000).Count();
            return View(model);
        }
    }
}