

using EasterRaces.Models.Cars.Contracts;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MIN_MODEL_LENGTH = 4;
        private string model;

        public Car(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length < 4)
                {
                    string exc_msg = string.Format(Utilities.Messages.ExceptionMessages.InvalidModel, value, MIN_MODEL_LENGTH);
                    throw new ArgumentException(exc_msg);
                }
                this.model = value;
            }
        }

        public virtual int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
