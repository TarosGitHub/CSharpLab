using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Enumerator;

namespace EnumeratorTests
{
    [TestClass]
    public class EnumerableEnumeratorTests
    {
        [TestMethod]
        public void TestPrintEnumerator()
        {
            List<int> list = new List<int> { 10, 11, 12, 13 };

            string res = EnumerableEnumerator.PrintEnumerator(list.GetEnumerator());

            Assert.AreEqual("10111213", res);
        }

        [TestMethod]
        public void TestPrintEnumerable()
        {
            List<int> list = new List<int> { 10, 11, 12, 13 };

            string res = EnumerableEnumerator.PrintEnumerable(list);

            Assert.AreEqual("10111213", res);
        }
    }
}
