namespace Computers.Tests
{
    using System;
    using NUnit.Framework;

    public class ComputerTests
    {
        private Computer computer;
        private Part part;
        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("MacBook");
            this.part = new Part("RAM", 300);
        }

        [Test]
        public void PartCtorShouldWorkCorrectly()
        {
            string eName = "Mouse";
            decimal ePrice = 10M;
            Part part = new Part(eName, ePrice);

            Assert.AreEqual(eName, part.Name);
            Assert.AreEqual(ePrice, part.Price);
        }

        [Test]
        public void ComputerCtorShouldWorkCorrectly()
        {
            Computer computer = new Computer("ValidName");
            Assert.IsNotNull(computer);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        public void NameSetterShouldThrowExceptionWhenNullEmptyWhitespace(string name)
        {
            Assert.That(() =>
            {
                Computer computer = new Computer(name);
            },Throws.Exception.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void NameGetterShouldWorkCorrectly()
        {
            string eName = "MacBook";
            Computer computer = new Computer(eName);

            Assert.AreEqual(eName, computer.Name);
        }
        [Test]
        public void AddPartShouldThrowExceptionWhenPartIsNull()
        {
            Assert.That(() =>
            {
                this.computer.AddPart(null);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("Cannot add null!"));
        }

        [Test]
        public void AddPartShouldWorkCorrectly()
        {
            this.computer.AddPart(this.part);
            int eCount = 1;

            int aCount = this.computer.Parts.Count;

            Assert.AreEqual(eCount, aCount);
        }

        [Test]
        public void TotalPriceShouldReturnCorrectSum()
        {
            Part partOne = new Part("SSD", 300);
            Part partTwo = new Part("RAM", 200);
            this.computer.AddPart(partOne);
            this.computer.AddPart(partTwo);

            decimal ePrice = partOne.Price + partTwo.Price;

            decimal aPrice = this.computer.TotalPrice;

            Assert.AreEqual(ePrice, aPrice);
        }
        [Test]
        public void RemovePartShouldReturnTrue()
        {
            Part partOne = new Part("SSD", 300);
            this.computer.AddPart(part);

            Assert.IsTrue(this.computer.RemovePart(part));
        }
        [Test]
        public void RemovePartShouldReturnFalse()
        {
            Assert.IsFalse(this.computer.RemovePart(new Part("none",123)));
        }

        [Test] 
        public void GetPartShouldReturnValidPart()
        {
            Part partOne = new Part("SSD", 300);
            this.computer.AddPart(partOne);

            Part aPart = this.computer.GetPart(partOne.Name);

            Assert.AreEqual(partOne.Name, aPart.Name);
            Assert.AreEqual(partOne.Price, aPart.Price);
        }
        [Test]
        public void GetPartShouldReturnNull()
        {
            Part aPart = this.computer.GetPart("NonExistingPart");
            Assert.IsNull(aPart);
        }
    }
}