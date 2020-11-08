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
            list.PrintTheList();
            Console.WriteLine("The length of list is " + list.LengthOfList);
            list.AddElementToTheBeginning(50);
            list.PrintTheList();
            list.AddElementToTheIndex(-10, 1);
            list.PrintTheList();
            ArrayList list2 = list.SortAscending();
            list2.PrintTheList();
            ArrayList list3 = list.SortDescending();
            list3.PrintTheList();
        }
    }
}
