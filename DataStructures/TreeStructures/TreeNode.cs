using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.TreeStructures
{
    class TreeNode<K, V>
    {
        public TreeNode(K key, V value)
        {
            this.key = key;
            this.value = value;
            this.left = null;
            this.right = null;
            this.parent = null;
        }

        public K key { get; set; }

        public V value { get; set; }

        public TreeNode<K, V> left { get; set; }

        public TreeNode<K, V> right { get; set; }

        public TreeNode<K, V> parent { get; set; }
    }
}
