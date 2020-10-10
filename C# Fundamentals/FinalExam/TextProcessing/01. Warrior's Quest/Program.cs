using System;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "For Azeroth")
            {
                string[] command = input.Split();
                if (command[0] == "GladiatorStance")
                {
                    skill = skill.ToUpper();
                    Console.WriteLine(skill);
                }
                else if (command[0] == "DefensiveStance")
                {
                    skill = skill.ToLower();
                    Console.WriteLine(skill);
                }
                else if (command[0] == "Dispel")
                {
                    int index = int.Parse(command[1]);
                    char letter = char.Parse(command[2]);
                    if (index >= 0 && index < skill.Length)
                    {
                        char[] temp = skill.ToCharArray();
                        temp[index] = letter;
                        skill = new string(temp);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }
                else if (command[0] == "Target" && command[1] == "Change")
                {
                    string oldSubstring = command[2];
                    string newSubstring = command[3];
                    while (skill.Contains(oldSubstring))
                    {
                        skill = skill.Replace(oldSubstring, newSubstring);
                    }
                    Console.WriteLine(skill);
                }
                else if (command[0] == "Target" && command[1] == "Remove")
                {
                    string substring = command[2];
                    while (skill.Contains(substring))
                    {
                        skill = skill.Replace(substring, "");
                    }
                    Console.WriteLine(skill);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }
        }
    }
}
