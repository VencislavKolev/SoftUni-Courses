using System;
using System.Diagnostics;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = 4;
            var path = Path.Combine("SliceMe.txt");
            var fileSize = new FileInfo("sliceMe.txt").Length;
            //   var path = Path.Combine(@"C:\Users\Asus\dummy.txt");
            //   var fileSize = new FileInfo(@"C:\Users\Asus\dummy.txt").Length;
            int sizePerFile = (int)Math.Ceiling(fileSize / (decimal)parts);
            //using (FileStream read = new FileStream("sliceMe.txt", FileMode.Open))
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (FileStream read = new FileStream(path, FileMode.Open))
            {
                for (int i = 0; i < parts; i++)
                {
                    int currFileSize = sizePerFile;
                    using (FileStream writer = new FileStream($"File {i + 1}.txt", FileMode.OpenOrCreate))
                    {
                        int readBytes = int.MaxValue;
                        while (readBytes != 0 && currFileSize >= 0)
                        {
                            byte[] buffer = new byte[4096];
                            readBytes = read.Read(buffer, 0, buffer.Length);
                            currFileSize -= readBytes;
                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
        }
    }
}
