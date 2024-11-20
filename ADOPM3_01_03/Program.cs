using System;

namespace ADOPM3_01_03
{
    class Program
    {
        /// <summary>
        /// Makes a division with x and y. Both x and y must not be equal to 0. 
        /// Otherwise DivideByZeroException is thrown
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static double SafeDivision(double x, double y)
        {
            if ((x, y) == (0, 0))
                throw new DivideByZeroException("What a strange division");
            if (y == 0)
                throw new DivideByZeroException();
            return x / y;
        }
        static void Main(string[] args)
        {
            // Input for test purposes. Change the values to see
            // exception handling behavior.
            double a = 10, b = 0;
            double result;

            try
            {
                Console.WriteLine("Code in the try block");
                result = SafeDivision(a, b);
                Console.WriteLine($"{a} divided by {b} = {result}");
            }
            catch (DivideByZeroException ex) when (ex.Message == "What a strange division")
            {
                Console.WriteLine("Attempted divide by zero.");
                Console.WriteLine($"Message: {ex.Message}");
                //throw; // test rethrow same exception
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted divide by zero.");
            }
            catch (Exception) { }
            finally
            {
                Console.WriteLine("Code here will always be executed");
            }
        }

        //Exercises:
        //1.    run the code with a=0 and test the exception filter
        //2.    in the exception filter rethrow the exception. What happend to code in the finally clause?
        //3.    Explore the exception object properties such as StackTrace, Message and InnerException
    }
}
