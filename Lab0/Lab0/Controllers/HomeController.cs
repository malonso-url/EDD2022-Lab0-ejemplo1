using Lab0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static LinkedList<Automovil> automovils = new LinkedList<Automovil>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		
		[HttpPost]
		public IActionResult HelloWorld(String firstname, String lastname){
            ViewBag.firstname = firstname;
            ViewBag.lastname = lastname;
            ViewBag.id = (new Random(DateTime.Now.Millisecond)).Next(1000, 9999);
            return View();
		}

        public IActionResult FormCar()
        {
            return View();
        }

        public IActionResult SaveCar(String Placa, String Marca, int Modelo) {
            Automovil nuevoAuto = new Automovil(Placa, Marca, Modelo);
            automovils.AddLast(nuevoAuto);
            ViewBag.savecarsuccess = "Auto con placa: " + Placa + " Guardado exitosamente ";
            return View();
        }

        public IActionResult ShowCar()
        {
            ViewData["autos"] = automovils;
            return View();
        }
    }
}
