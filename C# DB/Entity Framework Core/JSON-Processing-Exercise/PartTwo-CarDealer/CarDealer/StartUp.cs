using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string Datasets_Path = "../../../Datasets/";
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();
            //EnsureCreated(dbContext);

            ////------1------
            //string inputJson = File.ReadAllText(Datasets_Path + "suppliers.json");
            //string importedSuppliers = ImportSuppliers(dbContext, inputJson);
            //Console.WriteLine(importedSuppliers);

            ////------2------
            //string inputJson2 = File.ReadAllText(Datasets_Path + "parts.json");
            //string importedParts = ImportParts(dbContext, inputJson2);
            //Console.WriteLine(importedParts);

            ////------3------
            //string inputJson3 = File.ReadAllText(Datasets_Path + "cars.json");
            //string importedCars = ImportCars(dbContext, inputJson3);
            //Console.WriteLine(importedCars);

            ////------4------
            //string inputJson4 = File.ReadAllText(Datasets_Path + "customers.json");
            //string importedCustomers = ImportCustomers(dbContext, inputJson4);
            //Console.WriteLine(importedCustomers);

            ////------5------
            //string inputJson5 = File.ReadAllText(Datasets_Path + "sales.json");
            //string importedSales = ImportSales(dbContext, inputJson5);
            //Console.WriteLine(importedSales);

            //------1------
            //------1------
            //------1------
            //------1------
        }

        //Task5
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Task4
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Task1
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Task2
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            int[] supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Task3
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<ImportCarDto> carsDto = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar
                    {
                        Car = car,
                        PartId = partId
                    });
                }

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        private static void EnsureCreated(DbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            Console.WriteLine("Deleted");
            dbContext.Database.EnsureCreated();
            Console.WriteLine("Created");
        }
    }
}