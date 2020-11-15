using NUnit.Framework;
using DataStructures;

namespace ArrayListTests
{
    public class ListTests
    {
        [TestCase(new int[] {1,2,3 }, new int[] { 3,2,1,1,2,3}, new int[] { 3,2,1})]
        [TestCase(new int[] { 0 }, new int[] { 3, 2, 1, 0 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0 }, new int[] { 0 }, new int[] { })]
        [TestCase(new int[] {  }, new int[] { 3, 2, 1}, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3,4,5,6,7,8,9,10 }, new int[] { 3, 2, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 3, 2, 1 })]
        public void TestAdd(int[] values, int[] expectedValues, int[] currentValues)
        {
            ArrayList expected = new ArrayList(expectedValues);
            ArrayList actual = new ArrayList(currentValues);
            actual.Add(values);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(new int[] { 1,2 }, new int[] { 2,1})]
        [TestCase(new int[] { 3,2,1 }, new int[] { 1,2,3 })]
        [TestCase(new int[] {}, new int[] {})]
        public void TestReverseTheList(int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.ReverseTheList();
            Assert.AreEqual(expected.ToString(), actual.ToString()) ;
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 3, 2, 1  }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0 }, new int[] { 0,3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0 }, new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 3, 2, 1  }, new int[] { 3, 2, 1 })]
        public void TestAddElementsToTheBeginning(int[] values,int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddElementsToTheBeginning(values);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(new int[] { 1, 2, 3 },0, new int[] { 1, 2, 3, 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3 },2, new int[] { 3, 2, 1, 2, 3, 1 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 3, 2, 1,1, 2, 3 }, new int[] { 3, 2, 1 })]
        
        [TestCase(new int[] { 0 },0, new int[] {0, 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0 },0, new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 0 },3, new int[] {  3, 2, 1,0 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0 }, 2, new int[] { 3, 2, 0, 1 }, new int[] { 3, 2, 1 })]
        
        [TestCase(new int[] { },0, new int[] { 1,2,3 }, new int[] {1,2,3 })]
        [TestCase(new int[] { },2, new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] {  },3, new int[] {  3, 2, 1 }, new int[] { 3, 2, 1 })]
        public void TestAddElementsToTheIndex(int[] values,int index, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddElementsToTheIndex(values, index);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestCase(new int[] {0 }, -1, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0}, 4, new int[] { 3, 2, 1 })]
        public void NegativeTestAddElementsToTheIndex(int[] values, int index, int[] actualArray)
        {
            try
            {
                ArrayList actual = new ArrayList(actualArray);
                actual.AddElementsToTheIndex(values, index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [TestCase(1, new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(3,  new int[] {  }, new int[] { 3, 2, 1 })]
        [TestCase(0,  new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        public void TestRemove(int n, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.Remove(n);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase( -1, new int[] { 3, 2, 1 })]
        [TestCase( 4, new int[] { 3, 2, 1 })]
        [TestCase(0, new int[] { })]
        public void NegativeTestRemove(int n, int[] actualArray)
        {
            try
            {
                ArrayList actual = new ArrayList(actualArray);
                actual.Remove(n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(1, new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { }, new int[] { 3, 2, 1 })]
        [TestCase(0, new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        public void TestRemoveFromBeginning(int n, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveFromBeginning(n);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(-1, new int[] { 3, 2, 1 })]
        [TestCase(4, new int[] { 3, 2, 1 })]
        [TestCase(0, new int[] { })]
        public void NegativeTestRemoveFromBeginning(int n, int[] actualArray)
        {
            try
            {
                ArrayList actual = new ArrayList(actualArray);
                actual.RemoveFromBeginning(n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(0,1, new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(0,3, new int[] { }, new int[] { 3, 2, 1 })]
        [TestCase(0,0, new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]

        [TestCase(1, 1, new int[] {3,1 }, new int[] { 3, 2, 1 })]
        [TestCase(2, 1, new int[] { 3, 2}, new int[] { 3, 2, 1 })]
        [TestCase(1, 2, new int[] { 3 }, new int[] { 3, 2, 1 })]

        [TestCase(2, 0, new int[] { 3,2, 1 }, new int[] { 3, 2, 1 })]
        
        public void TestRemoveFromIndex(int index, int n, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveFromIndex(index,n);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestCase(-1, 1, new int[] { 3, 2, 1 })]
        [TestCase(0, 4, new int[] { 3, 2, 1 })]
        [TestCase(0,-1, new int[] {3,2,1 })]
        [TestCase(4, 1, new int[] { 3, 2, 1 })]
        [TestCase(2, 3, new int[] { 3, 2, 1 })]
        [TestCase(0, 0, new int[] {  })]
        public void NegativeTestRemoveFromIndex(int index, int n, int[] actualArray)
        {
            try
            {
                ArrayList actual = new ArrayList(actualArray);
                actual.RemoveFromIndex(index,n);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(2,1, new int[] { 1,2,3} )]
        [TestCase(2, 0, new int[] { 2, 2, 2 })]
        public void TestGetTheIndexByValue(int value, int expected, int[] actualArray)
        {
            ArrayList actualList = new ArrayList(actualArray);
            int actual = actualList.GetTheIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 1, 2, 3 })]
        public void NegativeTestGetTheIndexByValue(int value, int[] actualArray)
        {
            try
            {
                ArrayList actualList = new ArrayList(actualArray);
                int actual = actualList.GetTheIndexByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(3, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 2, 2, 2 })]
        public void TestGetMaxElement( int expected, int[] actualArray)
        {
            ArrayList actualList = new ArrayList(actualArray);
            int actual = actualList.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 2, 2, 2 })]
        public void TestGetMinElement(int expected, int[] actualArray)
        {
            ArrayList actualList = new ArrayList(actualArray);
            int actual = actualList.GetMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 2, 2, 2 })]
        public void TestGetMinElementIndex(int expected, int[] actualArray)
        {
            ArrayList actualList = new ArrayList(actualArray);
            int actual = actualList.GetMinElementIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 2, 2, 2 })]
        public void TestGetMaxElementIndex(int expected, int[] actualArray)
        {
            ArrayList actualList = new ArrayList(actualArray);
            int actual = actualList.GetMaxElementIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2,1,3}, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 2,2,2 }, new int[] { 2, 2, 2 })]
        [TestCase(new int[] {  }, new int[] {  })]
        public void TestSortAscending(int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual = actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 2, 1, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        public void TestSortDescending(int[] actualArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual = actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 2,1,3,1,5}, new int[] { 1,2,1,3,1,5})]
        [TestCase(1, new int[] { 2, 3,  5 }, new int[] {  2,  3,  5 ,1})]
        [TestCase(1, new int[] { 2, 1, 3, 1, 5 }, new int[] {  2,1, 1, 3, 1, 5 })]
        public void TestRemoveFirstElementByValue(int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveFirstElementByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 2, 3,  5 }, new int[] { 1, 2, 1, 3, 1, 5 })]
        [TestCase(1, new int[] { 2, 3, 5 }, new int[] { 2, 3, 5, 1 })]
        [TestCase(1, new int[] { 2, 3,  5 }, new int[] { 2, 1, 1, 3, 1, 5 })]
        public void TestRemoveAllElementsByValue(int value, int[] expectedArray, int[] actualArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.RemoveAllElementsByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1,  new int[] {  2,  3,  5 })]
        public void NegativeTestRemoveAllElementsByValue(int value, int[] actualArray)
        {
            try
            {
                ArrayList actual = new ArrayList(actualArray);
                actual.RemoveAllElementsByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(1, new int[] { 2, 3, 5 })]
        public void NegativeTestRemoveFirstElementByValue(int value, int[] actualArray)
        {
            try
            {
                ArrayList actual = new ArrayList(actualArray);
                actual.RemoveFirstElementByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}