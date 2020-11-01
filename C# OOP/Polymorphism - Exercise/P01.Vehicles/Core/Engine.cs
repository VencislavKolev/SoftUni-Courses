
using P01.Vehicles.Core.Contracts;
using P01.Vehicles.Factories;
using P01.Vehicles.Models;
using System;

namespace P01.Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;
        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                try
                {
                    ProcessOperation(car, truck, commandArgs);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ProcessOperation(Vehicle car, Vehicle truck, string[] commandArgs)
        {
            string action = commandArgs[0];
            string vehicleType = commandArgs[1];
            if (action == "Drive")
            {
                string cmdDriveOutput = "";
                double kilometers = double.Parse(commandArgs[2]);
                if (vehicleType == "Car")
                {
                    cmdDriveOutput = car.Drive(kilometers);
                }
                else if (vehicleType == "Truck")
                {
                    cmdDriveOutput = truck.Drive(kilometers);
                }
                Console.WriteLine(cmdDriveOutput);
            }
            else if (action == "Refuel")
            {
                double refillAmount = double.Parse(commandArgs[2]);
                if (vehicleType == "Car")
                {
                    car.Refuel(refillAmount);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(refillAmount);
                }
            }
        }

        private Vehicle ProduceVehicle()
        {
            string[] vehicleArgs = Console.ReadLine().Split();
            string type = vehicleArgs[0];
            double fuelQty = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            Vehicle vehicle = this.vehicleFactory.produceVehicle(type, fuelQty, fuelConsumption);
            return vehicle;
        }
    }
}
