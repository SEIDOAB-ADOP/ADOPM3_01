using System;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace ADOPM3_01_13
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = "quick brown fox jumps over the lazy dog and catches the lazy white rabbit .".Split(" ");
            Random rand = new Random();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1_000_000; i++)
               sb.Append(words[rand.Next(words.Length)] + " ");

            Console.WriteLine(sb.Length);
            Console.WriteLine(fname("Example4_13_uncompressed.text"));    

            using (Stream s = File.Create(fname("Example4_13_uncompressed.text")))
            using (TextWriter w = new StreamWriter(s))
                w.Write(sb);

            Console.WriteLine(new FileInfo(fname("Example4_13_uncompressed.text")).Length);
            
            using (Stream s = File.Create(fname("Example4_13_compressed.zip")))
            using (Stream ds = new GZipStream(s, CompressionMode.Compress))
            using (TextWriter w = new StreamWriter(ds))
                w.Write(sb);

            Console.WriteLine(new FileInfo(fname("Example4_13_compressed.zip")).Length);

            
            using (Stream s = File.OpenRead(fname("Example4_13_compressed.zip")))
            using (Stream ds = new GZipStream(s, CompressionMode.Decompress))
            using (TextReader r = new StreamReader(ds))
            {
                var sReadback = r.ReadToEnd();
                Console.Write(sReadback.Length);
            }
            

            static string fname(string name)
            {
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                documentPath = Path.Combine(documentPath, "ADOP", "Examples");
                if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
                return Path.Combine(documentPath, name);
            }
        }

        //Exercises:
        //1.    Modify above code to compress using GZip and BrotliStream algorithms
        //2.    Modify code to compress a randomly initialized byte array of 10k byte
    }
}
