using System;
using System.Collections.Generic;
using System.Text;

namespace P06.FoodShortage.Models
{
    public class People
    {
        private List<Citizen> citizens;
        private List<Rebel> rebels;

        public People()
        {
            this.citizens = new List<Citizen>();
            this.rebels = new List<Rebel>();
        }

        public IReadOnlyCollection<Citizen> Citizens => this.citizens;
        public IReadOnlyCollection<Rebel> Rebels => this.rebels;

        public void AddCitizen(Citizen citizen)
        {
            this.citizens.Add(citizen);
        }
        public void AddRebel(Rebel rebel)
        {
            this.rebels.Add(rebel);
        }
    }
}
