namespace ADOPM3_01_02c
{
    class Program
    {
        public struct AStruct { public int iVal; }
        public class AClass { public int iVal; }
        static void Main(string[] args)
        {
            AClass c1 = new AClass { iVal = 9 };
            AStruct s1 = new AStruct { iVal = 7 };

            object oc1 = (object)c1;  //Casting (not boxing) the reference type to object
            object os1 = (object)s1;  //Boxing the value type to object

            ((AClass)(oc1)).iVal = 20;      //Allowed as it is casted
            //((AStruct)(os1)).iVal = 20;   //NOT Allowed as it is boxed
            os1 = new AStruct { iVal=20 };  //A new instance MUST be created


            //Confusions using object
            object myObject = oc1;
            ((AClass)(myObject)).iVal = 20;        //Allowed as it is casted

            myObject = os1;
            //((AStruct)(myObject)).iVal = 20;     //NOT Allowed as it is boxed
            myObject = new AStruct { iVal = 20 };  //A new instance MUST be created
        }
    }
}

