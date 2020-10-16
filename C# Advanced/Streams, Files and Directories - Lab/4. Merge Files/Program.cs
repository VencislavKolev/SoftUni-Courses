using System;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileOnePath = Path.Combine("04. Merge Files", "FileOne.txt");
            var fileTwoPath = Path.Combine("04. Merge Files", "FileTwo.txt");
            string[] readFirst = File.ReadAllText(fileOnePath).Split();
            string[] readSecond = File.ReadAllText(fileTwoPath).Split();
            File.WriteAllText("result.txt", "");
            for (int i = 0; i < readFirst.Length; i++)
            {
                File.AppendAllText("result.txt", readFirst[i] + Environment.NewLine + readSecond[i]);
            }
        }
    }
}
