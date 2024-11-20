using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace ADOPM3_01_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string startPath = Path.Combine(documentPath, "SeedGenerator");
            string zipFile = Path.Combine(documentPath, "SeedGenerator.zip");
            string extractPath = Path.Combine(documentPath, "ExtractSeedGenerator");

            if (File.Exists(zipFile)) File.Delete(zipFile);
            ZipFile.CreateFromDirectory(startPath, zipFile);
            Console.WriteLine($"Zip Created: {zipFile}");

            if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true);
            ZipFile.ExtractToDirectory(zipFile, extractPath);
            Console.WriteLine($"Zip Extracted: {extractPath}");

            //OpenFileExplorer(startPath);

            //ZipArchive
            Console.WriteLine();
            using (ZipArchive archive = ZipFile.OpenRead(zipFile))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    Console.WriteLine(entry.FullName);
                }
            }
        }

        private static void OpenFileExplorer(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = FileExplorer()
                };

                Process.Start(startInfo);
            }
            else
            {
                Console.WriteLine(string.Format("{0} Directory does not exist!", folderPath));
            }
        }

        private static string FileExplorer()
        {
            if (OperatingSystem.IsMacOS) return "open";

            //assume Windows platform.
            //Need to check app in Linux
            return "explorer";
        }

        //Ask the .NET runtime on which platfrom it is running
        private static class OperatingSystem
        {
            public static bool IsWindows =>
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            public static bool IsMacOS =>
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            public static bool IsLinux =>
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }
    }
        //Exercises:
        //1.    Use ZipArchive to iterate over "Examples.zip" and printout content. 
        //2.    Use ZipCreate to add a file to "Examples.zip", Use ZipArchive to confirm that it is included in the zip file.
}
