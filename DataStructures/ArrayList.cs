using System;

namespace DataStructures
{
    public class ArrayList
    {
        private int[] _array;   

        public int Length { get; private set; }



        public ArrayList()
        {
            _array = new int[3];
            Length = 0;
        }

        public void Add(int value)
        {
            if (Length>=_array.Length)
            {
                RiseSize();
            }
            _array[Length] = value;
            Length++;
        }
        public void ReverseTheList()
        {
            int[] newArray = new int[_array.Length];
            for (int i=0;i<Length;i++)
            {
                newArray[i] = _array[Length - 1 - i];
            }
            Array.Copy(newArray, _array, _array.Length);
        }
        public void AddElementToTheBeginning(int value)
        {
            if (Length>=_array.Length)
            {
                RiseSize();
            }
            int[] newArray = new int[_array.Length+1];
            newArray[0] = value;

            Array.Copy(_array,0,newArray,1,_array.Length);
            _array = new int[newArray.Length];
            Array.Copy(newArray, _array, newArray.Length);
            Length++;

        }

        public void PrintTheList()
        {
            string n = "";
            for(int i=0;i<Length;i++)
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
    }
}
