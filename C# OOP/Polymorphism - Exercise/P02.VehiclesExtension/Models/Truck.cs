
using P02.VehiclesExtension.Common;
using System;

namespace P02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double AIRCON_INCREASE = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
        {

        }
        public override double FuelConsumptionPerKilometer
        {
            get
            {
                return base.FuelConsumptionPerKilometer;
            }
            protected set
            {
                base.FuelConsumptionPerKilometer = value + AIRCON_INCREASE;
            }
        }

        public override void Refuel(double fuelAmount)
        {

            if (fuelAmount > this.TankCapacity)
            {
                string excMsg = string.Format(ExceptionMessages.InvalidRefillQuantityMessage, fuelAmount);
                throw new InvalidOperationException(excMsg);
            }
            base.Refuel(fuelAmount * 0.95);
        }
    }
}
