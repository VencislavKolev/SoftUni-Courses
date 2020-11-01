using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public virtual double FuelConsumption => defaultFuelConsumption;
        public int HorsePower { get; private set; }
        public double Fuel { get; private set; }

        public virtual void Drive(double kilometers)
        {
            double spentFuel = (kilometers * this.FuelConsumption);
            this.Fuel -= spentFuel;
        }
    }
}
