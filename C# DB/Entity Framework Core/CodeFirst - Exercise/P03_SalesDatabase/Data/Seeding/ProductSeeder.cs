using System;
using System.Collections.Generic;

using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Data.Seeding.Contracts;

namespace P03_SalesDatabase.Data.Seeding
{
    public class ProductSeeder : ISeeder
    {
        private readonly Random random;
        private readonly SalesContext dbContext;
        public ProductSeeder(SalesContext dbContext, Random random)
        {
            this.dbContext = dbContext;
            this.random = random;
        }
        public void Seed()
        {
            ICollection<Product> products = new List<Product>();

            string[] names = new string[]
            {
                "CPU",
                "Motherboard",
                "RAM",
                "SSD",
                "HDD",
                "Keyboard"
            };

            for (int i = 0; i < 30; i++)
            {
                int nameIndex = this.random.Next(names.Length);
                string productName = names[nameIndex];
                double quantity = this.random.Next(1000);
                decimal price = this.random.Next(5000) * 1.123m;

                Product product = new Product()
                {
                    Name = productName,
                    Quantity = quantity,
                    Price = price
                };

                products.Add(product);
            }

            this.dbContext
                .Products.AddRange(products);
            this.dbContext.SaveChanges();
        }
    }
}
