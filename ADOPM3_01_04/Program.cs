using System;

namespace ADOPM3_01_04
{
    class Program
    {
        public class DatabaseObject
        {
            public string someDatabaseDetails { get; set; }
        }
        public class MyOwnException : Exception
        {
            public DatabaseObject DBO { get; private set; }
            public MyOwnException(string message, DatabaseObject dbo) : base(message)
            {
                DBO = dbo;
            }
            public MyOwnException(string message, Exception inner) : base(message, inner) { }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    //Exercises:
    //1.    In BOOPM3_07_03 make a custom exception for a 0 by 0 division and handle it
}
