using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab0.Models
{
    public class Automovil
    {
        public Automovil(String Placa, String Marca, int Modelo) {
            this.Placa = Placa;
            this.Marca = Marca;
            this.Modelo = Modelo;
        }

        public string Placa {get; set;}

        public string Marca { get; set; }

        public int Modelo { get; set; }
    }
}
