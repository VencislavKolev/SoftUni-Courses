using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split('|');

            int health = 100;
            int bitcoins = 0;
            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currRoom = rooms[i].Split();
                string roomName = currRoom[0];
                int amount = int.Parse(currRoom[1]);

                if (roomName == "potion")
                {
                    if (health + amount <= 100)
                    {
                        health += amount;
                    }
                    else
                    {
                        amount = 100 - health;
                        health = 100;
                    }
                    Console.WriteLine($"You healed for {amount} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (roomName == "chest")
                {
                    bitcoins += amount;
                    Console.WriteLine($"You found {amount} bitcoins.");
                }
                else
                {
                    string monster = currRoom[0];
                    health -= amount;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
