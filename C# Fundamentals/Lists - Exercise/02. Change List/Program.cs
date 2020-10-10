using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split()
                   .Select(int.Parse).ToList();
            PrintChangedList(list);
        }
        static void PrintChangedList(List<int> initialList)
        {
            List<int> newList = new List<int>();
            for (int i = 0; i < initialList.Count; i++)
            {
                newList.Add(initialList[i]);
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split().ToArray();
                if (command[0] == "Delete")
                {
                    int elementToRemove = int.Parse(command[1]);
                    if (newList.Contains(elementToRemove))
                    {
                        newList.RemoveAll(item => item == elementToRemove);
                    }
                }
                else if (command[0] == "Insert")
                {
                    int addElement = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    newList.Insert(index, addElement);
                }
                continue;
            }
            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
