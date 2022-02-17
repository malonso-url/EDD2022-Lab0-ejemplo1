using Lab0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.LinearStructures;

namespace Lab0.Controllers
{
    public class HomeController : Controller
    {
        public static LinkedList<Automovil> automovils = new LinkedList<Automovil>();
        public static CustomLinkedList<Automovil> listAutomovil = new CustomLinkedList<Automovil>();

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
            automovils.AddLast(nuevoAuto); //Added to a normal linked list
            listAutomovil.InsertAtEnd(nuevoAuto); //Added to list 
            ViewBag.savecarsuccess = "Auto con placa: " + Placa + " Guardado exitosamente ";
            return View();
        }

        [HttpGet]
        public IActionResult ShowCar(int lower)
        {


            if (lower == 1)
            {
                /* LinkedList<Automovil> newList = new LinkedList<Automovil>();
                 for (int i = 0; i < automovils.Count; i++)
                 {
                     String placa = automovils.ToArray<Automovil>()[i].Placa.ToLower();
                     String marcaLower = automovils.ToArray<Automovil>()[i].Marca.ToLower();
                     int modelo = automovils.ToArray<Automovil>()[i].Modelo;
                     newList.AddLast(new Automovil(placa, marcaLower, modelo));
                 }
                 ViewData["autos"] = newList;*/
                CustomLinkedList<Automovil> newList = new CustomLinkedList<Automovil>();
                for (int i = 0; i < automovils.Count; i++)
                {
                    String placa = automovils.ToArray<Automovil>()[i].Placa.ToLower();
                    String marcaLower = automovils.ToArray<Automovil>()[i].Marca.ToLower();
                    int modelo = automovils.ToArray<Automovil>()[i].Modelo;
                    newList.InsertAtEnd(new Automovil(placa, marcaLower, modelo));
                }
                ViewData["autos"] = newList;
            }
            else if (lower == 2) //sending the custom list
            {
                ViewData["autos"] = listAutomovil;
            }
            else if (lower == 3)
            {
                listAutomovil.Sort(new Lab0.Models.Comparadores.CompareAutoByPlacaAsc());
                ViewData["autos"] = listAutomovil;
            }
            else if (lower == 4) 
            {
                listAutomovil.SortUsingMethods(SortUsingSelectionSort);
                ViewData["autos"] = listAutomovil;
            }
            else
            {
                ViewData["autos"] = listAutomovil;
            }

            return View();
        }

        private void SortUsingSelectionSort () {
            Lab0.Models.Comparadores.CompareAutoByModeloAsc myComparer = new Lab0.Models.Comparadores.CompareAutoByModeloAsc();
            int min;

            for (int index = 0; index < listAutomovil.Count() - 1; index++)
            {
                min = index;
                for (int scan = index + 1; scan < listAutomovil.Count(); scan++)
                {
                    //if (myCompare.Compare(myArray[scan], myArray[min]) < 0)
                    if (myComparer.Compare(listAutomovil.Get(scan), listAutomovil.Get(min)) < 0)
                    {
                        min = scan;
                    }
                }

                //Doing the swap
                Automovil aux = new Automovil(listAutomovil.Get(min).Placa, listAutomovil.Get(min).Marca, listAutomovil.Get(min).Modelo);

                listAutomovil.Get(min).Placa = listAutomovil.Get(index).Placa;
                listAutomovil.Get(min).Marca = listAutomovil.Get(index).Marca;
                listAutomovil.Get(min).Modelo = listAutomovil.Get(index).Modelo;

                listAutomovil.Get(index).Placa = aux.Placa;
                listAutomovil.Get(index).Marca = aux.Marca;
                listAutomovil.Get(index).Modelo = aux.Modelo;

            }
        }


    }
}
