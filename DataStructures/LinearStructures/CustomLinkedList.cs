using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinearStructures
{
    public class CustomLinkedList<T> : ICustomLinkedList<T>, IEnumerable<T>
    {
        private int count;
        private Node<T> start;
        private Node<T> end;

        public int Count()
        {
            return count;
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }

        public void Insert(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (IsEmpty())
            {
                start = newNode;
                end = newNode;
            }
            else {
                end.next = newNode;
                end = newNode;
            }

            count++;
        }

        public void Insert(T value, int index)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return (count == 0);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<T> GetEnumerator()
        {
            var node = start;
            while (node != null) {
                yield return node.value;
                node = node.next;
            }
        }

        
    }
}
