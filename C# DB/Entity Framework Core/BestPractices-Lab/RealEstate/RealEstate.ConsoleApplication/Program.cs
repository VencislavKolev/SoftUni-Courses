using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Services;
using RealEstates.Services;

namespace RealEstate.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            RealEstateDbContext db = new RealEstateDbContext();
            db.Database.Migrate();
            //Console.WriteLine("Created");

            IPropertiesService propertiesService = new PropertiesService(db);

            Console.Write("Min price: ");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price: ");
            int maxPrice = int.Parse(Console.ReadLine());
            var properties = propertiesService.SearchByPrice(minPrice, maxPrice);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.District}, fl. {property.Floor}, {property.Size} m², {property.Year}, {property.Price}€, {property.PropertyType}, {property.BuildingType}");
            }
        }
    }
}
