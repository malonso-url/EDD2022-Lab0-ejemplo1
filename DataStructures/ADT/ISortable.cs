using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ADT
{
    public interface ISortable<T>
    {
        /// <summary>
        /// This method sort a list of elements
        /// </summary>
        /// <param name="comparer">Needs a way to compare the elements since they are generics</param>
        void Sort(IComparer<T> comparer);

    }
    
}
