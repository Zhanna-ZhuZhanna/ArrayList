using System;
using DataStructures;
namespace ConsoleProjectForDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list =new ArrayList();
            Console.WriteLine("The length of list is "+list.Length);
            list.Add(100);
            Console.WriteLine("The length of list is "+list.Length);
            Console.WriteLine(list.ToString);
        }
    }
}
