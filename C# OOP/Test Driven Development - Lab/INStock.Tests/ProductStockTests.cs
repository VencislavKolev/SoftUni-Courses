namespace INStock.Tests
{
    using System;
    using System.Linq;
    using INStock.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        private const string ProductLabel = "TestLabel";
        private const string AnotherProductLabel = "AnotherLabel";
        private Product product;
        private Product anotherProduct;
        private ProductStock productStock;
        [SetUp]
        public void SetUp()
        {
            this.productStock = new ProductStock();
            this.product = new Product(ProductLabel, 10, 1);
            this.anotherProduct = new Product(AnotherProductLabel, 20, 5);
        }

        //Arrange

        //Act

        //Assert

        //----- Add Method Tests -----
        [Test]
        public void AddProductShouldAddTheProduct()
        {
            //Arrange
            //Act
            this.productStock.Add(this.product);
            //Assert
            IProduct actualProduct = productStock.FindByLabel(ProductLabel);

            Assert.That(productStock, Is.Not.Null);
            Assert.AreEqual(product.Label, actualProduct.Label);
            Assert.AreEqual(product.Price, actualProduct.Price);
            Assert.AreEqual(product.Quantity, actualProduct.Quantity);
        }
        [Test]
        public void AddingTwoProductsShouldAddThem()
        {
            //Act
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);
            //Assert
            IProduct firstActualProduct = productStock.FindByLabel(ProductLabel);
            IProduct secondActualProduct = productStock.FindByLabel(AnotherProductLabel);

            Assert.That(productStock, Is.Not.Null);

            Assert.AreEqual(product.Label, firstActualProduct.Label);
            Assert.AreEqual(product.Price, firstActualProduct.Price);
            Assert.AreEqual(product.Quantity, firstActualProduct.Quantity);

            Assert.AreEqual(anotherProduct.Label, secondActualProduct.Label);
            Assert.AreEqual(anotherProduct.Price, secondActualProduct.Price);
            Assert.AreEqual(anotherProduct.Quantity, secondActualProduct.Quantity);
        }
        [Test]
        public void AddProductShouldThrowExceptionWhenDuplicateLabel()
        {
            //Assert
            Assert.That(() =>
            {
                //Arrange & Act
                this.productStock.Add(this.product);
                this.productStock.Add(new Product(ProductLabel, 10, 1));
            },
            Throws.ArgumentException
            .With.Message.EqualTo($"A product with '{ProductLabel}' label already exists."));
        }
        //----- Remove Method Tests -----
        [Test]
        public void RemoveShouldReturnTrueIfRemovedSuccessfully()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();
            IProduct productToRemove = this.productStock.Find(3);
            //Act
            bool result = this.productStock.Remove(productToRemove);

            //Assert
            Assert.IsTrue(result);
            Assert.That(this.productStock.Count, Is.EqualTo(5));
            Assert.That(this.productStock[3].Label, Is.EqualTo("5"));
        }
        [Test]
        public void RemoveShouldReturnFalseIfProductIsNotFound()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();
            IProduct productNotInStock = new Product("NotInStock", 22, 33);
            //Act
            bool result = this.productStock.Remove(productNotInStock);

            //Assert
            Assert.IsFalse(result);
            Assert.That(this.productStock.Count, Is.EqualTo(6));
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenProductIsNull()
        {
            //Assert
            Assert.That(
                //Arrange & Act
                () => this.productStock.Remove(null),
            Throws
            .Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("Product cannot be null."));

            //Assert.Throws<ArgumentNullException>(() =>
            //{
            //    //Arrange & Act
            //    this.productStock.Remove(null);
            //}, "Product cannot be null.");
        }

        //----- Contains Method Tests -----
        [Test]
        public void ContainsShouldReturnTrueIfProductExists()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Act
            bool result = this.productStock.Contains(this.product);

            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void ContainsShouldReturnFalseIfProductDoesNotExists()
        {
            //Arrange & Act
            bool result = this.productStock.Contains(this.product);

            //Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void ContainsShouldThrowExceptionWhenProductIsNull()
        {
            //Assert
            Assert.That(
                //Arrange & Act
                () => this.productStock.Contains(null),
            Throws
            .Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("Product cannot be null."));
        }

        //----- Count Method Tests -----
        [Test]
        public void CountShouldReturnCorrectProductsCount()
        {
            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);
            int expectedCount = 2;
            //Act
            int actualCount = this.productStock.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        //----- Find Method Tests -----
        [Test]
        public void FindShouldReturnCorrectProductByIndex()
        {
            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);
            //Act
            IProduct foundProduct = this.productStock.Find(1);
            //Assert
            Assert.That(foundProduct, Is.Not.Null);
            Assert.AreEqual(anotherProduct.Label, foundProduct.Label);
            Assert.AreEqual(anotherProduct.Price, foundProduct.Price);
            Assert.AreEqual(anotherProduct.Quantity, foundProduct.Quantity);
        }
        [Test]
        public void FindShouldThrowExceptionWhenIndexOutOfRange()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Assert
            Assert.That(() =>
            {
                //Act
                this.productStock.Find(1);
            },
            Throws.Exception.InstanceOf<IndexOutOfRangeException>()
            .With.Message.EqualTo("Product index does not exist."));
        }
        [Test]
        public void FindShouldThrowExceptionWhenIndexIsBelowZero()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Assert
            Assert.That(() =>
            {
                //Act
                this.productStock.Find(-1);
            },
            Throws.Exception.InstanceOf<IndexOutOfRangeException>()
            .With.Message.EqualTo("Product index does not exist."));
        }

        //----- FindByLabel Method Tests -----
        [Test]
        public void FindByLabelShouldReturnCorrectProduct()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Act
            IProduct foundProduct = this.productStock.FindByLabel(ProductLabel);
            //Assert
            Assert.IsNotNull(foundProduct);
            Assert.AreEqual(this.product.Label, foundProduct.Label);
            Assert.AreEqual(this.product.Price, foundProduct.Price);
            Assert.AreEqual(this.product.Quantity, foundProduct.Quantity);
        }
        [Test]
        public void FindByLabelShouldThrowExceptionWhenProductDoesNotExist()
        {
            //Arrange
            const string invalidLabel = "Invalid Label";
            //Assert
            Assert.That(() =>
            {
                //Act
                this.productStock.FindByLabel(invalidLabel);
            },
            Throws
            .Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo($"Product with '{invalidLabel}' label could not be found."));
        }
        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelIsNull()
        {
            //Assert
            Assert.That(
                //Arrange & Act
                () => this.productStock.FindByLabel(null),
            Throws
            .Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("Product label cannot be null."));
        }

        //----- FindAllInPriceRange Method Tests -----

        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollectionWhenNoProductsMatch()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var collection = this.productStock.FindAllInRange(60, 100);
            //Assert
            Assert.IsEmpty(collection);
        }
        [Test]
        public void FindAllInPriceRangeShouldReturnCorrectCollectionInCorrectOrder()
        {
            //Arrange
            AddMultipleProductsToProductStock();

            //Act
            var collection = this.productStock
                .FindAllInRange(4, 21)
                .ToList();
            //Assert
            Assert.That(collection.Count, Is.EqualTo(3));
            Assert.That(collection[0].Price, Is.EqualTo(20));
            Assert.That(collection[1].Price, Is.EqualTo(10));
            Assert.That(collection[2].Price, Is.EqualTo(5));

        }

        //----- FindAllByPrice Method Tests -----

        [Test]
        public void FindAllByPriceShouldReturnEmptyCollectionWhenNoProductsMatch()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var collection = this.productStock.FindAllByPrice(333);
            //Assert
            Assert.IsEmpty(collection);
        }
        [Test]
        public void FindAllByPriceShouldReturnAllProductsThatMatch()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var collection = this.productStock
                .FindAllByPrice(10)
                .ToList();
            //Assert
            Assert.That(collection.Count, Is.EqualTo(1));
            Assert.That(collection[0].Label, Is.EqualTo("1"));
        }

        //----- FindMostExpensiveProduct Method Tests -----
        [Test]
        public void FindMostExpensiveProductShouldReturnCorrectProduct()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();
            //Act
            var actualProduct = this.productStock.FindMostExpensiveProduct();
            //Assert
            Assert.IsNotNull(actualProduct);
            Assert.That(actualProduct.Label, Is.EqualTo("4"));
            Assert.That(actualProduct.Price, Is.EqualTo(400));
            Assert.That(actualProduct.Quantity, Is.EqualTo(4));

        }

        [Test]
        public void FindMostExpensiveProductShouldThrowExceptionWhenNoProducts()
        {
            //Assert
            Assert.That(() =>
            {
                //Arrange & Act
                this.productStock.FindMostExpensiveProduct();
            },
            Throws
            .Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("ProductStock is empty."));
        }

        //----- FindAllByQuantity Method Tests -----
        [Test]
        public void FindAllByQuantityShouldReturnValidCollectionWithWantedQuantity()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();
            //Act
            var collection = this.productStock
                .FindAllByQuantity(5)
                .ToList();
            //Assert
            Assert.IsNotNull(collection);
            Assert.That(collection[0].Label, Is.EqualTo("5"));
            Assert.That(collection[1].Label, Is.EqualTo("6"));
        }
        [Test]
        public void FindAllByQuantityShouldReturnEmptyCollection()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var collection = this.productStock.FindAllByQuantity(6);
            //Assert
            Assert.IsEmpty(collection);
        }

        //----- GetEnumerator Method Tests -----
        public void GetEnumeratorShouldReturnCorrectInsertionOrder()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var collection = this.productStock.ToList();
            //Assert
            Assert.That(collection[0].Label, Is.EqualTo("1"));
            Assert.That(collection[1].Label, Is.EqualTo("2"));
            Assert.That(collection[2].Label, Is.EqualTo("3"));
            Assert.That(collection[3].Label, Is.EqualTo("4"));
            Assert.That(collection[4].Label, Is.EqualTo("5"));
            Assert.That(collection[5].Label, Is.EqualTo("6"));
        }

        //----- this[int index] Method Tests -----
        [Test]
        public void GetByIndexShouldReturnCorrectProduct()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Act
            IProduct foundProduct = this.productStock[0];
            //Assert
            Assert.IsNotNull(foundProduct);
            Assert.AreEqual(this.product.Label, foundProduct.Label);
            Assert.AreEqual(this.product.Price, foundProduct.Price);
            Assert.AreEqual(this.product.Quantity, foundProduct.Quantity);
        }
        [Test]
        public void GetByIndexShouldThrowExceptionWhenProductDoesNotExist()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Assert
            Assert.That(
                //Act
                () => this.productStock[1],
            Throws
            .Exception.InstanceOf<IndexOutOfRangeException>()
            .With.Message.EqualTo($"Product index does not exist."));
        }
        [Test]
        public void GetByIndexShouldThrowExceptionWhenIndexIsBelowZero()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Assert
            Assert.That(
                //Act
                () => this.productStock[-1],
            Throws
            .Exception.InstanceOf<IndexOutOfRangeException>()
            .With.Message.EqualTo($"Product index does not exist."));
        }

        [Test]
        public void SetIndexShouldChangeProduct()
        {
            const string productLabel = "NewLabel";
            //Arrange
            this.AddMultipleProductsToProductStock();
            //Act
            this.productStock[3] = new Product(productLabel, 50, 3);
            //Assert
            IProduct foundProduct = this.productStock.Find(3);

            Assert.IsNotNull(foundProduct);
            Assert.AreEqual(productLabel, foundProduct.Label);
            Assert.AreEqual(50, foundProduct.Price);
            Assert.AreEqual(3, foundProduct.Quantity);
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenProductDoesNotExist()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Assert
            Assert.That(
                //Act
                () => this.productStock[1] = new Product(ProductLabel, 10, 10),
           Throws
            .Exception.InstanceOf<IndexOutOfRangeException>()
            .With.Message.EqualTo("Product index does not exist."));
        }
        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsBelowZero()
        {
            //Arrange
            this.productStock.Add(this.product);
            //Assert
            Assert.That(
                //Act
                () => this.productStock[-1] = new Product(ProductLabel, 10, 10),
            Throws
            .Exception.InstanceOf<IndexOutOfRangeException>()
            .With.Message.EqualTo("Product index does not exist.")); ;
        }


        private void AddMultipleProductsToProductStock()
        {
            this.productStock.Add(new Product("1", 10, 1));
            this.productStock.Add(new Product("2", 5, 2));
            this.productStock.Add(new Product("3", 20, 3));
            this.productStock.Add(new Product("4", 400, 4));
            this.productStock.Add(new Product("5", 400, 5));
            this.productStock.Add(new Product("6", 50, 5));
        }

        //Arrange

        //Act

        //Assert
    }
}
