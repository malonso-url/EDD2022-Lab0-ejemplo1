using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.ADT
{
    interface ISelfBalancedTree<K, V>
    {
        void Insert(K key, V value);

        V Search(K key);

        V Delete(K key);

        V[] GetList();

        void Traversal(ITreeTraversal<V> traversal);

        bool IsEmpty();

        int Count();

    }
}
