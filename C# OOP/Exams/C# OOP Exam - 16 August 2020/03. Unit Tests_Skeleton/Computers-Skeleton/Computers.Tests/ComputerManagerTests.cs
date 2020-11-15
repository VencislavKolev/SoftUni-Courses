using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;

        private readonly string manufacturer = "Apple";
        private readonly string model = "MacBook";
        private readonly decimal price = 1299m;
        [SetUp]
        public void Setup()
        {
            this.computerManager = new ComputerManager();
            this.computer = new Computer(manufacturer, model, price);
        }

        [Test]
        public void TestIfComputerCtorWorksCorrectly()
        {
            string eManifacturer = "Apple";
            string eModel = "MacBook Pro";
            decimal ePrice = 1299m;

            Computer computer = new Computer(eManifacturer, eModel, ePrice);

            Assert.AreEqual(eManifacturer, computer.Manufacturer);
            Assert.AreEqual(eModel, computer.Model);
            Assert.AreEqual(ePrice, computer.Price);
        }
        [Test]
        public void TestIfComputerManagerCtorWorksCorrectly()
        {
            this.computerManager = new ComputerManager();

            Assert.IsNotNull(this.computerManager);
        }
        [Test]
        public void AddComputerShouldThrowExceptionWhenNullObject()
        {
            Computer nullComputer = null;

            Assert.That(() =>
            {
                this.computerManager.AddComputer(nullComputer);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void AddComputerShouldThrowExceptionWhenExistingObject()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.That(() =>
            {
                this.computerManager.AddComputer(this.computer);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("This computer already exists."));
        }
        [Test]
        public void AddComputerShouldIncreaseCount()
        {
            int eCount = 1;
            this.computerManager.AddComputer(this.computer);

            int aCount = this.computerManager.Count;

            Assert.AreEqual(eCount, aCount);
        }
        [Test]
        public void ComputersCollectionShouldBeValid()
        {
            this.computerManager.AddComputer(this.computer);
            ICollection<Computer> eCollection = new List<Computer>()
            {
                this.computer
            };

            var aCollection = this.computerManager.Computers;

            CollectionAssert.AreEqual(eCollection, aCollection);
        }
        [Test]
        public void GetComputerShouldThrowExceptionWhenNullManufacturer()
        {
            Assert.That(() =>
            {
                this.computerManager.GetComputer(null, "model");
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void GetComputerShouldThrowExceptionWhenNullModel()
        {
            Assert.That(() =>
            {
                this.computerManager.GetComputer("manufacturer", null);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void GetComputerShouldThrowExceptionWhenNullComputer()
        {
            Assert.That(() =>
            {
                this.computerManager.GetComputer("None", "None");
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("There is no computer with this manufacturer and model."));
        }
        [Test]
        public void GetComputerShouldReturnCorrectComputer()
        {
            this.computerManager.AddComputer(this.computer);

            Computer computer = this.computerManager.GetComputer(manufacturer, model);

            Assert.AreEqual(manufacturer, computer.Manufacturer);
            Assert.AreEqual(model, computer.Model);
            Assert.AreEqual(price, computer.Price);
        }
        [Test]
        public void RemoveComputerShouldReturnValidComputer()
        {
            this.computerManager.AddComputer(this.computer);

            Computer computer = this.computerManager.RemoveComputer(manufacturer, model);

            Assert.AreEqual(manufacturer, computer.Manufacturer);
            Assert.AreEqual(model, computer.Model);
            Assert.AreEqual(price, computer.Price);
        }
        [Test]
        public void RemoveComputerShouldThrowExceptionWhenNullManufacturer()
        {
            Assert.That(() =>
            {
                this.computerManager.RemoveComputer(null, "model");
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void RemoveComputerShouldThrowExceptionWhenNullModel()
        {
            Assert.That(() =>
            {
                this.computerManager.RemoveComputer("manufacturer", null);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void GetComputersByManufacturerShouldReturnValidCollection()
        {
            ICollection<Computer> expCollection = new List<Computer>();
            for (int i = 1; i < 4; i++)
            {
                Computer computer = new Computer(manufacturer, model + i, price + i);
                this.computerManager.AddComputer(computer);
                expCollection.Add(computer);
            }
            ICollection<Computer> actCollection = this.computerManager.GetComputersByManufacturer(manufacturer);

            CollectionAssert.AreEqual(expCollection, actCollection);
        }
        [Test]
        public void GetComputerByManufacturerShouldThrowExceptionWhenNullManufacturer()
        {
            Assert.That(() =>
            {
                this.computerManager.GetComputersByManufacturer(null);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }
    }
}