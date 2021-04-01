using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarDealer.Data;
using CarDealer.Dto.Import;
using CarDealer.Models;
using CarDealer.XlmHelper;

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

            //---------TASK 5---------
            string cars = GetCarsWithDistance(context);
            File.WriteAllText(DATASETS_RESULT_PATH + "cars.xml", cars);
        }

        //Task6
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ImportCarDto[] cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(c => new ImportCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            string result = XmlConverter.Serialize<ImportCarDto>(cars, "cars");

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