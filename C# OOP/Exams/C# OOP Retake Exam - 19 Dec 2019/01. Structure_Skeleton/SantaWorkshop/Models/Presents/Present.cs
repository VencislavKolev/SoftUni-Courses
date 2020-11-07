
using System;

using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private const int DEF_PRESENT_DECREASE = 10;

        private string name;
        private int energyRequired;

        public Present(string name,int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                this.energyRequired = value > 0 ? value : 0;
                //if (value < 0)
                //{
                //    this.energyRequired = 0;
                //}
                //this.energyRequired = value;
            }
        }

        public void GetCrafted()
        {
            this.EnergyRequired -= DEF_PRESENT_DECREASE;
        }

        public bool IsDone()
        {
            return this.EnergyRequired == 0;
        }
    }
}
