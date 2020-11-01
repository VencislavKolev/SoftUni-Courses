
using P01.Vehicles.Common;
using P01.Vehicles.Models.Contracts;
using System;

namespace P01.Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKilometer)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumptionPerKilometer { get; protected set; }

        public string Drive(double kilometers)
        {
            double fuelNeeded = this.FuelConsumptionPerKilometer * kilometers;
            if (this.FuelQuantity < fuelNeeded)
            {
                string excMsg = string.Format(ExceptionMessages.NotEnoughFuelMessage, this.GetType().Name);
                throw new InvalidOperationException(excMsg);
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            this.FuelQuantity += fuelAmount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
