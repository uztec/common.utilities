using System.Collections.Generic;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class ListCompareTest
    {
        [Fact]
        public void TestListStringEquals()
        {
            // Creating a List of strings 
            List<string> list1 = new List<string> { "Item1", "Item2", "Item3", "Item4" };
            List<string> list2 = new List<string> { "Item1", "Item2", "Item3", "Item4" };
            Assert.Equal<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListStringSame()
        {
            // Creating a List of strings 
            List<string> list1 = new List<string> { "Item1", "Item2", "Item3", "Item4" };
            List<string> list2 = list1;
            Assert.Equal<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListStringDiferent()
        {
            // Creating a List of strings 
            List<string> list1 = new List<string> { "Item1", "Item2", "Item3", "Item4" };
            List<string> list2 = new List<string> { "Item1", "Item2", "Item3", "Item5" };
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListStringBigger()
        {
            // Creating a List of strings 
            List<string> list1 = new List<string> { "Item1", "Item2", "Item3", "Item4" };
            List<string> list2 = new List<string> { "Item1", "Item2", "Item3"};
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListStringSmaller()
        {
            // Creating a List of strings 
            List<string> list1 = new List<string> { "Item1", "Item2", "Item3" };
            List<string> list2 = new List<string> { "Item1", "Item2", "Item3", "Item4" };
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListStringNull()
        {
            // Creating a List of strings 
            List<string> list1 = new List<string> { "Item1", "Item2", "Item3" };
            List<string> list2 = null;
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListIntEquals()
        {
            // Creating a List of strings 
            List<int> list1 = new List<int> { 1, 2, 3, 5, 8, 13 };
            List<int> list2 = new List<int> { 1, 2, 3, 5, 8, 13 };
            Assert.Equal<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListIntSame()
        {
            // Creating a List of strings 
            List<int> list1 = new List<int> { 1, 2, 3, 5, 8, 13 };
            List<int> list2 = list1;
            Assert.Equal<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListIntDiferent()
        {
            // Creating a List of strings 
            List<int> list1 = new List<int> { 1, 2, 3, 5, 8, 13 };
            List<int> list2 = new List<int> { 1, 2, 3, 5, 8, 14 };
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListIntBigger()
        {
            // Creating a List of strings 
            List<int> list1 = new List<int> { 1, 2, 3, 5, 8, 13 };
            List<int> list2 = new List<int> { 1, 2, 3, 5, 8};
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListIntSmaller()
        {
            // Creating a List of strings 
            List<int> list1 = new List<int> { 1, 2, 3, 5, 8 };
            List<int> list2 = new List<int> { 1, 2, 3, 5, 8, 13 };
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }
        [Fact]
        public void TestListIntNull()
        {
            // Creating a List of strings 
            List<int> list1 = new List<int> { 1, 2, 3, 5, 8, 13 };
            List<int> list2 = null;
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListIntEmpty()
        {
            // Creating a List of strings 
            List<int> list1 = new List<int> { 1, 2, 3, 5, 8, 13 };
            List<int> list2 = new List<int>();
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

        [Fact]
        public void TestListIntEmptyNull()
        {
            // Creating a List of strings 
            List<int> list1 = new List<int>();
            List<int> list2 = null;
            Assert.NotEqual<int>(0, list1.CompareTo(list2));
        }

    }
}
