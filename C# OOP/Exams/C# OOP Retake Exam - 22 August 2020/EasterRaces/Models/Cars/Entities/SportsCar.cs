
using System;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int MIN_HP = 250;
        private const int MAX_HP = 450;
        private const int DEF_SPORTSCAR_CUB_CENTIMETERS = 3000;

        private int horsePower;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, DEF_SPORTSCAR_CUB_CENTIMETERS)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MIN_HP || value > MAX_HP)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
    }
}
