using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Asus\Desktop\Diplomna rabota";
            Dictionary<string, Dictionary<string, long>> info = new Dictionary<string, Dictionary<string, long>>();
            string[] files = Directory.GetFiles(path);
            foreach (var filePath in files)
            {
                string fileName = filePath
                    .Split(@"\")
                    .Last();
                string extension = fileName.Split('.').Last();
                if (!info.ContainsKey(extension))
                {
                    info.Add(extension, new Dictionary<string, long>());
                }
                if (!info[extension].ContainsKey(fileName))
                {
                    FileInfo file = new FileInfo(filePath);
                    var size = file.Length;
                    info[extension].Add(fileName, size);
                }
            }
            using (StreamWriter writer = new StreamWriter("Output.txt"))
            {
                foreach (var ext in info.OrderBy(x => x.Key))
                {
                    string extName = '.' + ext.Key;
                    writer.WriteLine(extName);
                    Console.WriteLine(extName);
                    foreach (var kvp in ext.Value.OrderBy(x => x.Value))
                    {
                        string currFile = kvp.Key;
                        double sizeInMb = kvp.Value * 1.0 / 1024;
                        writer.WriteLine($"--{currFile} - {sizeInMb:f3}Kb");
                        Console.WriteLine($"--{currFile} - {sizeInMb:f3}Kb");
                    }
                }
            }

        }
    }
}
