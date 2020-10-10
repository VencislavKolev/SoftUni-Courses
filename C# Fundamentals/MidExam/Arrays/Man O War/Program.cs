using System;
using System.Linq;

namespace Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int[] warShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int maxHealthPerSection = int.Parse(Console.ReadLine());

            string input = "";
            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] commands = input.Split();
                string action = commands[0];
                int index = 0;
                int damage = 0;
                if (action == "Fire")
                {
                    index = int.Parse(commands[1]);
                    damage = int.Parse(commands[2]);
                    if (index >= 0 && index < warShip.Length)
                    {
                        warShip[index] -= damage;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                        continue;
                    }
                }
                else if (action == "Defend")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    damage = int.Parse(commands[3]);
                    if ((startIndex >= 0 && startIndex < pirateShip.Length) &&
                        (endIndex >= 0 && endIndex < pirateShip.Length))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                    continue;
                }
                else if (action == "Repair")
                {
                    index = int.Parse(commands[1]);
                    int addHealth = int.Parse(commands[2]);
                    if (index >= 0 && index < pirateShip.Length)
                    {
                        if (pirateShip[index] + addHealth <= maxHealthPerSection)
                        {
                            pirateShip[index] += addHealth;
                        }
                        else
                        {
                            pirateShip[index] = maxHealthPerSection;
                        }
                    }
                    continue;
                }
                else if (action == "Status")
                {
                    int sectionsNeededRepairCount = 0;
                    double minHealthNeeded = maxHealthPerSection * 1.0 / 5;
                    foreach (var section in pirateShip)
                    {
                        if (section < minHealthNeeded)
                        {
                            sectionsNeededRepairCount++;
                        }
                    }
                    Console.WriteLine($"{sectionsNeededRepairCount} sections need repair.");
                }
            }
            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");
        }
    }
}
