//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            this.car = new Car("Fiat", "Punto", 10, 50);
        }
        //-----Constructor Test-----
        [Test]
        public void TestIfConstructorsWorkCorrectly()
        {
            string expectedMake = "Fiat";
            string expectedModel = "Punto";
            double expectedFuelConsumption = 10;
            double expectedFuelCapacity = 50;
            double expectedFuelAmount = 0;

            Car car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumption = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        //-----Make Test-----

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestIfMakeIsNullEmptyThrowsException(string make)
        {
            string model = "Punto";
            double fuelConsumption = 10;
            double fuelCapacity = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        //-----Model Test-----

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestIfModelIsNullEmptyThrowsException(string model)
        {
            string make = "Fiat";
            double fuelConsumption = 10;
            double fuelCapacity = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        //-----FuelConsumption Test-----

        [Test]
        [TestCase(0)]
        [TestCase(double.MinValue)]
        public void TestIfFuelConsumptionThrowsExceptionWhenZeroOrNegative(double fuelConsumption)
        {
            string make = "Fiat";
            string model = "Punto";
            double fuelCapacity = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        //-----FuelCapacity Test-----

        [Test]
        [TestCase(0)]
        [TestCase(double.MinValue)]
        public void TestIfFuelCapacityThrowsExceptionWhenZeroOrNegative(double fuelCapacity)
        {
            string make = "Fiat";
            string model = "punto";
            double fuelConsumption = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        //-----Refuel Method Test-----

        [Test]
        [TestCase(0)]
        [TestCase(double.MinValue)]
        public void TestIfRefuelMethodThrowsExceptionIfZeroOrNegativeFuelPassed(double refuelQty)
        {

            Assert.That(() =>
            {
                car.Refuel(refuelQty);
            },
            Throws.ArgumentException
            .With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        [TestCase(5)]
        [TestCase(33)]
        [TestCase(49)]
        public void TestIfFuelAmountIsSetCorrectlyAfterRefuel(double fuel)
        {
            //Act
            this.car.Refuel(fuel);
            //Assert
            Assert.AreEqual(fuel, this.car.FuelAmount);

        }

        [Test]
        [TestCase(55)]
        [TestCase(100.5)]
        public void TestIfFuelQuantityIsCorrectAfterOverRefueling(double fuel)
        {
            //Arrange
            double expectedAmount = car.FuelCapacity;
            //Act
            this.car.Refuel(fuel);
            double actualAmount = this.car.FuelAmount;
            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        //-----Drive Method Test-----

        [Test]
        [TestCase(9999)]
        public void TestIfDriveMethodThrowsExceptionWhenFuelNeededIsBiggerThanFuelAmount(double distance)
        {
            this.car.Refuel(10);

            Assert.That(() =>
            {
                this.car.Drive(distance);
            },
            Throws.InvalidOperationException
            .With.Message.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        [TestCase(50)]
        public void TestIfDriveMethodSetsFuelAmountCorrectlyIfAbleToGoTheDistance(double distance)
        {
            this.car.Refuel(10);
            this.car.Drive(distance);

            int expectedFuelAmount = 5;

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }
    }
}