using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using CarDealer.XlmHelper;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        private static readonly string DATASETS_PATH = "../../../Datasets/";
        private static readonly string DATASETS_RESULT_PATH = "../../../Datasets/Result/";

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //ResetDatabase(context);
            //CreateExportDirectory();

            //---------IMPORT---------

            //---------TASK 1---------
            string suppliersXml = File.ReadAllText(DATASETS_PATH + "suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));

            //---------TASK 2---------
            string partsXml = File.ReadAllText(DATASETS_PATH + "parts.xml");
            //Console.WriteLine(ImportParts(context, partsXml));

            //---------TASK 3---------
            string carsXml = File.ReadAllText(DATASETS_PATH + "cars.xml");
            //Console.WriteLine(ImportCars(context, carsXml));

            //---------TASK 4---------
            string customersXml = File.ReadAllText(DATASETS_PATH + "customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersXml));

            //---------TASK 5---------
            string salesXml = File.ReadAllText(DATASETS_PATH + "sales.xml");
            //Console.WriteLine(ImportSales(context, salesXml));

            //---------EXPORT---------

            ////---------TASK 6---------
            //string cars = GetCarsWithDistance(context);
            //File.WriteAllText(DATASETS_RESULT_PATH + "cars.xml", cars);

            ////---------TASK 7---------
            //string bmwCars = GetCarsFromMakeBmw(context);
            //File.WriteAllText(DATASETS_RESULT_PATH + "bmw-cars.xml", bmwCars);

            ////---------TASK 8---------
            //string localSuppliers = GetLocalSuppliers(context);
            //File.WriteAllText(DATASETS_RESULT_PATH + "local-suppliers.xml", localSuppliers);

            ////---------TASK 9---------
            //string carsWithParts = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText(DATASETS_RESULT_PATH + "cars-and-parts.xml", carsWithParts);

            //---------TASK 10---------
            //string customerSales = GetTotalSalesByCustomer(context);
            //File.WriteAllText(DATASETS_RESULT_PATH + "customers-total-sales.xml", customerSales);

            //---------TASK 11---------
            string salesInfo = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(DATASETS_RESULT_PATH + "sales-discounts.xml", salesInfo);
        }

        //Task11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleInfoDto[] salesInfo = context.Sales
                .Select(x => new ExportSaleInfoDto
                {
                    Car = new ExportCarAttributeDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(x => x.Part.Price) - x.Car.PartCars.Sum(x => x.Part.Price) * x.Discount / 100
                })
                .ToArray();

            string result = XmlConverter.Serialize<ExportSaleInfoDto>(salesInfo, "sales");

            return result;
        }

        //Task10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerSales = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new ExportCustomerSaleDto
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales
                        .Select(x => x.Car)
                        .SelectMany(x => x.PartCars)
                        .Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            string result = XmlConverter.Serialize<ExportCustomerSaleDto>(customerSales, "customers");

            return result;
        }

        //Task9
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarPartDto[] carParts = context.Cars
                .Select(c => new ExportCarPartDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(p => new ExportPartDto
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            string result = XmlConverter.Serialize<ExportCarPartDto>(carParts, "cars");

            return result;
        }

        //Task8
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            string result = XmlConverter.Serialize<ExportLocalSupplierDto>(localSuppliers, "suppliers");

            return result;
        }

        //Task7
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarBmwDto[] bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportCarBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            string result = XmlConverter.Serialize<ExportCarBmwDto>(bmwCars, "cars");

            return result;
        }

        //Task6
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarDto[] cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(c => new ExportCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            string result = XmlConverter.Serialize<ExportCarDto>(cars, "cars");

            return result;
        }

        //Task5
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            ImportSaleDto[] salesDto = XmlConverter.Deserializer<ImportSaleDto>(inputXml, "Sales");

            List<Sale> sales = salesDto
                .Where(c => context.Cars.Any(x => x.Id == c.CarId))
                .Select(s => new Sale
                {
                    Discount = s.Discount,
                    CarId = s.CarId,
                    CustomerId = s.CustomerId
                })
                .ToList();


            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Task4
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ImportCustomerDto[] customersDto = XmlConverter.Deserializer<ImportCustomerDto>(inputXml, "Customers");

            List<Customer> customers = customersDto
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Task3
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootAttribute = "Cars";

            ImportCarDto[] carsDto = XmlConverter.Deserializer<ImportCarDto>(inputXml, rootAttribute);

            List<Car> cars = new List<Car>();

            List<PartCar> partCars = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                };

                int[] validParts = carDto.Parts
                    .Where(x => context.Parts
                        .Any(p => p.Id == x.PartId))
                    .Select(p => p.PartId)
                    .Distinct()
                    .ToArray();

                foreach (var partId in validParts)
                {
                    PartCar partCar = new PartCar
                    {
                        Car = car,
                        PartId = partId
                    };
                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.PartCars.AddRange(partCars);
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Task2
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootAttribute = "Parts";

            ImportPartDto[] partsDto = XmlConverter.Deserializer<ImportPartDto>(inputXml, rootAttribute);

            List<Part> parts = partsDto
                .Where(p => context.Suppliers
                .Any(s => s.Id == p.SupplierId))
                    .Select(p => new Part
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = p.Quantity,
                        SupplierId = p.SupplierId
                    })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Task1
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootAttribute = "Suppliers";

            ImportSuppliersDto[] suppliersDto = XmlConverter.Deserializer<ImportSuppliersDto>(inputXml, rootAttribute);

            List<Supplier> suppliers = suppliersDto
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("DB deleted");
            context.Database.EnsureCreated();
            Console.WriteLine("DB created");
        }

        private static void CreateExportDirectory()
        {
            if (!Directory.Exists(DATASETS_RESULT_PATH))
            {
                Directory.CreateDirectory(DATASETS_RESULT_PATH);
            }
        }
    }
}