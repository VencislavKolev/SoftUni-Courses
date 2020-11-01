
using System;
using P02.VehiclesExtension.Core.Contracts;
using P02.VehiclesExtensions.Factories;

namespace P02.VehiclesExtension.Core
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
            Vehicle bus = ProduceVehicle();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                try
                {
                    ProcessOperation(car, truck, bus, commandArgs);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ProcessOperation(Vehicle car, Vehicle truck, Vehicle bus, string[] commandArgs)
        {
            string action = commandArgs[0];
            string vehicleType = commandArgs[1];
            if (action == "Drive" || action == "DriveEmpty")
            {
                string cmdDriveOutput = "";
                double kilometers = double.Parse(commandArgs[2]);
                if (action == "DriveEmpty")
                {
                    cmdDriveOutput = bus.Drive(kilometers);
                }
                else if (vehicleType == "Car")
                {
                    cmdDriveOutput = car.Drive(kilometers);
                }
                else if (vehicleType == "Truck")
                {
                    cmdDriveOutput = truck.Drive(kilometers);
                }
                else if (vehicleType == "Bus")
                {
                    cmdDriveOutput = bus.DriveBusWithPeople(kilometers);
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
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(refillAmount);
                }
            }
        }

        private Vehicle ProduceVehicle()
        {
            string[] vehicleArgs = Console.ReadLine().Split();
            string type = vehicleArgs[0];
            double fuelQty = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);
            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQty, fuelConsumption, tankCapacity);
            return vehicle;
        }
    }
}
