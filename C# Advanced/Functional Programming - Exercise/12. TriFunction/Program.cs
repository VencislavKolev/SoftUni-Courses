using System;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split();

            Func<string, int, bool> isBigger = new Func<string, int, bool>((name, targetSize) =>
               {
                   bool isBigger = false;
                   int sum = 0;
                   foreach (var letter in name)
                   {
                       sum += letter;
                   }
                   if (sum >= targetSize)
                   {
                       isBigger = true;
                   }
                   return isBigger;
               });

            Func<string[], string> traverseNames = new Func<string[], string>((names) =>
              {
                  string firstValidName = string.Empty;
                  foreach (var name in names)
                  {
                      if (isBigger(name, wordSum))
                      {
                          firstValidName = name;
                          break;
                      }
                  }
                  return firstValidName;
              });
            string firstValidName = traverseNames(names);
            Console.WriteLine(firstValidName);
        }
    }
}
