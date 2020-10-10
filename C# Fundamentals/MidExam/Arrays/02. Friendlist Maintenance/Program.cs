using System;

namespace _02._Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] friendList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string input = "";

            while ((input = Console.ReadLine()) != "Report")
            {
                string[] commands = input.Split();
                string action = commands[0];
                int index = 0;
                string name = "";
                if (action == "Blacklist")
                {
                    name = commands[1];
                    bool isNotFound = true;
                    for (int i = 0; i < friendList.Length; i++)
                    {
                        if (friendList[i] == name)
                        {
                            friendList[i] = "Blacklisted";
                            isNotFound = false;
                            Console.WriteLine($"{name} was blacklisted.");
                        }
                    }
                    if (isNotFound)
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (action == "Error")
                {
                    index = int.Parse(commands[1]);
                    if (index >= 0 && index < friendList.Length)
                    {
                        name = friendList[index];
                        if (name != "Blacklisted" && name != "Lost")
                        {
                            friendList[index] = "Lost";
                            Console.WriteLine($"{name} was lost due to an error.");
                        }
                    }
                }
                else if (action == "Change")
                {
                    index = int.Parse(commands[1]);
                    string newName = commands[2];
                    if (index >= 0 && index < friendList.Length)
                    {
                        string currName = friendList[index];
                        friendList[index] = newName;
                        Console.WriteLine($"{currName} changed his username to {newName}.");
                    }
                }
            }
            int blacklistedCount = 0;
            int lostCount = 0;
            foreach (var name in friendList)
            {
                if (name == "Blacklisted")
                {
                    blacklistedCount++;
                }
                else if (name == "Lost")
                {
                    lostCount++;
                }
            }
            Console.WriteLine($"Blacklisted names: {blacklistedCount}");
            Console.WriteLine($"Lost names: {lostCount}");
            Console.WriteLine(string.Join(" ", friendList));
        }
    }
}
