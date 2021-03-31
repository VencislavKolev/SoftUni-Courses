using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;

namespace ProductShop
{
    public class StartUp
    {
        private static string DATASETS_PATH = "../../../Datasets/";
        private static string DATASETS_RESULT_PATH = "../../../Datasets/Result/";

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //ResetDatabase(context);

            //CreateExportDirectory();

            ////---------TASK 1---------
            //string inputXml = File.ReadAllText(DATASETS_PATH + "users.xml");
            //string importedUsersCount = ImportUsers(context, inputXml);
            //Console.WriteLine(importedUsersCount);

            ////---------TASK 2---------
            //string inputXml2 = File.ReadAllText(DATASETS_PATH + "products.xml");
            //string importedProductsCount = ImportProducts(context, inputXml2);
            //Console.WriteLine(importedProductsCount);

            ////---------TASK 3---------
            //string inputXml3 = File.ReadAllText(DATASETS_PATH + "categories.xml");
            //string importedCategoriesCount = ImportCategories(context, inputXml3);
            //Console.WriteLine(importedCategoriesCount);

            ////---------TASK 4---------
            //string inputXml4 = File.ReadAllText(DATASETS_PATH + "categories-products.xml");
            //string importedCategoriesProducts = ImportCategoryProducts(context, inputXml4);
            //Console.WriteLine(importedCategoriesProducts);

            ////---------TASK 5---------
            //string productsInRangeXml = GetProductsInRange(context);
            //File.WriteAllText(DATASETS_RESULT_PATH + "products-in-range.xml", productsInRangeXml);

            ////---------TASK 6---------
            //string soldProducts = GetSoldProducts(context);
            //File.WriteAllText(DATASETS_RESULT_PATH + "users-sold-products.xml", soldProducts);

            ////---------TASK 7---------
            //string categoriesByProducts = GetCategoriesByProductsCount(context);
            //File.WriteAllText(DATASETS_RESULT_PATH + "categories-by-products.xml", categoriesByProducts);

            //---------TASK 8---------
            string usersWithProducts = GetUsersWithProducts(context);
            File.WriteAllText(DATASETS_RESULT_PATH + "users-and-products.xml", usersWithProducts);
        }

        //Task8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            ExportUsersAndProductsDto[] filteredUsers = context.Users
                .Include(x => x.ProductsSold)
                .ToArray()
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUsersAndProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(ps => new ProductDto
                            {
                                Name = ps.Name,
                                Price = ps.Price,
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray();

            var customExport = new ExportCustomUserProductDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = filteredUsers,
            };

            string result = XmlConverter.Serialize(customExport, rootElement);

            return result;
        }

        //Task7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            ExportCategoryInfoDto[] categories = context.Categories
                .Select(c => new ExportCategoryInfoDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts
                        .Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts
                        .Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            string result = XmlConverter.Serialize(categories, rootElement);

            return result;
        }

        //Task6
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            ExportUserSoldProductDto[] userSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(usp => new ExportUserSoldProductDto
                {
                    FirstName = usp.FirstName,
                    LastName = usp.LastName,
                    SoldProducts = usp.ProductsSold
                    //.Where(u => u.Buyer != null)
                        .Select(p => new ExportSoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            string result = XmlConverter.Serialize(userSoldProducts, rootElement);

            return result;
        }

        //Task5
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            ExportProductDto[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + ' ' + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            string result = XmlConverter.Serialize(products, rootElement);

            return result;

        }

        //Task4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootAttribute = "CategoryProducts";

            ImportCategoryProductDto[] importCategoriesProductsDto = XmlConverter.Deserializer<ImportCategoryProductDto>(inputXml, rootAttribute);

            //int[] validCategoryIds = context.Categories
            //    .Select(c => c.Id)
            //    .ToArray();
            //int[] validProductIds = context.Products
            //    .Select(p => p.Id)
            //    .ToArray();
            //.Where(cp => validCategoryIds.Contains(cp.CategoryId) &&
            //validProductIds.Contains(cp.ProductId))

            List<CategoryProduct> categoryProducts = importCategoriesProductsDto
                .Where(i =>
                context.Categories.Any(c => c.Id == i.CategoryId) &&
                context.Products.Any(p => p.Id == i.ProductId))
                .Select(cp => new CategoryProduct
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Task3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootAttribute = "Categories";

            ImportCategoryDto[] importCategoriesDto = XmlConverter.Deserializer<ImportCategoryDto>(inputXml, rootAttribute);

            List<Category> categories = importCategoriesDto
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Task 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootAttribute = "Products";

            ImportProductDto[] importProductsDto = XmlConverter.Deserializer<ImportProductDto>(inputXml, rootAttribute);

            List<Product> products = importProductsDto
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToList();

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Task 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootAttribute = "Users";

            ImportUserDto[] importUsersDto = XmlConverter.Deserializer<ImportUserDto>(inputXml, rootAttribute);

            List<User> users = importUsersDto
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToList();

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        private static void ResetDatabase(ProductShopContext context)
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