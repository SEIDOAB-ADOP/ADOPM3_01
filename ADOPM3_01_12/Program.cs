using System;
using System.IO;

namespace ADOPM3_01_12
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fname("Example4_12.bin"), FileMode.Create)))
            {
                writer.Write(1.250F);
                writer.Write(@"c:\Temp");
                writer.Write(new byte[1000]);
                writer.Write(10);
                writer.Write(true);
            }
            if (File.Exists(fname("Example4_12.bin")))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fname("Example4_12.bin"), FileMode.Open)))
                {
                    Console.WriteLine(reader.ReadSingle()); // 1,25
                    Console.WriteLine(reader.ReadString()); // c:\Temp
                    byte[] data = reader.ReadBytes(1000);
                    Console.WriteLine(reader.ReadInt32()); // 10
                    Console.WriteLine(reader.ReadBoolean()); // true
                }
            }

            static string fname(string name)
            {
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                documentPath = Path.Combine(documentPath, "AOOP2", "Examples");
                if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
                return Path.Combine(documentPath, name);
            }
        }
    }
}
