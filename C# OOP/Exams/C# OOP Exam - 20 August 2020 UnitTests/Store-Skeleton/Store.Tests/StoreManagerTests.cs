using System;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

namespace Store.Tests
{
    [TestFixture]
    public class StoreManagerTests
    {
        private StoreManager storeManager;
        [SetUp]
        public void Setup()
        {
            this.storeManager = new StoreManager();
        }

        [Test]
        public void TestIfProductCtorWorksCorrectly()
        {
            //Arrange
            string expName = "SomeProduct";
            int expQty = 1;
            decimal expPrice = 1m;
            //Act
            Product product = new Product(expName, expQty, expPrice);
            //Assert
            Assert.AreEqual(expName, product.Name);
            Assert.AreEqual(expQty, product.Quantity);
            Assert.AreEqual(expPrice, product.Price);
        }
        [Test]
        public void TestIfStoreManagerCtorWorksCorrectly()
        {
            StoreManager store = new StoreManager();
            Assert.IsNotNull(store);
        }
        [Test]
        public void AddProductShouldThrowExceptionWhenNullProductGiven()
        {
            Product nullProduct = null;
            Assert.That(() =>
            {
                this.storeManager.AddProduct(nullProduct);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void AddProductShouldThrowExceptionWhenNotEnoughQty(int quantity)
        {
            Product product = new Product("SomeName", quantity, 10m);
            Assert.That(() =>
            {
                this.storeManager.AddProduct(product);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("Product count can't be below or equal to zero."));
        }

        [Test]
        public void AddProductShouldIncreaseCount()
        {
            //Arrange
            int expCount = 2;
            Product product = new Product("SomeName", 2, 10m);
            Product product2 = new Product("SomeName2", 4, 20m);
            //Act
            this.storeManager.AddProduct(product);
            this.storeManager.AddProduct(product2);
            //Assert
            int actCount = this.storeManager.Count;
            Assert.AreEqual(expCount, actCount);
        }
        [Test]
        public void TestIfProductPropertyReturnValidCollection()
        {
            //Arrange
            Product product = new Product("SomeName", 2, 10m);
            Product product2 = new Product("SomeName2", 4, 20m);
            IReadOnlyCollection<Product> expProduct = new List<Product>()
            {
                product,product2
            };
            //Act
            this.storeManager.AddProduct(product);
            this.storeManager.AddProduct(product2);

            //Assert
            IReadOnlyCollection<Product> actProducts = this.storeManager.Products;
            CollectionAssert.AreEqual(expProduct, actProducts);
        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenProductIsNull()
        {
            Assert.That(() =>
            {
                this.storeManager.BuyProduct("None", 2);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenProductQtyIsLessThanWanted()
        {
            Product product = new Product("SomeName", 4, 20m);
            this.storeManager.AddProduct(product);
            Assert.That(() =>
            {
                this.storeManager.BuyProduct(product.Name, 5);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("There is not enough quantity of this product."));
        }
        [Test]
        public void BuyProductShouldReturnCorrectFinalPrice()
        {
            //Arrange
            decimal expPrice = 80m;
            Product product = new Product("SomeName", 4, 20m);
            this.storeManager.AddProduct(product);
            //Act
            decimal actPrice = this.storeManager.BuyProduct(product.Name, 4);
            //Assert
            Assert.AreEqual(expPrice, actPrice);
        }
        [Test]
        public void BuyProductShouldDecreaseProductQuantity()
        {
            //Arrange
            int expQty = 2;
            Product product = new Product("SomeName", 4, 20m);
            this.storeManager.AddProduct(product);
            //Act
            this.storeManager.BuyProduct(product.Name, 2);
            int actQty = this.storeManager
                .Products
                .First(x => x.Name == product.Name)
                .Quantity;
            //Assert
            Assert.AreEqual(expQty, actQty);
        }
        [Test]
        public void MostExpProductShouldReturnNullWhenNoProducts()
        {
            Product product = this.storeManager.GetTheMostExpensiveProduct();
            Assert.IsNull(product);
        }
        [Test]
        public void MostExpProductShouldReturnCorrectProduct()
        {
            Product product = new Product("SomeName", 4, 20m);
            Product mostExp = new Product("SomeName2", 4, 100m);
            this.storeManager.AddProduct(product);
            this.storeManager.AddProduct(mostExp);

            //Act
            Product actProduct = this.storeManager.GetTheMostExpensiveProduct();
            //Assert
            Assert.AreEqual(mostExp, actProduct);
        }
    }
}