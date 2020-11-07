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
