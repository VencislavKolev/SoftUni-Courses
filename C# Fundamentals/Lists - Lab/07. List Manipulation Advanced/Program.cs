using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            string command = "";
            bool isChanged = false;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] action = command.Split();

                if (action[0] == "Add" || action[0] == "Remove" ||
                    action[0] == "RemoveAt" || action[0] == "Insert")
                {
                    isChanged = true;
                }

                switch (action[0])
                {
                    case "Add":
                        int addNumber = int.Parse(action[1]);
                        list.Add(addNumber);
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(action[1]);
                        list.Remove(removeNumber);
                        break;
                    case "RemoveAt":
                        int removeAtIndex = int.Parse(action[1]);
                        if (removeAtIndex < list.Count)
                        {
                            list.RemoveAt(removeAtIndex);
                            continue;
                        }
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(action[1]);
                        int indexAt = int.Parse(action[2]);
                        if (indexAt < list.Count)
                        {
                            list.Insert(indexAt, insertNumber);
                            continue;
                        }
                        break;
                    case "Contains":
                        int wantedNumber = int.Parse(action[1]);
                        if (list.Contains(wantedNumber))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        foreach (var item in list)
                        {
                            if (item % 2 == 0)
                            {
                                Console.Write(item + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "PrintOdd":
                        foreach (var item in list)
                        {
                            if (item % 2 != 0)
                            {
                                Console.Write(item + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "GetSum": Console.WriteLine(list.Sum()); break;
                    case "Filter":
                        int number = int.Parse(action[2]);
                        if (action[1] == ">")
                        {
                            foreach (var item in list)
                            {
                                if (item > number)
                                {
                                    Console.Write(item + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (action[1] == ">=")
                        {
                            foreach (var item in list)
                            {
                                if (item >= number)
                                {
                                    Console.Write(item + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (action[1] == "<")
                        {
                            foreach (var item in list)
                            {
                                if (item < number)
                                {
                                    Console.Write(item + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (action[1] == "<=")
                        {
                            foreach (var item in list)
                            {
                                if (item <= number)
                                {
                                    Console.Write(item + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                }
            }
            if (isChanged == true)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}
