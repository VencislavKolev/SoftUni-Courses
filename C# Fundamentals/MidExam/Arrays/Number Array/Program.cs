using System;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int positiveNumCount = 0;
            while (input != "End")
            {
                string[] command = input.Split();
                string action = command[0];

                int givenIndex = 0;
                switch (action)
                {
                    case "Switch":
                        givenIndex = int.Parse(command[1]);
                        if (givenIndex >= 0 && givenIndex < arr.Length)
                        {
                            arr[givenIndex] *= -1;
                        }
                        break;
                    case "Change":
                        givenIndex = int.Parse(command[1]);
                        if (givenIndex >= 0 && givenIndex < arr.Length)
                        {
                            int value = int.Parse(command[2]);
                            arr[givenIndex] = value;
                        }
                        break;
                    case "Sum":
                        string type = command[1];
                        int sum = 0;
                        if (type == "Negative")
                        {
                            foreach (int num in arr)
                            {
                                if (num < 0)
                                {
                                    sum += num;
                                }
                            }
                        }
                        else if (type == "Positive")
                        {
                            foreach (int num in arr)
                            {
                                if (num >= 0)
                                {
                                    sum += num;
                                    positiveNumCount++;
                                }
                            }
                        }
                        else if (type == "All")
                        {
                            sum = arr.Sum();
                        }
                        Console.WriteLine(sum);
                        break;
                }
                input = Console.ReadLine();
            }

            string positive = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    positive += arr[i] + " ";
                }
            }
            Console.WriteLine(positive);
        }
    }
}
