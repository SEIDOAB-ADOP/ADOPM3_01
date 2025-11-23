namespace ADOPM3_01_02d
{
    class Program
    {
        public interface IA { public int iVal { get; set; } }

        public struct AStruct : IA { public int iVal { get; set; } }
        public class AClass : IA { public int iVal { get; set; } }

        static void Main(string[] args)
        {
            AClass c1 = new AClass { iVal = 9 };
            AStruct s1 = new AStruct { iVal = 7 };

            IA oc1 = c1;  //Casting (not boxing) the reference type to IA
            IA os1 = s1;  //Boxing the value type to IA

            ((AClass)(oc1)).iVal = 20;         //Allowed as it is casted
            //((AStruct)(os1)).iVal = 20;      //NOT Allowed as it is boxed
            os1 = new AStruct { iVal = 20 };   //A new instance MUST be created

            //Confusions using IA
            IA myObject = oc1;
            ((AClass)(myObject)).iVal = 20;        //Allowed as it is casted

            myObject = os1;
            //((AStruct)(myObject)).iVal = 20;     //NOT Allowed as it is boxed
            myObject = new AStruct { iVal = 20 };  //A new instance MUST be created
        }
    }
}

