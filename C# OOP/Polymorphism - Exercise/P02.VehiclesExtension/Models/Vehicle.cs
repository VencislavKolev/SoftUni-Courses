using System;
using System.Runtime.InteropServices;
using P02.VehiclesExtension.Common;
using P02.VehiclesExtension.Models.Contracts;

namespace P02.VehiclesExtension
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public double TankCapacity { get; private set; }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                this.fuelQuantity = value;
            }
        }
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
        public virtual string DriveBusWithPeople(double kilometers)
        {

            double WITH_PEOPLE_INCREASE = 1.4;
            double fuelNeeded = (this.FuelConsumptionPerKilometer + WITH_PEOPLE_INCREASE) * kilometers;
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
            if (this.FuelQuantity + fuelAmount > this.TankCapacity)
            {
                string excMsg = string.Format(ExceptionMessages.InvalidRefillQuantityMessage, fuelAmount);
                throw new InvalidOperationException(excMsg);
            }
            else if (fuelAmount <= 0)
            {
                string excMsg = string.Format(ExceptionMessages.NegativeOrZeroRefillQuantityMessage);
                throw new InvalidOperationException(excMsg);
            }
            this.FuelQuantity += fuelAmount;

        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
