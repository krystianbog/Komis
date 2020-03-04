using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Komis.Data;
using Komis.Models;

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
    }
}