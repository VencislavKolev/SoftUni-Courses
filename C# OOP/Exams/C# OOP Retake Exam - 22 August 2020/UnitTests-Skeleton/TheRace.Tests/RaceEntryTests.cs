using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void TestIfUnitCarCtorWorksCorrectly()
        {
            //Arrange
            string expModel = "E36";
            int expHorsePower = 150;
            double expCubicCentimeters = 2000;
            //Act
            UnitCar unitCar = new UnitCar(expModel, expHorsePower, expCubicCentimeters);
            //Assert
            Assert.AreEqual(expModel, unitCar.Model);
            Assert.AreEqual(expHorsePower, unitCar.HorsePower);
            Assert.AreEqual(expCubicCentimeters, unitCar.CubicCentimeters);
        }

        [Test]
        public void TestIfUnitDriverCtorWorksCorrectly()
        {
            //Arrange
            string expModel = "E36";
            int expHorsePower = 150;
            double expCubicCentimeters = 2000;
            UnitCar unitCar = new UnitCar(expModel, expHorsePower, expCubicCentimeters);
            string expName = "DriverName";
            //Act
            UnitDriver unitDriver = new UnitDriver(expName, unitCar);
            //Assert
            Assert.AreEqual(expName, unitDriver.Name);
            Assert.AreEqual(expModel, unitCar.Model);
            Assert.AreEqual(expHorsePower, unitCar.HorsePower);
            Assert.AreEqual(expCubicCentimeters, unitCar.CubicCentimeters);
        }
        [Test]
        public void NameSetterShouldThrowExceptionWhenNameIsNull()
        {
            //Arrange
            string expModel = "E36";
            int expHorsePower = 150;
            double expCubicCentimeters = 2000;
            UnitCar unitCar = new UnitCar(expModel, expHorsePower, expCubicCentimeters);
            string nullName = null;
            //Act
            //Assert
            Assert.That(() =>
            {
                UnitDriver unitDriver = new UnitDriver(nullName, unitCar);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void TestIfPropertyCarReturnCorrectCar()
        {
            //Arrange
            string expModel = "E36";
            int expHorsePower = 150;
            double expCubicCentimeters = 2000;
            UnitCar unitCar = new UnitCar(expModel, expHorsePower, expCubicCentimeters);
            string expName = "DriverName";
            UnitDriver unitDriver = new UnitDriver(expName, unitCar);
            //Act
            UnitCar car = unitDriver.Car;
            //Assert
            Assert.AreEqual(unitCar, car);
        }
        //-----
        [Test]
        public void TestIfRaceEntryCtorWorksCorrectly()
        {
            int expCount = 0;
            RaceEntry testRaceEntry = new RaceEntry();

            //Assert
            Assert.AreEqual(expCount, testRaceEntry.Counter);
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverAlreadyExists()
        {
            //Arrange
            string expModel = "E36";
            int expHorsePower = 150;
            double expCubicCentimeters = 2000;
            UnitCar unitCar = new UnitCar(expModel, expHorsePower, expCubicCentimeters);
            string expName = "DriverName";
            UnitDriver unitDriver = new UnitDriver(expName, unitCar);
            this.raceEntry.AddDriver(unitDriver);
            int expCount = 1;
            //Assert
            Assert.That(() =>
            {
                this.raceEntry.AddDriver(unitDriver);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo($"Driver {unitDriver.Name} is already added."));
            Assert.AreEqual(expCount, this.raceEntry.Counter);
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverIsNull()
        {
            //Arrange
            UnitDriver unitDriver = null;

            //Assert
            Assert.That(() =>
            {
                this.raceEntry.AddDriver(unitDriver);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("Driver cannot be null."));
        }
        [Test]
        public void AddDriverShouldPsycallyAddDriver()
        {
            //Arrange
            string expModel = "E36";
            int expHorsePower = 150;
            double expCubicCentimeters = 2000;
            UnitCar unitCar = new UnitCar(expModel, expHorsePower, expCubicCentimeters);
            string expName = "DriverName";
            UnitDriver unitDriver = new UnitDriver(expName, unitCar);
            int expCount = 1;
            string expResult = $"Driver {expName} added in race.";
            //Act
            string actResult = this.raceEntry.AddDriver(unitDriver);
            //Assert
            Assert.AreEqual(expCount, this.raceEntry.Counter);
            Assert.AreEqual(expResult, actResult);
        }

        //---
        [Test]
        public void CalcAvHorsePowerShouldThrowExceptionWhenNotEnoughDrivers()
        {
            Assert.That(() =>
            {
                this.raceEntry.CalculateAverageHorsePower();
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("The race cannot start with less than 2 participants."));
        }
        [Test]
        public void CalcAvHorsePowerShouldReturnCorrectResult()
        {
            //Arrange

            UnitCar unitCar = new UnitCar("Model1", 100, 2000);
            UnitCar unitCar2 = new UnitCar("Model2", 50, 2000);
            UnitDriver unitDriver = new UnitDriver("Driver1", unitCar);
            UnitDriver unitDriver2 = new UnitDriver("Driver2", unitCar2);
            this.raceEntry.AddDriver(unitDriver);
            this.raceEntry.AddDriver(unitDriver2);
            double expRes = 75;
            //Act
            double actRes = this.raceEntry.CalculateAverageHorsePower();
            //Assert
            Assert.AreEqual(expRes, actRes);
        }
    }
}

// Latest Try
using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        //UnitCar Test
        [Test]
        public void UnitCarCtorShouldWorkCorrectly()
        {
            //Arrange
            string eModel = "Corsa";
            int eHP = 80;
            double eCubCentimeters = 1200;

            //Act
            UnitCar car = new UnitCar(eModel, eHP, eCubCentimeters);
            //Assert
            Assert.AreEqual(eModel, car.Model);
            Assert.AreEqual(eHP, car.HorsePower);
            Assert.AreEqual(eCubCentimeters, car.CubicCentimeters);
        }

        // UnitDriver Tests
        [Test]
        public void UnitDriverCtorShouldWorkCorrectly()
        {
            //Arrange
            string eName = "ValidName";
            string eModel = "Corsa";
            int eHP = 80;
            double eCubCentimeters = 1200;
            UnitCar car = new UnitCar(eModel, eHP, eCubCentimeters);
            //Act
            UnitDriver unitDriver = new UnitDriver(eName, car);
            //Assert
            Assert.AreEqual(eName, unitDriver.Name);
        }
        [Test]
        public void NameShouldThrowExceptionWhenNull()
        {
            //Arrange
            string eModel = "Corsa";
            int eHP = 80;
            double eCubCentimeters = 1200;
            UnitCar car = new UnitCar(eModel, eHP, eCubCentimeters);
            //Act

            //Assert
            Assert.That(() =>
            {
                UnitDriver unitDriver = new UnitDriver(null, car);
            }, Throws.Exception.InstanceOf<ArgumentNullException>());
        }

        //Race Entry Tests
        [Test]
        public void TestEntryCtorShouldWorkCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverIsNull()
        {
            //Assert
            Assert.That(() =>
            {
                //Act
                raceEntry.AddDriver(null);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("Driver cannot be null."));
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverAlreadyExists()
        {
            //Arrange
            UnitDriver unitDriver = new UnitDriver("First", new UnitCar("Model", 100, 1000));
            this.raceEntry.AddDriver(unitDriver);

            //Assert
            Assert.That(() =>
            {
                this.raceEntry.AddDriver(unitDriver);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo($"Driver {unitDriver.Name} is already added."));
        }

        [Test]
        public void AddDriverShouldWorkCorrectly()
        {
            //Arrange
            UnitDriver unitDriver = new UnitDriver("First", new UnitCar("Model", 100, 1000));
            string expResult = $"Driver {unitDriver.Name} added in race.";
            int expCount = 1;
            //Act
            string result = this.raceEntry.AddDriver(unitDriver);
            //Assert
            Assert.AreEqual(expResult, result);
            Assert.AreEqual(expCount, this.raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWhenNotEnoughParticipants()
        {
            //Assert
            Assert.That(() =>
            {
                //Act
                this.raceEntry.CalculateAverageHorsePower();
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("The race cannot start with less than 2 participants."));
        }
        [Test]
        public void CalculateAverageHorsePowerShouldReturnValidResult()
        {
            //Arrange
            UnitDriver first = new UnitDriver("First", new UnitCar("Model", 100, 1000));
            UnitDriver second = new UnitDriver("Second", new UnitCar("Model2", 50, 1000));
            this.raceEntry.AddDriver(first);
            this.raceEntry.AddDriver(second);
            double expResult = (100 + 50) / 2;

            //Act
            double result = this.raceEntry.CalculateAverageHorsePower();

            //Assert
            Assert.AreEqual(expResult, result);
        }

    }
}