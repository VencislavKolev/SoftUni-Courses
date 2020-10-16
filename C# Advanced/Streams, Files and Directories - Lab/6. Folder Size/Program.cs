using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"C:\Users\Asus\source\repos\C# Advanced\Streams, Files and Directories - Lab\6. Folder Size\TestFolder");
            double sum = 0;
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }
            //Bytes -> KB -> MB
            sum = sum / 1024 / 1024;
            File.WriteAllText("result.txt", sum.ToString());
        }
    }
}
