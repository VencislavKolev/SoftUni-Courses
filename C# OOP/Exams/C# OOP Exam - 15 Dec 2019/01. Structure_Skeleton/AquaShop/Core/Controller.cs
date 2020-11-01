
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IAquarium> aquariums;
        private readonly IRepository<IDecoration> decorations;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            this.aquariums.Add(aquarium);
            string message = string.Format(OutputMessages.SuccessfullyAdded, aquariumType); //aquarium.GetType().Name
            return message;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            this.decorations.Add(decoration);
            string message = string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            return message;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            ////
            string outputMsg = string.Empty;
            if (aquarium.GetType() == typeof(FreshwaterAquarium) && fish.GetType() == typeof(FreshwaterFish) ||
                aquarium.GetType() == typeof(SaltwaterAquarium) && fish.GetType() == typeof(SaltwaterFish))
            {
                outputMsg = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                aquarium.AddFish(fish);
            }
            else
            {
                outputMsg = OutputMessages.UnsuitableWater;
            }
            //if (fish.GetType() == typeof(FreshwaterFish) && aquarium.GetType() == typeof(SaltwaterAquarium))
            //{
            //    return OutputMessages.UnsuitableWater;
            //}
            //if (fish.GetType() == typeof(SaltwaterFish) && aquarium.GetType() == typeof(FreshwaterAquarium))
            //{
            //    return OutputMessages.UnsuitableWater;
            //}

            //aquarium.AddFish(fish);

            //string outputMsg = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            return outputMsg;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            var totalValue = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            string outputMsg = string.Format(OutputMessages.AquariumValue, aquariumName, totalValue);
            return outputMsg;
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            foreach (var currFish in aquarium.Fish)
            {
                currFish.Eat();
            }
            string outputMsg = string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
            return outputMsg;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            if (decoration == null)
            {
                string excMsg = string.Format(ExceptionMessages.InexistentDecoration, decorationType);
                throw new InvalidOperationException(excMsg);
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            string outputMsg = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            return outputMsg;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
