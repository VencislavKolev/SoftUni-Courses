using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split()
                   .Select(int.Parse).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split().ToArray();
                string operation = input[0];
                if (operation == "Add")
                {
                    int addNumber = int.Parse(input[1]);
                    AddNumber(list, addNumber);
                }
                else if (operation == "Insert")
                {
                    int index = int.Parse(input[2]);
                    int number = int.Parse(input[1]);
                    if (index < 0 || index > list.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    InsertNumber(list, number, index);
                }
                else if (operation == "Remove")
                {
                    int index = int.Parse(input[1]);
                    if (index < 0 || index > list.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    RemoveIndex(list, index);
                }
                else if (operation == "Shift")
                {
                    int count = int.Parse(input[2]);
                    if (input[1] == "left")
                    {
                        ShiftLeft(list, count);
                    }
                    else if (input[1] == "right")
                    {
                        ShiftRight(list, count);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
        static List<int> AddNumber(List<int> inputList, int number)
        {
            inputList.Add(number);
            return inputList;
        }
        static List<int> InsertNumber(List<int> inputList, int number, int index)
        {
            inputList.Insert(index, number);
            return inputList;
        }
        static List<int> RemoveIndex(List<int> inputList, int index)
        {
            inputList.RemoveAt(index);
            return inputList;
        }
        static List<int> ShiftLeft(List<int> inputList, int count)
        {
            for (int i = 0; i < count; i++) //брой ротации
            {
                int firstNum = inputList[0];
                inputList.Add(firstNum);
                inputList.RemoveAt(0);
            }
            return inputList;
        }
        static List<int> ShiftRight(List<int> inputList, int count)
        {
            for (int i = 0; i < count; i++) //брой ротации
            {
                int lastNum = inputList[inputList.Count - 1];
                inputList.Insert(0, lastNum);
                inputList.RemoveAt(inputList.Count - 1);
            }
            return inputList;
        }
    }
}
