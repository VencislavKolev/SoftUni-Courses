
using P03.Raiding.Core.Contracts;
using P03.Raiding.Factories;
using P03.Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Raiding.Core
{
    public class Engine : IEngine
    {
        private HeroFactory heroFactory;
        private ICollection<IBaseHero> heros;
        public Engine()
        {
            this.heros = new List<IBaseHero>();
            this.heroFactory = new HeroFactory();
        }
        public void Run()
        {
            int neededValidHeros = int.Parse(Console.ReadLine());
            int currValidHeros = 0;
            while (currValidHeros != neededValidHeros)
            {

                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    IBaseHero hero = this.heroFactory.ProduceHero(type, name);
                    if (hero == null)
                    {
                        throw new InvalidOperationException("Invalid hero!");
                    }
                    this.heros.Add(hero);
                    currValidHeros++;
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in this.heros)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int herosTotalPower = this.heros.Sum(x => x.Power);
            if (herosTotalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
