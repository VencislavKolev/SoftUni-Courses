namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ComputerTests
    {
        private Computer computer;
        private string computerName = "MyPC";
        [SetUp]
        public void Setup()
        {
            this.computer = new Computer(computerName);
        }

        [Test]
        public void TestIfPartCtorWorksCorrectly()
        {
            string eName = "SomeName";
            decimal ePrice = 10m;

            Part part = new Part(eName, ePrice);

            Assert.AreEqual(eName, part.Name);
            Assert.AreEqual(ePrice, part.Price);
        }
        [Test]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        public void NameShouldThrowExceptionWhenNullOrWhiteSpace(string name)
        {
            Assert.That(() =>
            {
                Computer computer = new Computer(name);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenNullPart()
        {
            Part part = null;

            Assert.That(() =>
            {
                this.computer.AddPart(part);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("Cannot add null!"));
        }
        [Test]
        public void AddMethodShouldAddElementToCollection()
        {
            int eCount = 1;
            Part part = new Part("Sensor", 10m);

            this.computer.AddPart(part);

            int aCount = this.computer.Parts.Count;
            Assert.AreEqual(eCount, aCount);
        }
        [Test] 
        public void TotalPriceShouldReturnCorrectPrice()
        {
            Part part1 = new Part("Sensor", 10m);
            Part part2 = new Part("Sensor2", 20m);
            decimal eSum = 30m;

            this.computer.AddPart(part1);
            this.computer.AddPart(part2);

            decimal aSum = this.computer.TotalPrice;
            Assert.AreEqual(eSum, aSum);
        }
        [Test]
        public void RemoveShouldReturnFalseWhenNonExistingPart()
        {
            bool eRes = false;
            Part part1 = new Part("Sensor", 10m);

            bool aRes = this.computer.RemovePart(part1);

            Assert.AreEqual(eRes, aRes);
        }
        [Test]
        public void RemoveShouldReturnTrueWhenRemovingExistingPart()
        {
            bool eRes = true;
            Part part1 = new Part("Sensor", 10m);
            this.computer.AddPart(part1);

            bool aRes = this.computer.RemovePart(part1);

            Assert.AreEqual(eRes, aRes);
        }
        [Test]
        public void GetPartShouldReturnNullPart()
        {
            Part aPart = this.computer.GetPart("None");
            Assert.IsNull(aPart);
        }
        [Test]
        public void GetPartShouldReturnValidPart()
        {
            Part ePart = new Part("Sensor", 10m);
            this.computer.AddPart(ePart);

            Part aPart = this.computer.GetPart(ePart.Name);
            Assert.AreEqual(ePart, aPart);
        }
    }
}