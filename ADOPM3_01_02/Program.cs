using System;

namespace ADOPM3_01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Boxed value type (ox1 and ox2) becomes reference types, BUT does NOT behave as normal
            //reference types as
            //  - a copies of the value type is boxed into the heap and unboxed into the stack
            //  - modifications of the instance on the heap i not allowed. Compiler error
            //Therefore, a boxed type still behaves as a value type

            //Example: int is a simple, classic value type
            int i1 = 9;
            int i2 = 7;

            i1 = i2;    // deep copy, i.e. the content
            i2 = 10;
            Console.WriteLine($"i1: {i1}, i2: {i2}"); //7,10 expected value type behaviour

            //Boxing the int - it is now of reference type object
            object bi1 = i1;
            object bi2 = i2;

            // shallow copy, i.e. the reference only
            //ox1 and ox2 refer to the same instance on the heap
            bi1 = bi2;
            Console.WriteLine($"bi1: {bi1}, bi2: {bi2}");

            //((int)(bi2)) = 20; //Compiler error when trying to change the boxed object on the heap
            bi2 = 20;            //ox2 now refers to a new boxed instance on the heap
            Console.WriteLine($"bi1: {bi1}, bi2: {bi2}"); // 10, 20 expected value type behaviour

            //Unbox the bi1, bi2 (variables of reference type) copies back into value types
            //object must be casted to the boxed type
            int ubi1 = (int)bi1;           
            int ubi2 = (int)bi2;
            Console.WriteLine($"ubi1: {ubi1}, ubi2: {ubi2}"); // 10, 20

            //Unbox the ox1, ox2 (variables of reference type) and cast it into a float
            float ubif1 = (float)(int)bi1;
            float ubif2 = (float)(int)bi2;
            Console.WriteLine($"ubif1: {ubif1:N2}, ubif2: {ubif2:N2}"); // 10.00, 20.00
        }
    }
}
