using System;

namespace ADOPM3_01_02a
{
    class Program
    {
        public struct AStruct { public int iVal; }
        static void Main(string[] args)
        {
            //Boxed value type (ox1 and ox2) becomes reference types, BUT does NOT behave as normal
            //reference types as
            //  - a copies of the value type is boxed into the heap and unboxed into the stack
            //  - modifications of the instance on the heap i not allowed. Compiler error
            //Therefore, a boxed type still behaves as a value type

            //Example: AStruct is a complex, classic value type
            AStruct s1 = new AStruct { iVal = 9 };
            AStruct s2 = new AStruct { iVal = 7 };

            s1 = s2;    // deep copy, i.e. the content
            s2.iVal = 10;
            Console.WriteLine($"s1: {s1.iVal}, s2: {s2.iVal}"); //7,10 expected value type behaviour

            
            //Boxing the struct - it is now of reference type object
            object bs1 = s1;
            object bs2 = s2;  // shallow copy, i.e. the reference only

            bs1 = bs2;  //ox1 and ox2 refer to the same instance on the heap
            Console.WriteLine($"bs1: {((AStruct)(bs1)).iVal}, bs2: {((AStruct)(bs2)).iVal}");

            
            //((AStruct)(bs2)).iVal = 20;     //Compiler error when trying to change the boxed object on the heap
            bs2 = new AStruct { iVal = 20 };  //bs2 now refers to a new boxed instance on the heap
            Console.WriteLine($"bs1: {((AStruct)(bs1)).iVal}, bs2: {((AStruct)(bs2)).iVal}"); // 10, 20 expected value type behaviour

            //Unbox the bi1, bi2 (variables of reference type) copies back into value types
            //object must be casted to the boxed type
            AStruct ubs1 = (AStruct)bs1;
            AStruct ubs2 = (AStruct)bs2;
            Console.WriteLine($"ubs1: {((AStruct)(ubs1)).iVal}, ubs2: {((AStruct)(ubs2)).iVal}"); // 10, 20
            
        }
    }
}
