namespace INStock.Tests
{
    using System;
    using NUnit.Framework;

    public class ProductTests
    {
        //Arrange

        //Act

        //Assert
        [Test]
        public void QuantityCannotBeLessThanZero()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {  //Arrange & Act
                Product product = new Product("TestProduct", 10, -1);
            }, "Quantity cannot be less than zero");
        }

        [Test]
        public void PriceCannotBeLessThanZero()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {  //Arrange & Act
                Product product = new Product("TestProduct", -10, 1);
            }, "Price cannot be less than zero");
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void LabelCannotBeNullOrEmpty(string label)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {  //Arrange & Act
                Product product = new Product(label, 10, 1);
            }, "Label cannot be null or empty.");
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsCorrect()
        {
            //Arrange
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 5, 1);
            //Act
            var correctOrderResult = secondProduct.CompareTo(firstProduct);
            //Assert
            Assert.That(correctOrderResult < 0, Is.True);
        }
        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsIncorrect()
        {
            //Arrange
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 5, 1);
            //Act
            var incorrectOrderResult = firstProduct.CompareTo(secondProduct);
            //Assert
            Assert.That(incorrectOrderResult > 0, Is.True);
        }
        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsEqual()
        {
            //Arrange
            var firstProduct = new Product("Test 1", 10, 1);
            var secondProduct = new Product("Test 2", 10, 1);
            //Act
            var incorrectOrderResult = firstProduct.CompareTo(secondProduct);
            //Assert
            Assert.That(incorrectOrderResult == 0, Is.True);
        }
    }
}