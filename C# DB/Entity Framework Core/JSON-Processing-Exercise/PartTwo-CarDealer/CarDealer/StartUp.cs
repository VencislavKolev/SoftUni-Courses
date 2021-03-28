using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.CustomerDTOs;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string Datasets_Path = "../../../Datasets/";
        private static string Datasets_Results_Path = "../../../Datasets/Results/";
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();
            //EnsureCreated(dbContext);
            CreateResultDirectory();
            InitializeMapper();

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

            ////------6------
            //string json = GetOrderedCustomers(dbContext);
            //File.WriteAllText(Datasets_Results_Path + "orderedCustomers.json", json);

            ////------7------
            //string json = GetCarsFromMakeToyota(dbContext);
            //File.WriteAllText(Datasets_Results_Path + "toyota-cars.json", json);

            ////------8------
            //string json = GetLocalSuppliers(dbContext);
            //File.WriteAllText(Datasets_Results_Path + "local-suppliers.json", json);

            ////------9------
            //string json = GetCarsWithTheirListOfParts(dbContext);
            //File.WriteAllText(Datasets_Results_Path + "cars-and-parts.json", json);

            ////------10------
            //string json = GetTotalSalesByCustomer(dbContext);
            //File.WriteAllText(Datasets_Results_Path + "customers-total-sales.json", json);

            //------11------
            string json = GetSalesWithAppliedDiscount(dbContext);
            File.WriteAllText(Datasets_Results_Path + "sales-discounts.json", json);
        }

        //Task11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            CustomerSaleDto[] sales = context.Sales
                .Take(10)
                .Select(x => new CustomerSaleDto
                {
                    Car = new CarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    CustomerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    Price = x.Car.PartCars.Sum(cp => cp.Part.Price).ToString("F2"),
                    PriceWithDiscount = (x.Car.PartCars.Sum(cp => cp.Part.Price) - x.Car.PartCars.Sum(cp => cp.Part.Price) * x.Discount / 100).ToString("F2")
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return json;
        }

        //Task10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            CustomerTotalSalesDto[] totalSales = context.Customers
                .ProjectTo<CustomerTotalSalesDto>()
                .Where(x => x.BoughtCars > 0)
                .OrderByDescending(s => s.SpendMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToArray();

            string json = JsonConvert.SerializeObject(totalSales, Formatting.Indented);
            return json;
        }

        //Task9
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new CarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    parts = c.PartCars
                        .Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("F2")
                        })

                })
                .ToArray();

            string json = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
            return json;
        }

        //Task8
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            SupplierDto[] localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            return json;
        }

        //Task7
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray()
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            string json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return json;
        }

        //Task6
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            CustomerOrderedDto[] orderedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new CustomerOrderedDto
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(orderedCustomers, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            }
            );
            return json;
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

        //Task1
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        private static void EnsureCreated(DbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            Console.WriteLine("Deleted");
            dbContext.Database.EnsureCreated();
            Console.WriteLine("Created");
        }

        private static void CreateResultDirectory()
        {
            if (!Directory.Exists(Datasets_Results_Path))
            {
                Directory.CreateDirectory(Datasets_Results_Path);
            }
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
        }
    }
}