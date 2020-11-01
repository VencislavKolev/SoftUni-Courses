using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Engine
    {
        private readonly List<Animal> animals;
        public Engine()
        {
            this.animals = new List<Animal>();
        }
        public void Run()
        {
            string animalType;
            while ((animalType=Console.ReadLine())!= "Beast!")
            {
                string[] animalInformation = Console.ReadLine()
                    .Split();
                Animal animal;
                try
                {
                    animal = GetAnimal(animalType, animalInformation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                animals.Add(animal);
            }
            PrintAnimal();
        }

        private Animal GetAnimal(string animalType, string[] animalInformation)
        {
            string name = animalInformation[0];
            int age = int.Parse(animalInformation[1]);
            string gender = GetGender(animalInformation);

            Animal animal = null;
            if (animalType == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (animalType == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (animalType == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (animalType == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (animalType == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }
            return animal;
        }
        private static string GetGender(string[] animalInformation)
        {
            string gender = string.Empty;
            if (animalInformation.Length >= 3)
            {
                gender = animalInformation[2];
            }

            return gender;
        }

        private void PrintAnimal()
        {
            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
