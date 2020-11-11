namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;
        [Test]
        public void TestIfRobotCtorWorksCorretcly()
        {
            //Arrange
            string expName = "SomeName";
            int expMaxBattery = 100;
            //Act
            Robot robot = new Robot(expName, expMaxBattery);
            //Assert
            Assert.AreEqual(expName, robot.Name);
            Assert.AreEqual(expMaxBattery, robot.MaximumBattery);
            Assert.AreEqual(expMaxBattery, robot.Battery);
        }

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        public void TestIfRobotManagementCtorWorksCorrectly(int capacity)
        {
            //Arrange & Act
            RobotManager robotManager = new RobotManager(capacity);
            //Assert
            Assert.AreEqual(capacity, robotManager.Capacity);
            Assert.IsNotNull(robotManager);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenBelowZero()
        {
            Assert.That(() =>
            {
                this.robotManager = new RobotManager(-1);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("Invalid capacity!"));
        }

        [Test]
        public void CountShouldReturnCorrectNumber()
        {
            this.robotManager = new RobotManager(5);
            int expCount = 0;
            int actCount = this.robotManager.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void AddRobotShouldThrowExceptionWhenNameAlreadyExists()
        {
            this.robotManager = new RobotManager(3);
            string expName = "SomeName";
            int expMaxBattery = 100;
            Robot robot = new Robot(expName, expMaxBattery);
            this.robotManager.Add(robot);

            Robot robot2 = new Robot(expName, 50);
            Assert.That(() =>
            {
                this.robotManager.Add(robot2);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo($"There is already a robot with name {robot2.Name}!"));
        }
        [Test]
        public void AddRobotShouldThrowExceptionWhenNotEnoughSpace()
        {
            this.robotManager = new RobotManager(1);
            string expName = "SomeName";
            int expMaxBattery = 100;
            Robot robot = new Robot(expName, expMaxBattery);
            this.robotManager.Add(robot);

            Robot robot2 = new Robot("NewRobot", 50);
            Assert.That(() =>
            {
                this.robotManager.Add(robot2);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("Not enough capacity!"));
        }
        [Test]
        public void AddRobotShouldAddTheRobotSuccessfully()
        {
            //Arrange
            this.robotManager = new RobotManager(1);
            string expName = "SomeName";
            int expMaxBattery = 100;
            Robot robot = new Robot(expName, expMaxBattery);
            int expCount = 1;
            //Act
            this.robotManager.Add(robot);
            //Assert
            int actCount = this.robotManager.Count;
            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void RemoveRobotShouldThrowExceptionWhenNull()
        {
            //Arrange
            this.robotManager = new RobotManager(2);
            string name = "NonExisting";
            //Act
            //Assert
            Assert.That(() =>
            {
                this.robotManager.Remove(name);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo($"Robot with the name {name} doesn't exist!"));
        }

        [Test]
        public void RemoveRobotShouldDecreaseCount()
        {
            //Arrange
            this.robotManager = new RobotManager(1);
            string expName = "SomeName";
            int expMaxBattery = 100;
            Robot robot = new Robot(expName, expMaxBattery);
            this.robotManager.Add(robot);
            int expCount = 0;
            //Act
            this.robotManager.Remove(expName);
            //Assert
            int actCount = this.robotManager.Count;
            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void WorkShouldThrowExceptionWhenRobotIsNull()
        {
            this.robotManager = new RobotManager(3);
            string name = "False";
            Assert.That(() =>
            {
                this.robotManager.Work(name,"WhatJob",10);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo($"Robot with the name {name} doesn't exist!"));
        }
        [Test]
        public void WorkShouldThrowExceptionWhenRobotDoesntHaveEnoughEnergy()
        {
            //Arrange
            this.robotManager = new RobotManager(1);
            string expName = "SomeName";
            int expMaxBattery = 100;
            Robot robot = new Robot(expName, expMaxBattery);
            this.robotManager.Add(robot);

            Assert.That(() =>
            {
                this.robotManager.Work(expName, "WhatJob", 101);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo($"{robot.Name} doesn't have enough battery!"));
        }
        [Test]
        public void WorkShouldDecreaseRobotEnergy()
        {
            //Arrange
            this.robotManager = new RobotManager(1);
            string expName = "SomeName";
            int maxBattery = 100;
            Robot robot = new Robot(expName, maxBattery);
            this.robotManager.Add(robot);
            int expBattery = 50;
            //Act
            this.robotManager.Work(expName, "WhatJob", 50);
            //Assert
            int actBattery = robot.Battery;
            Assert.AreEqual(expBattery, actBattery);
        }
        [Test]
        public void ChargeShouldThrowExceptionWhenRobotIsNull()
        {
            this.robotManager = new RobotManager(3);
            string name = "False";
            Assert.That(() =>
            {
                this.robotManager.Charge(name);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo($"Robot with the name {name} doesn't exist!"));
        }
        [Test]
        public void ChargeShouldBoostRobotEnergyToMaximum()
        {
            //Arrange
            this.robotManager = new RobotManager(1);
            string expName = "SomeName";
            int maxBattery = 100;
            Robot robot = new Robot(expName, maxBattery);
            this.robotManager.Add(robot);
            int expBattery = 100;
            //Act
            this.robotManager.Work(expName, "WhatJob", 50);
            this.robotManager.Charge(expName);
            //Assert
            int actBattery = robot.Battery;
            Assert.AreEqual(expBattery, actBattery);
        }
    }
}
