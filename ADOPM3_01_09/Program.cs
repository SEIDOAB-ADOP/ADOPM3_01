using System;
using System.IO;

namespace ADOPM3_01_09
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = fname("Example4_09.txt");
            Console.WriteLine(filename); //location of the file

            File.WriteAllText(filename, $"{filename}\n");
            File.AppendAllText(filename, "Hello World\n");
            File.AppendAllText(filename, $"{int.MaxValue.ToString()}\n");
            File.AppendAllText(filename, double.MaxValue.ToString());


            Console.WriteLine(File.ReadAllText(fname("Example4_09.txt")));

            static string fname(string name)
            {
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                documentPath = Path.Combine(documentPath, "ADOP", "Examples");
                if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
                return Path.Combine(documentPath, name);
            }
        }
    }
}
