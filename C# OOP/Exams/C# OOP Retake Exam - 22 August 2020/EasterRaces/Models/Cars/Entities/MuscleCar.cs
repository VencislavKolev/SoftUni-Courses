
using System;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MIN_HP = 400;
        private const int MAX_HP = 600;
        private const int DEF_MUSCLECAR_CUB_CENTIMETERS = 5000;

        private int horsePower;
        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, DEF_MUSCLECAR_CUB_CENTIMETERS)
        {

        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MIN_HP || value>MAX_HP)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }
    }
}
