using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Lab0.Models;

namespace Lab0.Models.Comparadores
{
    public class CompareAutoByMarcaDesc : IComparer<Automovil>
    {
        public int Compare(Automovil x, Automovil y)
        {
            return x.Marca.CompareTo(y.Marca) * (-1);
        }
    }
}
