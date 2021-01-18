namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private const string aqName = "Aqua";
        private const int aqCapacity = 2;
        private Aquarium aquarium;

        [Test]
        public void TestIfFishConstructorWorksCorrectly()
        {
            string expectedName = "ImFish";
            bool expectedState = true;
            Fish fish = new Fish(expectedName);

            string actualName = fish.Name;
            bool actualState = fish.Available;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedState, actualState);
        }
        [Test]
        public void TestIfAquariumConstructorWorksCorrectly()
        {
            this.aquarium = new Aquarium(aqName, aqCapacity);

            string aName = aquarium.Name;
            int aCapacity = aquarium.Capacity;

            Assert.AreEqual(aqName, aName);
            Assert.AreEqual(aqCapacity, aCapacity);
        }
        //----- Test Name settter -----
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ShouldThrowExceptionIfInvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.aquarium = new Aquarium(name, aqCapacity);
            });
        }

        //----- Test Capacity settter -----
        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void ShouldThrowExceptionIfNegativeCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.aquarium = new Aquarium(aqName, capacity);
            });
        }

        //----- Test Add Method -----
        [Test]
        public void TestIfAddMethodIncreasesCount()
        {
            //Arrange
            int expCount = 2;
            this.aquarium = new Aquarium(aqName, aqCapacity);
            //Act
            this.aquarium.Add(new Fish("Nemo"));
            this.aquarium.Add(new Fish("Dorry"));
            //Assert
            int actCount = this.aquarium.Count;
            Assert.AreEqual(expCount, actCount);
        }
        [Test]
        public void TestIfAddMethodThrowsExceptionIfFull()
        {
            //Arrange
            this.aquarium = new Aquarium(aqName, 1);
            this.aquarium.Add(new Fish("Nemo"));

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.aquarium.Add(new Fish("Dorry"));
            });
        }

        //----- Test Remove Method -----
        [Test]
        public void TestIfRemoveMethodDecreasesCountCorrectly()
        {
            int expCount = 1;
            this.aquarium = new Aquarium(aqName, aqCapacity);
            this.aquarium.Add(new Fish("Dorry"));
            this.aquarium.Add(new Fish("Nemo"));

            //Act
            this.aquarium.RemoveFish("Nemo");
            //Assert
            int actCount = this.aquarium.Count;
            Assert.AreEqual(expCount, actCount);
        }
        [Test]
        public void TestIfRemoveMethodThrowsExceptionWhenFishIsNull()
        {
            this.aquarium = new Aquarium(aqName, aqCapacity);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.aquarium.RemoveFish("Nemo");
            });
        }

        //----- Test SellFish Method -----
        [Test]
        public void TestIfValidFishIsSoldCorrectly()
        {
            //Arrange
            bool expAvailability = false;
            Fish fish = new Fish("Nemo");
            this.aquarium = new Aquarium(aqName, aqCapacity);
            this.aquarium.Add(fish);

            //Act
            Fish soldFish = this.aquarium.SellFish("Nemo");

            //Assert
            Assert.AreEqual(expAvailability, soldFish.Available);
        }
        [Test]
        public void TestIfSellFishThrowsExceptionWhenIfInvalidFish()
        {
            this.aquarium = new Aquarium(aqName, aqCapacity);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.aquarium.SellFish("Nemo");
            });
        }

        //----- Test Report Method -----
        [Test]
        public void TestIfReportReturnsValidMessage()
        {
            //Arrange
            Fish fish = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            this.aquarium = new Aquarium(aqName, aqCapacity);

            this.aquarium.Add(fish);
            this.aquarium.Add(fish2);

            string expFishNames = $"Nemo, Nemo2";
            string expReportMsg = $"Fish available at {aqName}: {expFishNames}";
            //Act
            string actReportMsg = this.aquarium.Report();
            //Assert
            Assert.AreEqual(expReportMsg, actReportMsg);
        }
    }
}
