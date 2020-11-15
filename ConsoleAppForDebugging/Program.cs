using System;
using DataStructures;
namespace ConsoleAppForDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList(new int[] {1,2,3,4,5 });
            list.PrintTheList();
            Console.WriteLine("The length of list is " + list.LengthOfList);
           
            //list.PrintTheList();
            //Console.WriteLine("The length of list is " + list.LengthOfList);
            //list.RemoveFromBeginning();
            //list.PrintTheList();
            //Console.WriteLine("The length of list is " + list.LengthOfList);
            //list.RemoveFromBeginning(4);
            //list.PrintTheList();
            //Console.WriteLine("The length of list is " + list.LengthOfList);
        }
    }
}
