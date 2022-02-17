
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DataStructures.ADT;

namespace DataStructures.LinearStructures
{
    public delegate void SortMethod();

    public class CustomLinkedList<T> : ICustomList<T>, IEnumerable<T>, ISortable<T>
    {
        private int count;
        private Node<T> start;
        private Node<T> end;

        public int Count()
        {
            return count;
        }

        public T Get(int index)
        {
            if (!IsEmpty())
            {
                if (index == 0)
                {
                    return start.value;
                }
                else if (index == (Count() - 1))
                {
                    return end.value;
                }
                else if ((index > 0) && (index < (Count() - 1)))
                {
                    Node<T> temp = start;
                    int i = 0;
                    while ((temp != null) && (i != index))
                    {
                        temp = temp.next;
                        i++;
                    }

                    if (temp != null)
                    {
                        return temp.value;
                    }
                    else
                    {
                        return default;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            return default;
        }

        public void InsertAtEnd(T value)
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
            if (IsEmpty()) //if the list is empty then insert at start
            {
                InsertAtStart(value);
            }
            else 
            {
                if (index >= Count()) //if the index is equal or greater than count then insert at end
                {
                    InsertAtEnd(value);
                } 
                else if (index == 0) //If the index to insert is 0 and the list is not empty
                {
                    InsertAtStart(value);
                }
                else if ((index > 0) && (index < Count())) //Index between 1 (second element) and Count() - 1 previous the last one
                {
                    Node<T> newNode = new Node<T>(value);
                    Node<T> pretemp = start;
                    Node<T> temp = start.next;
                    int i = 1;

                    //Search the position where the node will be inserted
                    while ((temp != null) && (i < index)) {
                        pretemp = temp;
                        temp = temp.next;
                        i++;
                    }

                    //doing the insertion
                    newNode.next = temp;
                    pretemp.next = newNode;
                    count++;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

            }
        }

        public bool IsEmpty()
        {
            return (count == 0);
        }


        public void InsertAtStart(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (IsEmpty())
            {
                start = newNode;
                end = newNode;
            }
            else
            {
                newNode.next = start;
                start = newNode;
            }

            count++;
        }

        public T Delete(int index)
        {

            if (index == 0)
            {
                return DeleteAtStart();
            }
            else if (index == (Count() - 1))
            {
                return DeleteAtEnd();
            }
            else if ((index > 0) && (index < (Count() - 1)))
            {
                Node<T> pretemp = start;
                Node<T> temp = start.next;
                int i = 1;

                //Search the position where the node will be inserted
                while ((temp != null) && (i < (Count() - 1)))
                {
                    pretemp = temp;
                    temp = temp.next;
                    i++;
                }

                //Delete the node
                pretemp.next = temp.next;
                count--;
                return temp.value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public T DeleteAtStart()
        {
            if (!IsEmpty()) 
            {
                Node<T> temp = start;
                start = start.next;
                count--;
                return temp.value;
            }

            return default;
        }

        public T DeleteAtEnd()
        {
            if (!IsEmpty()) 
            {

                if (Count() == 1) //Only one node then delete
                {
                    Node<T> temp = start;
                    start = null;
                    end = null;
                    count--;
                    return temp.value;
                }
                else
                {
                    Node<T> pretemp = start;
                    Node<T> temp = start.next;

                    //Search the position where the node will be inserted
                    while (temp != null)
                    {
                        pretemp = temp;
                        temp = temp.next;
                    }

                    //Delete the node
                    end = pretemp;
                    end.next = null;
                    count--;
                    return temp.value;
                }

            }

            return default;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = start;
            while (node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            if (Count() <= 1) return;

            Node<T> first = start;
            Node<T> aElement = start;
            Node<T> bElement = start;

            for (int i = 0; i < Count() - 1; i++)
            {
                aElement = first;
                for (int j = 0; j < Count() - 1; j++)
                {
                    bElement = aElement.next;
                    if (comparer.Compare(aElement.value, bElement.value) > 0)
                    {
                        Swap(ref aElement, ref bElement);
                    }
                    aElement = aElement.next;
                }
            }
        }

        private void Swap(ref Node<T> a, ref Node<T> b)
        {
            T aux = b.value;
            b.value = a.value;
            a.value = aux;
        }

        public void SortUsingMethods(SortMethod preferedSortMethod) {
            preferedSortMethod();
        }

       
    }

}
