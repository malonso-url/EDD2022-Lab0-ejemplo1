using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Lab0.Models;

namespace Lab0.Models.Comparadores
{
    public class CompareAutoByPlacaAsc : IComparer<Lab0.Models.Automovil>
    {
        public int Compare(Automovil x, Automovil y)
        {
            return x.Placa.CompareTo(y.Placa);
        }
    }
}
