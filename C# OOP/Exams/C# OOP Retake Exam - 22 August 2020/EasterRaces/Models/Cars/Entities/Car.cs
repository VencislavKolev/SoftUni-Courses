using System;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsepower;
        private int _minHorsePower;
        private int _maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this._minHorsePower = minHorsePower;
            this._maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    string excMsg = string.Format(ExceptionMessages.InvalidModel, value, 4);
                    throw new ArgumentException(excMsg);
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsepower;
            }
            private set
            {
                if (value < _minHorsePower || value > _maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsepower = value;
            }
        }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
