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
        [TestCase(0,new int[] { 5, 6, 7 }, new int[] { 5, 6, 7 }, new int[] { })]
        [TestCase(1, new int[] { 5, 6, 7 }, new int[] {1, 5, 6, 7,  2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(1, new int[] { 5 }, new int[] { 1, 5,  2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { 5, 6, 7 }, new int[] { 1,  2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { 5, }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        public void TestAddToTheIndex(int index, int[] values, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddToTheIndex(values, index);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(5, new int[] { 5, 6, 7 }, new int[] {1,2 })]
        [TestCase(-1, new int[] { 1}, new int[] {1,2 })]
        [TestCase(1, new int[] { }, new int[] { 1, 2 })]
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
        [TestCase(1, new int[] { 1 }, new int[] { 1, 2 })]
        [TestCase(2, new int[] { 1 }, new int[] { 1, 2,3 })]
        [TestCase(3, new int[] { }, new int[] { 1, 2,3 })]
        [TestCase(0, new int[] {1,2,3 }, new int[] { 1, 2, 3 })]
        public void Remove(int n, int[] expectedArray, int[] actualArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);
            actual.Remove(n);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(-1, new int[] { 1, 2 })]
        [TestCase(3, new int[] { 1, 2 })]
        [TestCase(1, new int[] { })]
        public void NegativeTestRemove(int n,  int[] actualArray)
        {
            try
            {
                LinkedList actual = new LinkedList(actualArray);
                actual.Remove(n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(1, new int[] {2 }, new int[] { 1, 2 })]
        [TestCase(2, new int[] { 3 }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void TestRemoveFromBeginning(int n, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveFromBeginning(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 1, 2 })]
        [TestCase(3, new int[] { 1, 2 })]
        [TestCase(1, new int[] { })]
        public void NegativeTestRemoveFromBeginning(int n, int[] actualArray)
        {
            try
            {
                LinkedList actual = new LinkedList(actualArray);
                actual.RemoveFromBeginning(n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [TestCase(0, 1, new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(0,2, new int[] { 3 }, new int[] { 1, 2, 3 })]
        [TestCase(0,3, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(1,1, new int[] { 1,  3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, 2, new int[] { 1, 4,5 }, new int[] { 1, 2, 3,4 ,5})]
        [TestCase(1, 1, new int[] { 1, 3,4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 3, new int[] { 1, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 2, new int[] { 1}, new int[] { 1, 2, 3 })]
        [TestCase(2, 1, new int[] { 1,2 }, new int[] { 1, 2, 3 })]
        public void TestRemoveFromIndex(int index,int n, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveFromIndex(index,n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1,1, new int[] { 1, 2 })]
        [TestCase(3,1, new int[] { 1, 2 })]
        [TestCase(1,-1, new int[] {1,2 })]
        [TestCase(2, 1, new int[] { 1, 2 })]
        [TestCase(1, 2, new int[] { 1, 2 })]
        [TestCase(2, 1, new int[] { })]
        [TestCase(1, 2, new int[] {  })]
        public void NegativeTestRemoveFromIndex(int index,int n, int[] actualArray)
        {
            try
            {
                LinkedList actual = new LinkedList(actualArray);
                actual.RemoveFromIndex(index,n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(-1, 8, new int[] { 1, 2 ,3,4,5,6,7,0,-1,-5,-6})]
        [TestCase(1, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 0, -1, -5, -6 })]
        [TestCase(2, 1, new int[] { 1, 2, 3, 4, 5, 6, 7, 0, -1, -5, -6 })]
        [TestCase(3, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 0, -1, -5, -6 })]
        [TestCase(4, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 0, -1, -5, -6 })]
        [TestCase(-6, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 0, -1, -5, -6 })]
        [TestCase(0, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 0, -1, -5, -6 })]
        public void TestGetIndexByValue(int value, int expected, int[] actualArray)
        {
            LinkedList actualList = new LinkedList(actualArray);
            int actual = actualList.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 1, 2 })]
        [TestCase( 2, new int[] { })]
        public void NegativeTestGetIndexByValue(int index,  int[] actualArray)
        {
            try
            {
                LinkedList actual = new LinkedList(actualArray);
                actual.GetIndexByValue(index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [TestCase(0, new int[] { -1,-2,0,-5,-33})]
        [TestCase(0, new int[] { 0 })]
        [TestCase(0, new int[] {0, -2, -5, -33 })]
        [TestCase(10, new int[] { 0, -2, 5, -33, 10 })]
        public void TestGetMaxlement(int expected, int[] actualArray)
        {
            LinkedList actualList = new LinkedList(actualArray);
            int actual = actualList.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { })]
        public void NegativeTestGetMaxElement(int[] actualArray)
        {
            try
            {
                LinkedList actualList = new LinkedList(actualArray);
                int actual = actualList.GetMaxElement();
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(-33, new int[] { -1, -2, 0, -5, -33 })]
        [TestCase(0, new int[] { 0 })]
        [TestCase(-66, new int[] { -66, -2, -5, -33 })]
        [TestCase(0, new int[] { 0, 2, 5, 33, 10 })]
        public void TestGetMinlement(int expected, int[] actualArray)
        {
            LinkedList actualList = new LinkedList(actualArray);
            int actual = actualList.GetMinElement();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { })]
        public void NegativeTestGetMinElement(int[] actualArray)
        {
            try
            {
                LinkedList actualList = new LinkedList(actualArray);
                int actual = actualList.GetMinElement();
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }



        [TestCase(2, new int[] { -1, -2, 0, -5, -33 })]
        [TestCase(0, new int[] { 0 })]
        [TestCase(0, new int[] { 0, -2, -5, -33 })]
        [TestCase(4, new int[] { 0, -2, 5, -33, 10 })]
        public void TestGetMaxElementIndex(int expected, int[] actualArray)
        {
            LinkedList actualList = new LinkedList(actualArray);
            int actual = actualList.GetMaxElementIndex();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { })]
        public void NegativeTestGetMaxElementIndex(int[] actualArray)
        {
            try
            {
                LinkedList actualList = new LinkedList(actualArray);
                int actual = actualList.GetMaxElementIndex();
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(4, new int[] { -1, -2, 0, -5, -33 })]
        [TestCase(0, new int[] { 0 })]
        [TestCase(3, new int[] { 0, -2, -5, -33 })]
        [TestCase(3, new int[] { 0, -2, 5, -33, 10 })]
        [TestCase(0, new int[] { 1, 2, 5, 33, 10 })]
        public void TestGetMinElementIndex(int expected, int[] actualArray)
        {
            LinkedList actualList = new LinkedList(actualArray);
            int actual = actualList.GetMinElementIndex();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { })]
        public void NegativeTestGetMinElementIndex(int[] actualArray)
        {
            try
            {
                LinkedList actualList = new LinkedList(actualArray);
                int actual = actualList.GetMinElementIndex();
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [TestCase(5, new int[] {1,2,3,4 }, new int[] { 1,2,3,4,5})]
        [TestCase(2, new int[] { 1,  3, 4,5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] {  2, 3, 4,5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1,2, 3, 4, 5 }, new int[] { 1,1, 2, 3, 4, 5 })]
        public void TestRemoveFirstElementByValue(int value, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveFirstElementByValue(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(4,new int[] {1,2,3 })]
        [TestCase(4, new int[] {  })]
        public void NegativeTestRemoveFirstElementByValue(int value, int[] actualArray)
        {
            try
            {
                LinkedList actual = new LinkedList(actualArray);
                actual.RemoveFirstElementByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(1, new int[] {  2, 3, 4,5 }, new int[] { 1,1, 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 1,1,2, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 1,2, 3, 4 }, new int[] { 1, 2, 3, 4, 5,5 })]
        [TestCase(1, new int[] { 2, 3, 4, 5 }, new int[] { 1, 2, 3,1, 4, 5 })]
        [TestCase(1, new int[] {  2, 3, 4, 5 }, new int[] { 1, 1, 2, 3, 4, 5 })]
        public void TestRemoveAllElementsByValue(int value, int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.RemoveAllElementsByValue(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(4, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { })]
        public void NegativeTestRemoveAllElementsByValue(int value, int[] actualArray)
        {
            try
            {
                LinkedList actual = new LinkedList(actualArray);
                actual.RemoveAllElementsByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [TestCase(new int[] { 1,2,3,4}, new int[] {4,3,2,1 })]
        [TestCase(new int[] {  }, new int[] { })]
         [TestCase(new int[] { 1, 2 }, new int[] { 2,1})]
    public void TestReverseTheList(int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.ReverseTheList();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] {-5,0, 1, 2 }, new int[] { 2, 0, 1,-5 })]
        public void TestSortAsending(int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] {  1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 1, 0, -5 }, new int[] { 2, 0, 1, -5 })]
        public void TestSortDesending(int[] expectedArray, int[] actualArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }
    }

}
