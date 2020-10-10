using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> heroHitPoints = new Dictionary<string, int>();
            Dictionary<string, int> heroManaPoints = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] inputHeros = Console.ReadLine().Split();
                string heroName = inputHeros[0];
                int hitPoints = int.Parse(inputHeros[1]);
                int manaPoints = int.Parse(inputHeros[2]);
                if (!heroHitPoints.ContainsKey(heroName) && hitPoints <= 100 && manaPoints <= 200)
                {
                    heroHitPoints[heroName] = hitPoints;
                    heroManaPoints[heroName] = manaPoints;
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(" - ");
                if (input[0] == "End")
                {
                    break;
                }
                string command = input[0];
                string heroName = input[1];
                if (command == "CastSpell")
                {
                    int manaPointsNeeded = int.Parse(input[2]);
                    string spellName = input[3];
                    if (heroManaPoints[heroName] >= manaPointsNeeded)
                    {
                        heroManaPoints[heroName] -= manaPointsNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroManaPoints[heroName]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(input[2]);
                    string attacker = input[3];
                    heroHitPoints[heroName] -= damage;
                    if (heroHitPoints[heroName] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroHitPoints[heroName]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroManaPoints.Remove(heroName);
                        heroHitPoints.Remove(heroName);
                    }
                }
                else if (command == "Recharge")
                {
                    int amount = int.Parse(input[2]);
                    if (heroManaPoints[heroName] + amount > 200)
                    {
                        amount = 200 - heroManaPoints[heroName];
                    }
                    heroManaPoints[heroName] += amount;
                    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                }
                else if (command == "Heal")
                {
                    int amount = int.Parse(input[2]);
                    if (heroHitPoints[heroName] + amount > 100)
                    {
                        amount = 100 - heroHitPoints[heroName];
                    }
                    heroHitPoints[heroName] += amount;
                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }
            }
            foreach (var kvp in heroHitPoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                string currHero = kvp.Key;
                Console.WriteLine($"{currHero}{Environment.NewLine}" +
                    $"  HP: {kvp.Value}{Environment.NewLine}" +
                    $"  MP: {heroManaPoints[currHero]}");
            }
        }
    }
}
