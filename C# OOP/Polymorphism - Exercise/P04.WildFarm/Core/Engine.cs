using System;
using System.Collections.Generic;

using P04.WildFarm.Core.Contracts;
using P04.WildFarm.Exceptions;
using P04.WildFarm.Factories;
using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Contracts;
namespace P04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<IAnimal> animals;
        private FoodFactory foodFactory;
        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArgs = command.Split();
                IAnimal animal = ProduceAnimal(animalArgs);

                string[] foodArgs = Console.ReadLine().Split();
                string foodName = foodArgs[0];
                int quantity = int.Parse(foodArgs[1]);
                IFood food = this.foodFactory.ProduceFood(foodName, quantity);

                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Feed(food);
                }
                catch (UneatableFoodExceptions ufe)
                {
                    Console.WriteLine(ufe.Message);
                }
                this.animals.Add(animal);
            }
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static IAnimal ProduceAnimal(string[] animalArgs)
        {
            IAnimal animal = null;
            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                string livingRegion = animalArgs[3];
                if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else
                {
                    string breed = animalArgs[4];
                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                }
            }

            return animal;
        }
    }
}
