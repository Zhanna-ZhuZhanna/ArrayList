using System;
using NUnit.Framework;
using DataStructures.DLList;

namespace ArrayListTests
{
    class DoubleLinkedListTests
    {
        [TestCase(0, 1, new int[] { 1, 2, 3, 4 })]
        [TestCase(1, 2, new int[] { 1, 2, 3, 4 })]
        [TestCase(3, 4, new int[] { 1, 2, 3, 4 })]
        public void TestIndex(int index, int expected, int[] actualArray)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(actualArray);
            int actual = actualList[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0, new int[] { 0, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(1, 1, new int[] { 1, 1, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, 2, new int[] { 1, 2, 2, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(3, 3, new int[] { 1, 2, 3, 3 }, new int[] { 1, 2, 3, 4 })]
        public void TestChangingIndexValue(int index, int newValue, int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual[index]=newValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5, 6, 7 }, new int[] { 5, 6, 7 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        public void TestAdd(int[] values, int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.Add(values);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(new int[] { 5, 6, 7 }, new int[] { 5, 6, 7, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5 }, new int[] { 5, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 5, 6, 7 }, new int[] { 5, 6, 7 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        public void TestAddToTheBeginning(int[] values, int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.AddToTheBeginning(values);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(0, new int[] { 5, 6, 7 }, new int[] { 5, 6, 7, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 5 }, new int[] { 5, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 5, 6, 7 }, new int[] { 5, 6, 7 }, new int[] { })]
        [TestCase(1, new int[] { 5, 6, 7 }, new int[] { 1, 5, 6, 7, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(1, new int[] { 5 }, new int[] { 1, 5, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        public void TestAddToTheIndex(int index, int[] values, int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.AddToTheIndex(values, index);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(5, new int[] { 5, 6, 7 }, new int[] { 1, 2 })]
        [TestCase(-1, new int[] { 1 }, new int[] { 1, 2 })]
        [TestCase(1, new int[] { }, new int[] { 1, 2 })]
        public void NegativeTestAddToTheIndex(int index, int[] values, int[] actualArray)
        {
            try
            {
                DoubleLinkedList actual = new DoubleLinkedList(actualArray);
                actual.AddToTheIndex(values, index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        public void TestReverseTheList(int[] expectedArray, int[] actualArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            DoubleLinkedList actual = new DoubleLinkedList(actualArray);
            actual.ReverseTheList();
            Assert.AreEqual(expected, actual);
        }

    }
}
