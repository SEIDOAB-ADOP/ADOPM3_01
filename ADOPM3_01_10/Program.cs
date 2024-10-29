using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace ADOPM3_01_10
{
    class Program
    {
        static void Main(string[] args)
        {
			
			var t2 = new Stopwatch();
			t2.Start();

			//var sbBook = ""; //
			var sbBook = new StringBuilder();
			for (int i = 0; i < 1_000_000; i++)
			{
                //sbBook += "Hej hopp! ";
                sbBook.Append("Hej hopp! ");
			}

			Console.WriteLine(sbBook.Length);

			t2.Stop();
			Console.WriteLine($"{ t2.ElapsedMilliseconds} ms");
			

			
			string filename = fname("BestSeller.txt");

			using (FileStream fs = File.Create(filename))
			using (TextWriter writer = new StreamWriter(fs))
			{
				writer.WriteLine(filename);
				writer.WriteLine(sbBook);
			}

			/*
			using (FileStream fs = File.OpenRead(fname("Example4_10.txt")))
			using (TextReader reader = new StreamReader(fs))
			{

				string s = null;
                while ((s = reader.ReadLine()) != null)
				{
                    Console.WriteLine(s);
                }
			}
			*/
			

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
//Exercises:
//1. Use StringBuilder to create a book consisting of 100_000 words n random order from the
//   sentence "The quick brown fox catches the white rabbit . ."
//2. Write to a textfile using streams


