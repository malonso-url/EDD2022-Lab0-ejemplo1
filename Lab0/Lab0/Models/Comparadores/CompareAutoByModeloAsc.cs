using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Lab0.Models.Comparadores
{
    public class CompareAutoByModeloAsc : IComparer<Lab0.Models.Automovil>
    {
        public int Compare(Automovil x, Automovil y)
        {
            
            if (x.Modelo == y.Modelo)
            {
                return 0;
            }
            else if (x.Modelo > y.Modelo)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
