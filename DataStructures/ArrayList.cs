using System;
using System.Net.NetworkInformation;

namespace DataStructures
{
    public class ArrayList
    {
        private int[] _array;   
        public int LengthOfList { get; private set; }

        public ArrayList()
        {
            _array = new int[3];
            LengthOfList = 0;
        }

        public void Add(int value)
        {
            if (LengthOfList>=_array.Length)
            {
                RiseSize();
            }
            _array[LengthOfList] = value;
            LengthOfList++;
        }
        public void ReverseTheList()
        {
            int[] newArray = new int[_array.Length];
            for (int i=0;i<LengthOfList;i++)
            {
                newArray[i] = _array[LengthOfList - 1 - i];
            }
            _array = newArray ;
        }
        public void AddElementToTheBeginning(int value)
        {
            if (LengthOfList>=_array.Length)
            {
                RiseSize();
            }
            int[] newArray = new int[_array.Length+1];
            newArray[0] = value;
            Array.Copy(_array,0,newArray,1,_array.Length);
            _array = newArray;
            LengthOfList++;
        }

        public void AddElementToTheIndex(int value, int index)
        {
            if (index < 0) throw new Exception("Index can't be less than zero!");
            if (index >= LengthOfList) throw new Exception("Index is out of the length of the list!");
            if (LengthOfList >= _array.Length)
            {
                RiseSize();
            }
            int[] newArray = new int[_array.Length + 1];
            newArray[index] = value;
            for(int i=0;i<index;i++)
            {
                newArray[i] = _array[i];
            }
            for(int i=index+1;i<newArray.Length;i++)
            {
                newArray[i] = _array[i - 1];
            }
            _array = newArray;
            LengthOfList++;
        }

        public void Remove()
        {
            if (LengthOfList == 0) throw new Exception("There is nothing to remove");
            _array[LengthOfList - 1] = 0;
            LengthOfList--;
            if(LengthOfList<_array.Length/2)
            {
                ReduceSize();
            }
        }

        public void RemoveFromBeginning()
        {
            if (LengthOfList == 0) throw new Exception("There is nothing to remove");
            int[] newArray = new int[_array.Length];
            Array.Copy(_array, 1, newArray, 0, LengthOfList);
            _array = newArray;
            LengthOfList--;
            if (LengthOfList < _array.Length / 2)
            {
                ReduceSize();
            }
        }

        public void RemoveFromIndex(int index)
        {
            if (LengthOfList == 0) throw new Exception("There is nothing to remove");
            if (index < 0) throw new Exception("Index can't be less than zero!");
            if (index >= LengthOfList) throw new Exception("Index is out of the length of the list!");
            int[] newArray = new int[_array.Length];
            for(int i=0;i<index;i++)
            {
                newArray[i] = _array[i];
            }
            for(int i=index+1;i<_array.Length;i++)
            {
                newArray[i - 1] = _array[i];
            }
            _array = newArray;
            LengthOfList--;
            if (LengthOfList < _array.Length / 2)
            {
                ReduceSize();
            }

        }

        public int GetTheElementByIndex(int index)
        {
            if (index >= LengthOfList) throw new Exception("Index is out of the length of the list!");
            if (index<0) throw new Exception("Index can't be less than zero!");
            return _array[index];
        }

        public int GetTheIndexByValue(int value)
        {
            bool check = false;
            int index = 0;
            for(int i=0;i<LengthOfList;i++)
            {
                if(_array[i]==value)
                {
                    index = i;
                    check = true;
                    break;
                }
            }
            if (check) return index;
            else throw new Exception("There are not elements with value you are looking for");
        }

        public void EditElementAtIndex(int index, int value)
        {
            if (index >= LengthOfList) throw new Exception("Index is out of the length of the list!");
            if (index < 0) throw new Exception("Index can't be less than zero!");
            _array[index] = value;
        }


        public int GetMaxElement()
        {
            int max = _array[0];
            for(int i=0;i<LengthOfList;i++)
            {
                if (_array[i] > max) max = _array[i];
            }
            return max;
        }

        public int GetMinElement()
        {
            int min = _array[0];
            for (int i = 0; i < LengthOfList; i++)
            {
                if (_array[i] < min) min = _array[i];
            }
            return min;
        }

        public int GetMaxElementIndex()
        {
            int max = _array[0];
            int index = 0;
            for (int i = 0; i < LengthOfList; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public int GetMinElementIndex()
        {
            int min = _array[0];
            int index = 0;
            for (int i = 0; i < LengthOfList; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public ArrayList SortAscending()
        {
            ArrayList newList = new ArrayList();
            int[] newArray = new int[_array.Length];
            Array.Copy(_array, newArray, _array.Length);
            int start;
            for(int i=0;i<LengthOfList;i++)
            {
                start = i;
                for(int j=start;j<LengthOfList;j++)
                {
                    if(newArray[j]<newArray[i])
                    {
                        int cur = newArray[i];
                        newArray[i] = newArray[j];
                        newArray[j] = cur;
                    }
                }
            }

            for(int i=0;i<LengthOfList;i++)
            {
                newList.Add(newArray[i]);
            }

            return newList;
        }


        public ArrayList SortDescending()
        {
            ArrayList newList = new ArrayList();
            int[] newArray = new int[_array.Length];
            Array.Copy(_array, newArray, _array.Length);
            int start;
            for (int i = 0; i < LengthOfList; i++)
            {
                start = i;
                for (int j = start; j < LengthOfList; j++)
                {
                    if (newArray[j] > newArray[i])
                    {
                        int cur = newArray[i];
                        newArray[i] = newArray[j];
                        newArray[j] = cur;
                    }
                }
            }

            for (int i = 0; i < LengthOfList; i++)
            {
                newList.Add(newArray[i]);
            }

            return newList;
        }

        public void PrintTheList()
        {
            string n = "";
            for(int i=0;i<LengthOfList;i++)
            {
                n += _array[i] + " ";
            }
            Console.WriteLine(n);
        }


        public override bool Equals(object obj)         //для тестов
        {
            return true;
        }


        private void RiseSize(int amountOfBlankElements=1)
        {
            int newLength = _array.Length;
            while (newLength<_array.Length+amountOfBlankElements)
            {
                newLength = (int)(newLength * 1.33d);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }


        private void ReduceSize()
        {
            int newLength = (int)(_array.Length * 0.66d);
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, newLength);
            _array = newArray;
        }
    }
}
