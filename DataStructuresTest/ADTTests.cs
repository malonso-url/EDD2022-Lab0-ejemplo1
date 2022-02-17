using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.LinearStructures;

namespace DataStructuresTest
{
    [TestClass]
    public class ADTTests
    {
        [TestMethod]
        public void CustomListInsertAtStartTest()
        {
            CustomLinkedList<string> miLista = new CustomLinkedList<string>();
            miLista.InsertAtStart("prueba");
            Assert.AreEqual(1, miLista.Count());
        }


    }
}
