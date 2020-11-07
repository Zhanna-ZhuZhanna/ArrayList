using System;
using DataStructures;
namespace ConsoleAppForDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            Console.WriteLine("The length of list is " + list.Length);
            list.Add(100);
            list.PrintTheList();
            Console.WriteLine("The length of list is " + list.Length);
            list.AddElementToTheBeginning(50);
            list.PrintTheList();
        }
    }
}
