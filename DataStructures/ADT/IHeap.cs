using System;
using System.Collections.Generic;
using System.Text;

public delegate K GetPriorityDelegate<K, V>(V value);

public delegate int ComparePriorityDelegate<K>(K priority1, K priority2);

namespace DataStructures.ADT
{
    interface IHeap<K, V>
    {
        void Insert(V value);

        V peek();

        V Remove();

        int Count();

        bool IsEmpty();
    }
}
