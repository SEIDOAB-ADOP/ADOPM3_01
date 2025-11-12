using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace ADOPM3_01_07
{
    class Program
    {
		// HttpClient is intended to be instantiated once and reused throughout the life of an application
		private static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
			string s = null;

			//Using HttpClient (reusable static instance) with some Exception handling
			try 
			{ 
				s = await httpClient.GetStringAsync("https://www.microsoft.com/"); 
			}
			catch (HttpRequestException ex)
			{
				if (ex.InnerException is System.Net.Sockets.SocketException socketEx && 
				    socketEx.SocketErrorCode == System.Net.Sockets.SocketError.HostNotFound)
					Console.WriteLine("Bad domain name");
				else
					throw;     // Can't handle other sorts of HttpRequestException, so rethrow
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
	//1.	Change the domain name in order to generate different Http Exceptions (www.microsoft1.com and www.m.com). 
	//		Explain what happens
	//2.	Try to delete the file File.Delete() in the if statement. Explain what happens and why
}
