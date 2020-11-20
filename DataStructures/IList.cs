using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public interface IList
    {
        int GetIndexByValue(int value);
        void Add(int[] values);
        void AddToTheBeginning(int[] values);
        void AddToTheIndex(int[] values, int index);
        public void Remove(int n);
        public void RemoveFromBeginning(int n);
        public void RemoveFromIndex(int index, int n);
        int GetMaxElement();
        int GetMinElement();
        int GetMaxElementIndex();
        int GetMinElementIndex();
        void RemoveAllElementsByValue(int value);
        void RemoveFirstElementByValue(int value);
        void ReverseTheList();



    }
}
