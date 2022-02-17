using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Lab0.Models.Comparadores
{
    public class CompareAutoByMarcaAsc : IComparer<Lab0.Models.Automovil>
    {
        public int Compare(Automovil x, Automovil y)
        {
            return x.Marca.CompareTo(y.Marca);
        }
    }
}
