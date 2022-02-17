using System;
using DataStructures.LinearStructures;

namespace ManualTest
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomLinkedList<string> miLista = new CustomLinkedList<string>();
            miLista.InsertAtStart("prueba 1");
            miLista.InsertAtStart("prueba 2");
            miLista.InsertAtStart("prueba 3");

            foreach (var item in miLista) {
                Console.WriteLine(item);
            }

            Console.WriteLine("La cantidad de elementos es " + miLista.Count());
        }
    }
}
