using System;
using System.Net;
using System.IO;

namespace ADOPM3_01_07
{
    class Program
    {
        static void Main(string[] args)
        {
			string s = null;

			//Using statement with some Exception handling
			using (WebClient wc = new WebClient())
			{
				try { s = wc.DownloadString("http://www.microsoft.com/"); }
				catch (WebException ex)
				{
					if (ex.Status == WebExceptionStatus.NameResolutionFailure)
						Console.WriteLine("Bad domain name");
					else
						throw;     // Can’t handle other sorts of WebException, so rethrow
				}
			}

			//s now contains the html markup from the website
			File.WriteAllText(fname("Example4_07.txt"), s);
			if (File.Exists(fname("Example4_07.txt")))
			{
				//readback using StreamReader in a using declaration
				using var reader = File.OpenText(fname("Example4_07.txt")); //Using declaration
				Console.WriteLine(reader.ReadToEnd());

			}

			//using var reader = ... is now out of scope and the using declaration has closed the stream


			//Local helper method to ge platform independant paths
			static string fname(string name)
			{
				//LocalApplicationData is a good place to store a temporary file
				var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				documentPath = Path.Combine(documentPath, "AOOP2", "Examples");
				if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
				return Path.Combine(documentPath, name);
			}
		}
	}

	//Exercise:
	//1.	Change the domain name in order to generate different Web Exceptions (www.microsoft1.com and www.m.com. 
	//		Explain what happens
	//2.	Try to delete the file File.Delete() in the if statement. Explain what happens and why
}
