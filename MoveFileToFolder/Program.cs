using System;
using System.IO;

namespace MoveFileToFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(1, 1);
            Console.WriteLine($"Begin...");
            var sourcefolder = System.Configuration.ConfigurationManager.AppSettings["sourcefolder"];
            var targetfolder = System.Configuration.ConfigurationManager.AppSettings["targetfolder"];
            var folder = new DirectoryInfo(sourcefolder);
            Console.SetCursorPosition(1, 2);
            Console.WriteLine($"folder.FullName: {folder.FullName}");
            //
            if (folder.Exists)
            {
                Console.SetCursorPosition(1, 3);
                Console.WriteLine($"folder.Exists: {folder.Exists.ToString()}");
                var files = folder.EnumerateFiles("*.*");
                foreach (var f in files)
                {
                    var dateFolder = f.LastWriteTime;
                    var targetdatefolder = $@"{targetfolder}{dateFolder.Year}.{dateFolder.Month:00}\";
                    //
                    var fullfolderInfo = new DirectoryInfo(targetdatefolder);
                    if (!fullfolderInfo.Exists)
                        Directory.CreateDirectory(targetdatefolder);
                    //
                    Console.SetCursorPosition(1, 5);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(1, 5);
                    Console.WriteLine($@"{sourcefolder}{f.Name} to {targetdatefolder}{f.Name}");
                    //
                    File.Move($"{sourcefolder}{f.Name}", $@"{targetdatefolder}{f.Name}");   
                }
                Console.SetCursorPosition(1, 7);
                Console.WriteLine($"That's all folks!");
            }
            else
            {
                Console.SetCursorPosition(1, 3);
                Console.WriteLine($"folder.Exists: {folder.Exists.ToString()}");
            }
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("press any key to exit!");
            Console.ReadKey();
        }
    }
}
