using System;
using System.Collections.Generic;
using System.Text;

public delegate K GetKeyDelegate<K, V>(V value);

public delegate int CompareKeysDelegate<K>(K key1, K key2);

namespace DataStructures.ADT
{
    interface IBinarySearchTree<K, V>
    {
        void Insert(V value);

        V Search(K key);

        V Delete(K key);

        V[] GetList();

        void InOrder(ITreeTraversal<V> traversal);

        void PreOrder(ITreeTraversal<V> traversal);

        void PostOrder(ITreeTraversal<V> traversal);

        bool IsEmpty();

        int Count();
    }
}
