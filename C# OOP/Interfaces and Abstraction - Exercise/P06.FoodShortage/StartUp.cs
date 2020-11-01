using System;
using System.Linq;
using P06.FoodShortage.Models;

namespace P06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            People people = new People();
            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string group = inputArgs[2];
                    Rebel rebel = new Rebel(name, age, group);
                    people.AddRebel(rebel);
                }
                else if (inputArgs.Length == 4)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];
                    string birthdate = inputArgs[3];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    people.AddCitizen(citizen);
                }
            }
            string nameToFind;
            while ((nameToFind = Console.ReadLine()) != "End")
            {
                if (people.Citizens.Any(x => x.Name == nameToFind))
                {
                    Citizen citizen = people.Citizens.First(x => x.Name == nameToFind);
                    citizen.BuyFood();
                }
                else if (people.Rebels.Any(x => x.Name == nameToFind))
                {
                    Rebel rebel = people.Rebels.First(x => x.Name == nameToFind);
                    rebel.BuyFood();
                }
            }
            int food = people.Rebels.Sum(x => x.Food) + people.Citizens.Sum(x => x.Food);
            Console.WriteLine(food);
        }
    }
}
