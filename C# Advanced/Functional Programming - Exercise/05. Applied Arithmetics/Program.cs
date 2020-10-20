using System;
using System.Linq;
using System.Net.Sockets;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = ((arr) =>
            {
                Console.WriteLine(string.Join(" ", arr));
            });

            int[] numberArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    print(numberArr);
                }
                else
                {
                    Func<int[], int[]> processor = GetProcessor(command);
                    numberArr = processor(numberArr);
                }
            }
        }
        static Func<int[], int[]> GetProcessor(string cmd)
        {
            Func<int[], int[]> processor = null;
            if (cmd == "add")
            {
                processor = new Func<int[], int[]>((arr) =>
                  {
                      for (int i = 0; i < arr.Length; i++)
                      {
                          arr[i]++;
                      }
                      return arr;
                  });
            }
            else if (cmd == "multiply")
            {
                processor = new Func<int[], int[]>((arr) =>
                  {
                      for (int i = 0; i < arr.Length; i++)
                      {
                          arr[i] = arr[i] * 2;
                      }
                      return arr;
                  });
            }
            else if (cmd == "subtract")
            {
                processor = new Func<int[], int[]>((arr) =>
                  {
                      for (int i = 0; i < arr.Length; i++)
                      {
                          arr[i]--;
                      }
                      return arr;
                  });
            }
            return processor;
        }
    }
}
