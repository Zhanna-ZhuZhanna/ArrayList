using System;
using System.Net.NetworkInformation;

namespace DataStructures
{
    public class ArrayList:IList
    {
        private int[] _array;   
        public int LengthOfList { get; private set; }
        public ArrayList()
        {
            _array = new int[3];
            LengthOfList = 0;
        }
        public ArrayList(int value)
        {
            _array = new int[3];
            _array[0] = value;
            LengthOfList = 1;
        }
        public ArrayList(int[] array)
        {
                _array = new int[array.Length +3];
                Array.Copy(array, _array, array.Length);
                LengthOfList = array.Length;
        } 

        public int this[int index]
        {
            get
            {
                if (index < 0) throw new Exception("Index have to be grater than zero!");
                if (index >= LengthOfList) throw new Exception("Index is out of range!");
                return _array[index];
            }
            set
            {
                if (index < 0) throw new Exception("Index have to be grater than zero!");
                if (index >= LengthOfList) throw new Exception("Index is out of range!");
                _array[index] = value;
            }
        }
        public void Add(int[] values)
        {
            for(int i=0;i<values.Length;i++)
            {
                if (LengthOfList >= _array.Length)
                {
                    RiseSize();
                }
                _array[LengthOfList] = values[i];
                LengthOfList++;
            }
           
        }
        public void ReverseTheList()
        {
            for (int i=0;i<LengthOfList/2;i++)
            {
                int cur = _array[i];
                _array[i] = _array[LengthOfList-1 - i];
                _array[LengthOfList-1 - i] = cur;
            }
        }
        public void AddToTheBeginning(int[] values)
        {
            if (LengthOfList>=_array.Length)
            {
                RiseSize();
            }
            int[] newArray = new int[_array.Length+values.Length];
            Array.Copy(values, newArray, values.Length);
            Array.Copy(_array,0,newArray,values.Length,_array.Length);
            _array = newArray;
            LengthOfList+=values.Length;
        }

        public void AddToTheIndex(int[] values, int index)
        {
            if (index < 0) throw new Exception("Index can't be less than zero!");
            if (index > LengthOfList) throw new Exception("Index is out of the length of the list!");
            if (LengthOfList >= _array.Length)
            {
                RiseSize();
            }
            int[] newArray = new int[_array.Length + values.Length];
            int i = 0;
            do
            {
                if (i < index )
                {
                    newArray[i] = _array[i];
                }
                else if(i >= values.Length + index)
                {
                    newArray[i] = _array[i - values.Length];
                }
                else 
                {
                    newArray[i] = values[i - index];
                }
                i++;
            } while (i < newArray.Length);
            _array = newArray;
            LengthOfList+=values.Length;
        }

        public void Remove(int n=1)
        {
            if (n > LengthOfList) throw new Exception("The amount of elements to remove is grater than the amount of elements in the array!");
            if (n < 0) throw new Exception("The amount of elements to remove have to be grater than zero!");
            if (LengthOfList == 0) throw new Exception("There is nothing to remove");
            while (n>0)
            { 
            _array[LengthOfList - 1] = 0;
            LengthOfList--;
                n--;
            }
            if (LengthOfList<_array.Length/2)
            {
                ReduceSize();
            }
        }

        public void RemoveFromBeginning(int n = 1)
        {
            if (LengthOfList == 0) throw new Exception("There is nothing to remove");
            if (n > LengthOfList) throw new Exception("The amount of elements to remove is grater than the amount of elements in the array!");
            if (n < 0) throw new Exception("The amount of elements to remove have to be grater than zero!");
                for (int i = n; i < LengthOfList; i++)
                {
                    _array[i - n] = _array[i];
                }
                LengthOfList-=n;               
                if (LengthOfList < _array.Length / 2)
                {
                    ReduceSize();
                }
        }
        public void RemoveFromIndex(int index, int n=1)
        {
            if (n > LengthOfList) throw new Exception("The amount of elements to remove is grater than the amount of elements in the array!");
            if (n < 0) throw new Exception("The amount of elements to remove have to be grater than zero!");
            if (LengthOfList == 0) throw new Exception("There is nothing to remove");
            if (index < 0) throw new Exception("Index can't be less than zero!");
            if (index >= LengthOfList) throw new Exception("Index is out of the length of the list!");
            if (n + index > LengthOfList) throw new Exception("You can't delete so many elements from this index!");
            for(int i=index+n;i<LengthOfList;i++)
            {
                _array[i - n] = _array[i];
            }
            LengthOfList -= n;
            if (LengthOfList < _array.Length / 2)
            {
                ReduceSize();
            }

        }

        public int GetIndexByValue(int value)
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
            int[] newArray = new int[LengthOfList];
            Array.Copy(_array, newArray, LengthOfList);
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
            ArrayList newList = new ArrayList(newArray);

            return newList;
        }

        public ArrayList SortDescending()
        {
            int[] newArray = new int[LengthOfList];
            Array.Copy(_array, newArray, LengthOfList);
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
            ArrayList newList = new ArrayList(newArray);
            return newList;
        }

        public void RemoveAllElementsByValue(int value)
        {
            int amount = 0;
            for (int i = 0; i < LengthOfList; i++)
            {
                if (_array[i] == value) amount++;
            }
           if(amount==0)  throw new Exception("There are not elements with value you are looking for");
            while (amount > 0)
            {
                for (int i = 0; i < LengthOfList; i++)
                {
                    if (_array[i] == value)
                    {
                        RemoveFromIndex(i);
                        amount--;
                        break;
                    }
                }
            }
            
        }
        public void RemoveFirstElementByValue(int value)
        {
            bool check = true;
            for(int i=0;i<LengthOfList;i++)
            {
                if(_array[i]==value)
                {
                    RemoveFromIndex(i);
                    check = false;
                    break;
                }
            }
            if(check) throw new Exception("There are not elements with value you are looking for");
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
            ArrayList objList = (ArrayList)obj;
            if(objList.LengthOfList!=LengthOfList)
            {
                return false;
            }
            else
            {
                for(int i=0;i<LengthOfList;i++)
                {
                    if (objList[i] != this[i]) return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            for(int i=0;i<LengthOfList;i++)
            {
                s += this[i] + "; ";
            }
            return s;
        }

        private void RiseSize(int amountOfBlankElements=1)
        {
            int newLength = _array.Length;
            while (newLength<_array.Length+amountOfBlankElements)
            {
                newLength = (int)(newLength * 1.4d);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }


        private void ReduceSize()
        {
            int newLength = (int)(_array.Length * 0.7d);
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, newLength);
            _array = newArray;
        }
    }
}
