using System;
using DataStructures;
using DataStructures.DLList;
namespace ConsoleAppForDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList list = new DoubleLinkedList(new int[] { 1, 2, 3, 4 });
            Console.WriteLine(list.ToString());
            Console.WriteLine();
            Console.WriteLine(list.Length);

        }
    }
}
