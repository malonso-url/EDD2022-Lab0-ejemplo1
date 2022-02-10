using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.LinearStructures;

namespace DataStructuresTest
{
    [TestClass]
    public class ADTTests
    {
        [TestMethod]
        public void CustomListInsertTest()
        {
            CustomLinkedList<string> miLista = new CustomLinkedList<string>();
            miLista.Insert("prueba");
            Assert.AreEqual(1, miLista.Count());
        }
    }
}
