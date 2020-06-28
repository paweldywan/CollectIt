using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectIt.Tests
{
    [TestClass]
    public class SortedTests
    {
        [TestMethod]
        public void Can_Use_Sorted_List()
        {
            var list = new SortedList<int, string>(); //Szybka iteracja w przeciwieństwie do SortedDictionary, klucze także muszą być unikalne

            list.Add(3, "three");
            list.Add(1, "one");
            list.Add(2, "two");

            Assert.AreEqual(0, list.IndexOfKey(1));
            Assert.AreEqual(1, list.IndexOfValue("two"));
        }

        [TestMethod]
        public void Can_Use_SortedSet()
        {
            var set = new SortedSet<int>();

            set.Add(3);
            set.Add(1);
            set.Add(2);

            var enumerator = set.GetEnumerator();
            enumerator.MoveNext();

            Assert.AreEqual(1, enumerator.Current);
        }
    }
}
