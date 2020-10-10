using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                string action = tokens[0];
                if (action == "Reverse")
                {
                    numbers.Reverse();
                    continue;
                }
                int paintingNum = int.Parse(tokens[1]);
                switch (action)
                {
                    case "Change":
                        int changedNum = int.Parse(tokens[2]);
                        if (numbers.IndexOf(paintingNum) != -1)
                        {
                            int paintingNumIndex = numbers.IndexOf(paintingNum);
                            numbers[paintingNumIndex] = changedNum;
                        }
                        break;
                    case "Hide":
                        if (numbers.IndexOf(paintingNum) != -1)
                        {
                            numbers.Remove(paintingNum);
                        }
                        break;
                    case "Switch":
                        int paintingNumTwo = int.Parse(tokens[2]);
                        if (numbers.Contains(paintingNum) &&
                            numbers.Contains(paintingNumTwo))
                        {
                            int indexOne = numbers.IndexOf(paintingNum);
                            int indexTwo = numbers.IndexOf(paintingNumTwo);
                            int temp = numbers[indexOne];
                            numbers[indexOne] = numbers[indexTwo];
                            numbers[indexTwo] = temp;
                        }
                        break;
                    case "Insert":
                        int place = int.Parse(tokens[1]);
                        int newPainting = int.Parse(tokens[2]);
                        if (place >= 0 && place < numbers.Count)
                        {
                            numbers.Insert(place + 1, newPainting);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
