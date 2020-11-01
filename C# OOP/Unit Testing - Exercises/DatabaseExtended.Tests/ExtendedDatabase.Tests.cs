//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int DatabaseCapacity = 16;

        private /*ExtendedDatabase.*/ExtendedDatabase extendedDatabase;
        private Person[] initialPeople;


        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase();
            this.initialPeople = new Person[]
        {
            new Person(1,"Alisia"),
            new Person(123,"Venci"),
            new Person(123546,"Vencislav"),
            new Person(2223,"Andjela"),
            new Person(22,"Pavlova"),
            new Person(92223,"Iva"),
            new Person(92223546,"Ryan"),
            new Person(922,"Villopoto"),
            new Person(92224353,"Eli"),
            new Person(92245,"Tomac"),

            new Person(324353,"Kawasaki"),
            new Person(2223546,"Yamaha"),
            new Person(2224353,"Honda"),
            new Person(345,"KTM"),
            new Person(2245,"Husqvarna"),
            new Person(9345,"Suzuki")
        };
        }
        [Test]
        public void TestIfConstructorIsInitializedWith16People()
        {
            //Arrange
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase(initialPeople);
            //Assert
            Assert.AreEqual(DatabaseCapacity, this.extendedDatabase.Count);
        }
        [Test]
        public void TestIfConstructorInitializedPeopleCorrectly()
        {
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase(initialPeople);

            //Assert
            for (int i = 0; i < this.extendedDatabase.Count; i++)
            {
                Person person = this.extendedDatabase.FindById(this.initialPeople[i].Id);
                long id = person.Id;

                Assert.AreEqual(this.initialPeople[i].Id, id);
            }
        }
        [Test]
        public void TestIfConstructorThrowsExceptionWhenCapacityIsExceeded()
        {
            //Arrange
            Person[] extraPeople = new Person[17];
            this.initialPeople.CopyTo(extraPeople, 0);
            extraPeople[extraPeople.Length - 1] = new Person(999, "ExtraPerson");


            //Assert
            Assert.That(() =>
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase(extraPeople), Throws.ArgumentException
            .With.Message.EqualTo("Provided data length should be in range [0..16]!"));

        }
        //---Add Method Tests ---

        [Test]
        public void TestIfAddMethodThrowsExceptionWhenTryingToAddPersonWhenDatabaseIsFull()
        {
            //Arrange
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase(initialPeople);

            //Assert
            Assert.That(() =>     //Act
            this.extendedDatabase.Add(new Person(1, "Alsiia")),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void TestIfAddMethodThrowsExceptionWhenUserNameAlreadyExists()
        {
            //Arrange
            this.extendedDatabase.Add(new Person(99, "Alisia"));

            //Assert
            Assert.That(() =>       //Act
            this.extendedDatabase.Add(new Person(97, "Alisia")),
            Throws.InvalidOperationException
            .With.Message.EqualTo("There is already user with this username!"));

        }
        [Test]
        public void TestIfAddMethodThrowsExceptionWhenIdExists()
        {
            //Arrange
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase();
            this.extendedDatabase.Add(new Person(99, "Alisia"));

            //Assert
            Assert.That(() =>       //Act
            this.extendedDatabase.Add(new Person(99, "Andjela")),
            Throws.InvalidOperationException
            .With.Message.EqualTo("There is already user with this Id!"));

        }
        //---Remove Method Tests ---
        [Test]
        public void TestIfRemoveMethodDecreasesCountCorrectly()
        {
            //Arrange
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase(new Person(5, "Test"));
            int expectedCount = 0;

            //Act
            this.extendedDatabase.Remove();
            int actualCount = this.extendedDatabase.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount, "The collection is empty!");
        }
        [Test]
        public void TestIfRemoveMethodThrowsExceptionWhenRemovingFromEmptyDatabase()
        {
            //Arrange
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase();

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        //---Find By UserName Tests ---
        [Test]
        public void FindByUsernameOperationShouldReturnMatchingUsername()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.initialPeople);

            //Act
            Person alisia = this.initialPeople[0];
            Person expected = this.extendedDatabase.FindByUsername("Alisia");

            //Assert
            Assert.AreEqual(alisia.UserName, expected.UserName);
        }

        [TestCase("")]
        [TestCase(null)]
        public void FindByUserNameShouldThrowExceptionWithEmptyName(string name)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindByUsername(name), Throws.Exception
                .TypeOf<ArgumentNullException>()
                .With.Property("ParamName")
                .EqualTo("Username parameter is null!"));
        }
        [TestCase("Vanko1")]
        [TestCase("NonExistingName")]
        public void FindUserByUserNameShouldThrowExceptionWhenNotPresent(string name)
        {
            //Arrange
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase(new Person(1, "Alisia"));

            //Assert
            Assert.That(() =>
            this.extendedDatabase.FindByUsername(name),
            Throws.InvalidOperationException
            .With.Message.EqualTo("No user is present by this username!"));
        }

        //---Find By Id Tests ---
        [Test]
        public void FindByIdShouldReturnPersonIfGivenIdIsValid()
        {
            //Arrange
            this.extendedDatabase = new /*ExtendedDatabase.*/ExtendedDatabase(initialPeople);
            Person expectedPerson = this.initialPeople[0];

            //Act
            Person actualPerson = this.extendedDatabase.FindById(expectedPerson.Id);

            //Assert
            Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
        }

        [Test]
        [TestCase(1)]
        [TestCase(long.MaxValue)]
        public void FindByIdShouldThrowExceptionWhenNonExistingIdPassed(long id)
        {
            //Assert 
            Assert.That(() =>
            this.extendedDatabase.FindById(id),
            Throws.InvalidOperationException
            .With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(long.MinValue)]
        public void FindByIdShouldThrowExceptionWhenNegativeIdPassed(long id)
        {
            //Assert 
            Assert.That(() =>
            this.extendedDatabase.FindById(id),
            Throws.Exception
            .TypeOf<ArgumentOutOfRangeException>()
            .With.Property("ParamName")
            .EqualTo("Id should be a positive number!"));
        }
    }
}