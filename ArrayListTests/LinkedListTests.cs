using System;
using NUnit.Framework;
using DataStructures.LList;

namespace ArrayListTests
{
    class LinkedListTests
    {  
        [TestCase(0,1, new int[] { 1,2,3,4})]
        [TestCase(1, 2, new int[] { 1, 2, 3, 4 })]
        [TestCase(3, 4, new int[] { 1, 2, 3, 4 })]
        public void TestIndex(int index, int expected, int[] actualArray)
        {
            LinkedList actualList = new LinkedList(actualArray);
            int actual = actualList[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5,6,7}, new int[] {1,2,3,4,5,6,7 }, new int[] { 1,2,3,4})]
        [TestCase(new int[] { 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5, 6, 7 }, new int[] {  5, 6, 7 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { }, new int[] {  })]
        public void TestAdd(int[] values, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.Add(values);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(new int[] { 5, 6, 7 }, new int[] { 5, 6, 7 ,1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5 }, new int[] {5, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5, 6, 7 }, new int[] { 5, 6, 7 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        public void TestAddToTheBeginning(int[] values, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddToTheBeginning(values);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(0,new int[] { 5, 6, 7 }, new int[] { 5, 6, 7, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0,new int[] { 5 }, new int[] { 5, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0,new int[] { }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
      //  [TestCase(0,new int[] { 5, 6, 7 }, new int[] { 5, 6, 7 }, new int[] { })]
       // [TestCase(0,new int[] { }, new int[] { }, new int[] { })]

        [TestCase(1, new int[] { 5, 6, 7 }, new int[] {1, 5, 6, 7,  2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { 5, 6, 7 }, new int[] { 1,  2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4 })]

        public void TestAddToTheIndex(int index, int[] values, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddToTheIndex(values, index);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(5, new int[] { 5, 6, 7 }, new int[] {1,2 })]
        [TestCase(-1, new int[] { 1}, new int[] {1,2 })]
        public void NegativeTestAddToTheIndex(int index, int[] values, int[] actualArray)
        {
            try
            {
                LinkedList actual = new LinkedList(actualArray);
                actual.AddToTheIndex(values, index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}
