using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string resultDirectory = "../../../Datasets/Results";


        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();
            // EnsureCreated(db);

            InitializeMapper();

            if (!Directory.Exists(resultDirectory))
            {
                Directory.CreateDirectory(resultDirectory);
            }

            //------1------

            //string inputJson = File.ReadAllText("../../../DataSets/users.json");
            //string importedUsers = ImportUsers(db, inputJson);
            //Console.WriteLine(importedUsers);

            //------2------

            //string inputJson = File.ReadAllText("../../../DataSets/products.json");
            //string importedProducts = ImportProducts(db, inputJson);
            //Console.WriteLine(importedProducts);

            //------3------

            //string inputJson = File.ReadAllText("../../../DataSets/categories.json");
            //string importedCategories = ImportCategories(db, inputJson);
            //Console.WriteLine(importedCategories);

            //------4------

            //string inputJson = File.ReadAllText("../../../DataSets/categories-products.json");
            //string importedCategoryProducts = ImportCategoryProducts(db, inputJson);
            //Console.WriteLine(importedCategoryProducts);

            //------5------

            //string json = GetProductsInRange(db);
            //File.WriteAllText(resultDirectory + "/products-in-range.json", json);

            //------6------

            //string json = GetSoldProducts(db);
            //File.WriteAllText(resultDirectory + "/users-sold-productsDTO-AM.json", json);

            //------7------
            //string json = GetCategoriesByProductsCount(db);
            //File.WriteAllText(resultDirectory + "/categories-by-products.json", json);

            //------8------
            string json = GetUsersWithProducts(db);
            File.WriteAllText(resultDirectory + "/users-and-products.json", json);

        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }

        //Task1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Task2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Task3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            //JsonSerializerSettings settings = new JsonSerializerSettings()
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //};

            List<Category> categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Task4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Task5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 & p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = string.Concat(p.Seller.FirstName, " ", p.Seller.LastName)
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        //Task6
        public static string GetSoldProducts(ProductShopContext context)
        {
            UserWithSoldProductsDTO[] soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<UserWithSoldProductsDTO>()
                .ToArray();

            //var soldProducts = context.Users
            //    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            //    .OrderBy(u => u.LastName)
            //    .ThenBy(u => u.FirstName)
            //    .Select(u => new
            //    {
            //        firstName = u.FirstName,
            //        lastName = u.LastName,
            //        soldProducts = u.ProductsSold
            //            .Where(p => p.Buyer != null)
            //            .Select(p => new
            //            {
            //                name = p.Name,
            //                price = p.Price,
            //                buyerFirstName = p.Buyer.FirstName,
            //                buyerLastName = p.Buyer.LastName
            //            })
            //        .ToArray()
            //    })
            //    .ToArray();

            string json = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            return json;
        }

        //Task 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts
                    .Average(p => p.Product.Price)
                    .ToString("f2"),
                    totalRevenue = c.CategoryProducts
                    .Sum(p => p.Product.Price)
                    .ToString("f2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }
        //Task 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToArray()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(ps => ps.Buyer != null),
                        products = u.ProductsSold.Where(ps => ps.Buyer != null)
                            .Select(ps => new
                            {
                                name = ps.Name,
                                price = ps.Price
                            })
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToArray();

            var resultObject = new
            {
                usersCount = users.Length,
                users = users
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(resultObject, settings);
            return json;
        }
        private static void EnsureCreated(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Deleted");
            db.Database.EnsureCreated();
            Console.WriteLine("Created");
        }
    }
}