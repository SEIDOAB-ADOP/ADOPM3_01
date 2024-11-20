using System;
using System.Collections;
using System.Collections.Generic;

namespace ADOPM3_01_01
{
    class Program
    {
        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public string Year { get; set; }

            // Override ToString()
            public override string ToString() => $"Make:{Make} Model:{Model} Year:{Year}";

        }
        static void Main(string[] args)
        {
            // Loosely typed Stack - using Object Type
            Stack myStack = new Stack();
            myStack.Push(new Car { Make = "BMW", Model = "C Class", Year = "2020" });
            myStack.Push("A string of some kind");
            myStack.Push(5); //push an integer
            myStack.Push((false, 2.5F));

            // Displays the object types of the pops
            Console.WriteLine(myStack.Pop().GetType()); // System.ValueTuple
            Console.WriteLine(myStack.Pop().GetType()); // System.Int32
            Console.WriteLine(myStack.Pop().GetType()); // System.String
            Console.WriteLine(myStack.Pop().ToString()); // Make:BMW Model:C Class Year:2020

            Console.WriteLine();
            // Strongly typed Stack - using Generics
            Stack<Car> myStack1 = new Stack<Car>();
            myStack1.Push(new Car { Make = "BMW", Model = "C Class", Year = "2020" });
            //myStack1.Push("A string of some kind"); // Compile Error

            // Displays the object types of the pops
            Console.WriteLine(myStack1.Pop().ToString()); // Make:BMW Model:C Class Year:2020
            
        }
    }
    //Exercises:
    //1.    Create a loosely typed array, populate it with various types and iterate over it making a printout of the 
    //      Value, Type and Hashcodes of the elemnts in the array.
}
