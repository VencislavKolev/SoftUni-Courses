//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private const int MinAttackHP = 30;
        private const string TestName = "Vencislav";
        private const int TestDamage = 25;
        private const int TestHP = 50;

        [SetUp]
        public void Setup()
        {
        }
        //----- Test Constructor -----
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Vencislav";
            int expectedDamage = 25;
            int expectedHP = 50;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHP);
        }

        //----- Test Name setter-----
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TestIfNameSetterThrowsExceptionWhenInvalid(string name)
        {
            //Assert
            Assert.That(() =>
            {
                Warrior warrior = new Warrior(name, TestDamage, TestHP);
            },
            Throws.ArgumentException
            .With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        //----- Test Damage setter-----

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(int.MinValue)]
        public void TestIfDamageThrowsExceptionWhenZeroOrNegative(int damage)
        {
            //Assert
            Assert.That(() =>
            {
                Warrior warrior = new Warrior(TestName, damage, TestHP);
            },
            Throws.ArgumentException
            .With.Message.EqualTo("Damage value should be positive!"));
        }

        //----- Test HP setter-----

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void TestIfHPThrowsExceptionWhenNegative(int hp)
        {
            //Assert
            Assert.That(() =>
            {
                Warrior warrior = new Warrior(TestName, TestDamage, hp);
            },
            Throws.ArgumentException
            .With.Message.EqualTo("HP should not be negative!"));
        }

        //----- Test Attack Method -----

        [Test]
        [TestCase(30)]
        [TestCase(0)]
        public void TestIfHPisEqualOrBelowTheRequiredMinimum(int invalidHPforAttack)
        {
            //Arrange
            Warrior warrior = new Warrior(TestName, TestDamage, invalidHPforAttack);

            string secondName = "Strongmen";
            int secondDamage = 45;
            int secondHP = 20;
            Warrior defender = new Warrior(secondName, secondDamage, secondHP);

            //Assert
            Assert.That(() =>
                {
                    warrior.Attack(defender);
                },
                Throws.InvalidOperationException
                .With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void TestIfDefenderThrowsExceptionWhenHPIsBelowMinimum()
        {
            //Arrange
            Warrior warrior = new Warrior(TestName, TestDamage, TestHP);

            string secondName = "Strongmen";
            int secondDamage = 45;
            int secondHP = 20;
            Warrior defender = new Warrior(secondName, secondDamage, secondHP);

            //Assert
            Assert.That(() =>
            {
                warrior.Attack(defender);
            },
            Throws.InvalidOperationException
            .With.Message.EqualTo($"Enemy HP must be greater than {MinAttackHP} in order to attack him!"));
        }
        [Test]
        [TestCase(31)]
        [TestCase(44)]
        public void TestIfHPAreLessThanDefendersDamage(int lowerHP)
        {
            //Arrange
            Warrior warrior = new Warrior(TestName, TestDamage, lowerHP);

            string secondName = "Strongmen";
            int secondDamage = 45;
            int secondHP = 60;
            Warrior defender = new Warrior(secondName, secondDamage, secondHP);

            //Assert
            Assert.That(() =>
            {
                warrior.Attack(defender);
            },
            Throws.InvalidOperationException
            .With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }


        [Test]
        public void TestIfHPIsDecreasedCorrectlyAfterSuccessfulAttack()
        {
            string aName = "Attacker";
            int aDmg = 10;
            int aHP = 80;

            string dName = "Defender";
            int dDmg = 10;
            int dHP = 40;

            Warrior attacker = new Warrior(aName, aDmg, aHP);
            Warrior defender = new Warrior(dName, dDmg, dHP);

            //Act
            attacker.Attack(defender);
            int expectedAttackerHP = aHP - dDmg;
            int expectedDefenderHP = dHP - aDmg;

            //Assert
            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);

        }

        [Test]
        public void TestIfAttackerKilledDefender()
        {
            //Arrange
            string aName = "Attacker";
            int aDmg = 80;
            int aHP = 80;

            string dName = "Defender";
            int dDmg = 10;
            int dHP = 40;

            Warrior attacker = new Warrior(aName, aDmg, aHP);
            Warrior defender = new Warrior(dName, dDmg, dHP);

            //Act
            attacker.Attack(defender);
            int expectedDefenderHP = 0; //40 - 80 = -40 => 0

            //Assert
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}