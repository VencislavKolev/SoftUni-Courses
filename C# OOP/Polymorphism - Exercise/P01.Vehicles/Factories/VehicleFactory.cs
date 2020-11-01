
using P01.Vehicles.Common;
using P01.Vehicles.Models;
using System;
using System.Threading;

namespace P01.Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle produceVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            if (vehicle == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicleMessage);
            }
            return vehicle;
        }
    }
}
