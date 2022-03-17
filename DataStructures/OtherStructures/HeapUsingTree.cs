using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ADT;
using DataStructures.TreeStructures;

namespace DataStructures.OtherStructures
{
    class HeapUsingTree<K, V> : IHeap<K, V>
    {
        private GetPriorityDelegate<K, V> getPriority;
        private ComparePriorityDelegate<K> comparePriority;
        private int count;
        private TreeNode<K, V> root;

        public HeapUsingTree(GetPriorityDelegate<K, V> _getPriority, ComparePriorityDelegate<K> _comparePriority) {
            getPriority = _getPriority;
            comparePriority = _comparePriority;
        }

        public int Count()
        {
            return count;
        }

        public void Insert(V value)
        {
            if (IsEmpty())
            {
                TreeNode<K, V> newNode = new TreeNode<K, V>(getPriority(value), value);
                root = newNode;
                count++;
            }
            else 
            { 

            }
        }

        public bool IsEmpty()
        {
            return 0 == count;
        }

        public V peek()
        {
            throw new NotImplementedException();
        }

        public V Remove()
        {
            throw new NotImplementedException();
        }

        private void insertInternal(TreeNode<K, V> padre, TreeNode<K, V> newNode, int level) {

            int max_by_level = 1;
            for (int i = 1; i <= level; i++) {
                max_by_level += Convert.ToInt32(Math.Pow(2, i));
            }

            if (Count() < max_by_level)
            {  //Pede ser insertado en este nivel
                if (padre.left == null)
                {
                    padre.left = newNode;
                }
                else
                {
                    padre.right = newNode;
                }
                count++;

                //@pending: Comaparamos a verificar si es necesario cambiar el contenido del nodo
            }
            else
            { 
                //@pending: Buscar en el siguiente nivel pero enviarle como parametro el padre que puede tenerlo

            }

        }


    }
}
