using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                string[] action = command.Split();
                switch (action[0])
                {
                    case "Add":
                        int addNumber = int.Parse(action[1]);
                        list.Add(addNumber); break;
                    case "Remove":
                        int removeNumber = int.Parse(action[1]);
                        list.Remove(removeNumber); break;
                    case "RemoveAt":
                        int removeAtIndex = int.Parse(action[1]);
                        list.RemoveAt(removeAtIndex); break;
                    case "Insert":
                        int insertNumber = int.Parse(action[1]);
                        int indexAt = int.Parse(action[2]);
                        if (indexAt <= list.Count - 1)
                        {
                            list.Insert(indexAt, insertNumber);
                            continue;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
