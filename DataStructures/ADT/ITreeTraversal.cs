using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ADT
{
    public interface ITreeTraversal<V>
    {
        void Walk(V value);
    }
}
