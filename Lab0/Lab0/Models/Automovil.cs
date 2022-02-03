using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab0.Models
{
    public class Automovil
    {
        public Automovil(string placa, string marca, int modelo) {
            this.placa = placa;
            this.marca = marca;
            this.modelo = modelo;
        }

        [Display(Name = "Placa")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Ingrese una placa")]
        [StringLength(7)]
        public string placa { get; set; }

        [Display(Name = "Marca")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese la marca del automovil")]
        public string marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el año de fabricación")]
        public int modelo { get; set; }
    }
}
