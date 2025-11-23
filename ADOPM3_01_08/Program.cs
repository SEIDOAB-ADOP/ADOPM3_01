using System;
using System.IO;
using System.Linq;

namespace ADOPM3_01_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fname("Example4_08.bin")); //location of the file
 			using (Stream s = new FileStream(fname("Example4_08.bin"), FileMode.Create))
			{
				Console.WriteLine(s.CanRead);       // True
				Console.WriteLine(s.CanWrite);      // True
				Console.WriteLine(s.CanSeek);       // True

				s.WriteByte(101);
				s.WriteByte(102);
				byte[] block = { 1, 2, 3, 4, 5 };
				s.Write(block, 0, block.Length);     // Write block of 5 bytes

				//Write a string as bytes - needs text encoding
				byte[] block2 = System.Text.Encoding.Unicode.GetBytes("Hello World");
				s.Write(block2, 0, block2.Length);

				//Write a couple of numeric type as bytes
				long i1 = int.MaxValue;
				byte[] i1_block = BitConverter.GetBytes(i1);
				s.Write(i1_block, 0, i1_block.Length);

				double d1 = double.MaxValue;
				byte[] d1_block	= BitConverter.GetBytes(d1);
				s.Write(d1_block, 0, d1_block.Length);

				//Everything is written
				Console.WriteLine(s.Length);         // 29
				Console.WriteLine(s.Position);       // 29

				//Move back to the start
				s.Position = 0;                      

				//Read the stream back in the right order
				Console.WriteLine(s.ReadByte());     // 101
				Console.WriteLine(s.ReadByte());     // 102

				// Read from the stream back into the block array:
				Console.WriteLine(s.Read(block, 0, block.Length));   // 5

				// Read the string converted to bytes
				Console.WriteLine(s.Read(block2, 0, block2.Length));   // 22

				// Read the numeric types converted to bytes
				Console.WriteLine(s.Read(i1_block, 0, i1_block.Length));   // 22
				Console.WriteLine(s.Read(d1_block, 0, d1_block.Length));   // 22


				// Assuming the last Read returned 5, we'll be at
				// the end of the file, so Read will now return 0:
				Console.WriteLine(s.Read(block, 0, block.Length));   // 0

				//As a final touch
				//Convert back the byte[] to the string and to the two numeric types
				string s2 = System.Text.Encoding.Unicode.GetString(block2);
				int i2 = BitConverter.ToInt32(i1_block);
				double d2 = BitConverter.ToDouble(d1_block);

				Console.WriteLine(s2);
                Console.WriteLine(i2);
				Console.WriteLine(d2);
			}

			static string fname(string name)
			{
				//LocalApplicationData is a good place to store a temporary file
				var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				documentPath = Path.Combine(documentPath, "Martin", "M3");

				if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);

				return Path.Combine(documentPath, name);
			}
		}
	}
}
