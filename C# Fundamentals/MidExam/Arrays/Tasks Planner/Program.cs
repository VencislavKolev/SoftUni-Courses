using System;
using System.Linq;

namespace Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = "";
            int completedCount = 0;
            int incompletedCount = 0;
            int droppedCount = 0;
            foreach (var task in tasks)
            {
                if (task < 0)
                {
                    droppedCount++;
                }
                else if (task == 0)
                {
                    completedCount++;
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split();
                string action = commands[0];
                int index = 0;
                switch (action)
                {
                    case "Complete":
                        index = int.Parse(commands[1]);
                        if (index >= 0 && index < tasks.Length)
                        {
                            tasks[index] = 0;
                            completedCount++;
                        }
                        break;
                    case "Change":
                        index = int.Parse(commands[1]);
                        int time = int.Parse(commands[2]);
                        if (index >= 0 && index < tasks.Length)
                        {
                            tasks[index] = time;
                        }
                        break;
                    case "Drop":
                        index = int.Parse(commands[1]);
                        if (index >= 0 && index < tasks.Length)
                        {
                            tasks[index] = -1;
                            droppedCount++;
                        }
                        break;
                    case "Count":
                        int sum = 0;
                        if (commands[1] == "Completed")
                        {
                            sum = completedCount;
                        }
                        else if (commands[1] == "Incomplete")
                        {
                            incompletedCount = tasks.Length - completedCount - droppedCount;
                            sum = incompletedCount;
                        }
                        else if (commands[1] == "Dropped")
                        {
                            sum = droppedCount;
                        }
                        Console.WriteLine(sum);
                        break;
                }
            }
            string incompleted = "";
            foreach (var task in tasks)
            {
                if (task > 0)
                {
                    incompleted += task + " ";
                }
            }
            Console.WriteLine(incompleted);
        }
    }
}
