using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }
                trainers[trainerName].Pokemons.Add(pokemon);
            }
            string element;
            while ((element = Console.ReadLine()) != "End")
            {
                if (element == "Fire")
                {
                    CheckTrainers(trainers, element);
                }
                else if (element == "Electricity")
                {
                    CheckTrainers(trainers, element);
                }
                else if (element == "Water")
                {
                    CheckTrainers(trainers, element);
                }
            }
            foreach (var trainer in trainers.Values
                .OrderByDescending(t => t.Badges))
            {
                Console.WriteLine(trainer);
            }
        }

        private static void CheckTrainers(Dictionary<string, Trainer> trainers, string element)
        {
            foreach (var trainer in trainers.Values)
            {
                if (trainer.Pokemons
                    .Any(p => p.Element == element))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }
                }
            }
            foreach (var trainer in trainers.Values)
            {
                for (int i = 0; i < trainer.Pokemons.Count; i++)
                {
                    if (trainer.Pokemons[i].Health<=0)
                    {
                        trainer.Pokemons.RemoveAt(i);
                    }
                }
            }
        }

        static bool ContainsElement(string element, Pokemon pokemon)
        {
            return pokemon.Element == element;
        }
    }
}
