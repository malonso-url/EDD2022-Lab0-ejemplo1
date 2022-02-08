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
        public static LinkedList<Automovil> automovils = new LinkedList<Automovil>();

        private readonly ILogger<HomeController> _logger;

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
        public IActionResult HelloWorld(String firstname, String lastname) {
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

        [HttpGet]
        public IActionResult ShowCar(int lower)
        {
            

            if (lower == 1)
            {
                LinkedList<Automovil> newList = new LinkedList<Automovil>();
                for (int i = 0; i < automovils.Count; i++)
                {
                    String placa = automovils.ToArray<Automovil>()[i].Placa.ToLower();
                    String marcaLower = automovils.ToArray<Automovil>()[i].Marca.ToLower();
                    int modelo = automovils.ToArray<Automovil>()[i].Modelo;
                    newList.AddLast(new Automovil(placa, marcaLower, modelo));
                }
                ViewData["autos"] = newList;
            }
            else {
                ViewData["autos"] = automovils;
            }

            return View();
        }


    }
}
