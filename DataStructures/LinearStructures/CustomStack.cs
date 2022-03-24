using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.ADT;

namespace DataStructures.LinearStructures
{
    class CustomStack<T> : IStack<T>
    {

        private Node<T> head;
        private int count;

        public CustomStack() {
            head = null;
            count = 0;
        }

        public int Count()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T Peek()
        {
            if (head != null) {
                return head.value;
            }
            return default;
        }

        public T Pull()
        {
            if (!IsEmpty()){
                T temp = head.value;
                head = head.next;
                count--;
                return temp;
            }

            return default;
        }

        public void Push(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (IsEmpty())
            {
                head = newNode;
                count++;
            }
            else 
            {
                newNode.next = head;
                head = newNode;
                count++;
            }
        }
    }
}
