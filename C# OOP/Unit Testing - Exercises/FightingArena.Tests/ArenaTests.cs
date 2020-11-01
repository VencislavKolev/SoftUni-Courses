using System;
//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private Warrior attacker;
        private Warrior defender;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior1 = new Warrior("WarriorOne", 10, 50);
            this.attacker = new Warrior("IamAttacker", 10, 80);
            this.defender = new Warrior("IamDefender", 5, 40);
        }
        //----- Test Constructor -----
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        //----- Test Enroll Method -----
        [Test]
        public void TestIfWarriorIsEnrolledSuccessfully()
        {
            //Act
            this.arena.Enroll(this.warrior1);
            //Assert
            Assert.That(this.arena.Warriors, Has.Member(this.warrior1));
        }

        [Test]
        public void TestIfEnrollIncreasesCount()
        {
            int expectedCount = 2;
            this.arena.Enroll(warrior1);
            this.arena.Enroll(new Warrior("Pesho", 33, 44));

            int actualCount = this.arena.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]
        public void TestIfEnrollThrowsExceptionWhenTryingToAddExistingWarrior()
        {
            this.arena.Enroll(warrior1);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior1);
            });
        }

        [Test]
        public void TestIfEnrollWarriorsWithSameNameThrowsException()
        {
            Warrior warrior1Copy = new Warrior(warrior1.Name, warrior1.Damage, warrior1.HP);
            this.arena.Enroll(warrior1);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior1Copy);
            });
        }

        [Test]
        public void TestIfAttackThrowsExceptionWithMissingAttacker()
        {
            this.arena.Enroll(this.defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
        }
        [Test]
        public void TestIfAttackThrowsExceptionWithMissingDefender()
        {
            this.arena.Enroll(this.attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
        }

        [Test]
        public void TestFightBetweenTwoValidWarriors()
        {
            //Arrange
            int expectedAttackerHP = this.attacker.HP - this.defender.Damage;
            int expectedDefenderHP = this.defender.HP - this.attacker.Damage;

            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            //Act
            this.arena.Fight(this.attacker.Name, this.defender.Name);
            //Assert
            Assert.AreEqual(expectedAttackerHP, this.attacker.HP);
            Assert.AreEqual(expectedDefenderHP, this.defender.HP);
        }
    }
}
