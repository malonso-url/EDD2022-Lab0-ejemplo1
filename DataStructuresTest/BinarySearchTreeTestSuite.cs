using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.TreeStructures;
using DataStructures.ADT;

namespace DataStructuresTest
{
    class Recorrido<V> : ITreeTraversal<V>
    {
        public List<V> listado = new List<V>();

        public void Walk(V value)
        {
            listado.Add(value);
        }
    }

    [TestClass]
    public class BinarySearchTreeTestSuite
    {
        [TestMethod]
        public void BSTInsertEmptyTreeTest()
        {
            BinarySearchTree<int, string> myBST = new BinarySearchTree<int, string>(CompareNumbers);
            myBST.Insert(10, "test");
            Assert.AreEqual(1, myBST.Count());

            string[] elementsInList = myBST.GetList();
            Assert.AreEqual("test", elementsInList[0]);
            
        }

        [TestMethod]
        public void BSTInsertMultipleElementsTest()
        {
            BinarySearchTree<int, string> myBST = new BinarySearchTree<int, string>(CompareNumbers);
            myBST.Insert(50, "50");
            myBST.Insert(10, "10");
            myBST.Insert(90, "90");
            myBST.Insert(5, "5");
            myBST.Insert(25, "25");
            myBST.Insert(100, "100");
            myBST.Insert(80, "80");
            myBST.Insert(75, "75");
            myBST.Insert(15, "15");
            Assert.AreEqual(myBST.Count(), 9);

            string[] elementsInList = myBST.GetList();
            Assert.AreEqual("5", elementsInList[0]);
            Assert.AreEqual("10", elementsInList[1]);
            Assert.AreEqual("15", elementsInList[2]);
            Assert.AreEqual("25", elementsInList[3]);
            Assert.AreEqual("50", elementsInList[4]);
            Assert.AreEqual("75", elementsInList[5]);
            Assert.AreEqual("80", elementsInList[6]);
            Assert.AreEqual("90", elementsInList[7]);
            Assert.AreEqual("100", elementsInList[8]);

        }

        [TestMethod]
        public void BSTDeleteRootOnlyOneElementTest()
        {
            BinarySearchTree<int, string> myBST = new BinarySearchTree<int, string>(CompareNumbers);
            myBST.Insert(50, "50");
            Assert.AreEqual(false, myBST.IsEmpty());
            Assert.AreEqual("50", myBST.Delete(50));
            Assert.AreEqual(true, myBST.IsEmpty());
            Assert.AreEqual(null, myBST.Delete(5));
        }

        [TestMethod]
        public void BSTDeleteRootMultipleElementTest()
        {
            BinarySearchTree<int, string> myBST = new BinarySearchTree<int, string>(CompareNumbers);
            Recorrido<String> miRecorrido = new Recorrido<String>();

            myBST.Insert(50, "50");
            myBST.Insert(10, "10");
            myBST.Insert(90, "90");
            myBST.Insert(5, "5");
            myBST.Insert(25, "25");
            myBST.Insert(100, "100");
            myBST.Insert(80, "80");
            myBST.Insert(75, "75");
            myBST.Insert(15, "15");

            Assert.AreEqual("50", myBST.Delete(50)); //Delete the root

            myBST.InOrder(miRecorrido);

            Assert.AreEqual("5", miRecorrido.listado.ToArray()[0]);
            Assert.AreEqual("10", miRecorrido.listado.ToArray()[1]);
            Assert.AreEqual("15", miRecorrido.listado.ToArray()[2]);
            Assert.AreEqual("25", miRecorrido.listado.ToArray()[3]);
            Assert.AreEqual("75", miRecorrido.listado.ToArray()[4]);
            Assert.AreEqual("80", miRecorrido.listado.ToArray()[5]);
            Assert.AreEqual("90", miRecorrido.listado.ToArray()[6]);
            Assert.AreEqual("100", miRecorrido.listado.ToArray()[7]);

        }

        [TestMethod]
        public void BSTPostOrderWaltTest()
        {
            BinarySearchTree<int, string> myBST = new BinarySearchTree<int, string>(CompareNumbers);
            Recorrido<String> miRecorrido = new Recorrido<String>();

            myBST.Insert(50, "50");
            myBST.Insert(10, "10");
            myBST.Insert(90, "90");
            myBST.Insert(5, "5");
            myBST.Insert(25, "25");
            myBST.Insert(100, "100");
            myBST.Insert(80, "80");
            myBST.Insert(75, "75");
            myBST.Insert(15, "15");

            myBST.PostOrder(miRecorrido);

            Assert.AreEqual("5", miRecorrido.listado.ToArray()[0]);
            Assert.AreEqual("15", miRecorrido.listado.ToArray()[1]);
            Assert.AreEqual("25", miRecorrido.listado.ToArray()[2]);
            Assert.AreEqual("10", miRecorrido.listado.ToArray()[3]);
            Assert.AreEqual("75", miRecorrido.listado.ToArray()[4]);
            Assert.AreEqual("80", miRecorrido.listado.ToArray()[5]);
            Assert.AreEqual("100", miRecorrido.listado.ToArray()[6]);
            Assert.AreEqual("90", miRecorrido.listado.ToArray()[7]);
            Assert.AreEqual("50", miRecorrido.listado.ToArray()[8]);

        }

        [TestMethod]
        public void NormalListTest()
        {
            List<int> miList = new List<int>();

            miList.Insert(0, 1);
            miList.Insert(0, 2);
            miList.Insert(0, 3);
            miList.Insert(0, 4);

            Assert.AreEqual(4, miList[0]);
            Assert.AreEqual(3, miList[1]);
            Assert.AreEqual(2, miList[2]);
            Assert.AreEqual(1, miList[3]);
        }

            [TestMethod]
        public void BSTSearchElementTest()
        {
            BinarySearchTree<int, string> myBST = new BinarySearchTree<int, string>(CompareNumbers);
            myBST.Insert(50, "50");
            myBST.Insert(10, "10");
            myBST.Insert(90, "90");
            myBST.Insert(5, "5");
            myBST.Insert(25, "25");
            myBST.Insert(100, "100");
            myBST.Insert(80, "80");
            myBST.Insert(75, "75");
            myBST.Insert(15, "15");


            Assert.AreEqual("50", myBST.Search(50)); //search the root

            Assert.AreEqual(null, myBST.Search(4)); //Search non existent

            Assert.AreEqual("100", myBST.Search(100)); //Search leaft on right

            Assert.AreEqual("25", myBST.Search(25)); //Search intermediate node on left

        }

        private int CompareNumbers(int value1, int value2) {
            if (value1 > value2)
            {
                return 1;
            }
            else if (value1 < value2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

}
