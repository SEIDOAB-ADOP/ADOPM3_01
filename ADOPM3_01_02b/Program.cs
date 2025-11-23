namespace ADOPM3_01_02b
{
    class Program
    {
        public class AClass { public int iVal; }
        static void Main(string[] args)
        {
            //Refresh classic reference type behaviour
            AClass c1 = new AClass { iVal = 9 };
            AClass c2 = new AClass { iVal = 7 };

            //casting (not boxing) the reference type to object
            object oc1 = (object) c1;
            object oc2 = (object) c2;  // shallow copy, i.e. the reference only

            oc1 = oc2;  //oc1 and oc2 refer to the same instance on the heap
            Console.WriteLine($"oc1: {((AClass)(oc1)).iVal}, oc2: {((AClass)(oc2)).iVal}");

            ((AClass)(oc2)).iVal = 20;  //This is the fundamental instance modification that is not possible in boxing
            Console.WriteLine($"oc1: {((AClass)(oc1)).iVal}, oc2: {((AClass)(oc2)).iVal}");

            //cast object back to AClass, 
            AClass ubc2 = (AClass)oc2;
            Console.WriteLine($"ubc2: {((AClass)(ubc2)).iVal}");
            Console.WriteLine($"oc2: {((AClass)(oc2)).iVal}");
            Console.WriteLine($"c2: {((AClass)(c2)).iVal}");
        }
    }
}
