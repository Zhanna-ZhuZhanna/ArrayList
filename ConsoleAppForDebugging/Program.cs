using System;
using DataStructures;
namespace ConsoleAppForDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            Console.WriteLine("The length of list is " + list.LengthOfList);
            list.Add(100);
            list.Add(89);
            list.Add(100);
            list.Add(100);
            list.PrintTheList();
            Console.WriteLine("The length of list is " + list.LengthOfList);
            list.AddElementToTheBeginning(50);
            list.PrintTheList();
            list.AddElementToTheIndex(-10, 1);
            list.AddElementToTheBeginning(100);
            list.PrintTheList();
            list.RemoveFirstElementByValue(50);
            Console.WriteLine("The length of list is " + list.LengthOfList);
            list.PrintTheList();
        }
    }
}
