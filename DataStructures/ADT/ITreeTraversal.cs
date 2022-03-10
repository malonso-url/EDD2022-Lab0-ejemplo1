using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ADT
{
    interface ITreeTraversal<V>
    {
        void Walk(V value);
    }
}
