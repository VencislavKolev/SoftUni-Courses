
using System;
using P02.VehiclesExtension;
using P02.VehiclesExtension.Common;
using P02.VehiclesExtension.Models;

namespace P02.VehiclesExtensions.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            if (vehicle == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicleMessage);
            }
            return vehicle;
        }
    }
}
