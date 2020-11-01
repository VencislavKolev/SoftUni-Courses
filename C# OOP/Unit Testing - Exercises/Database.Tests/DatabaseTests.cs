using NUnit.Framework;
using System;

//In order to pass Judje remove Database reference
namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialData = new int[] { 1, 2 };
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(initialData);
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { })]
        public void TestConstructorWorksCorrectly(int[] testData)
        {
            //Arrange
            //   int[] testData = new int[] { 1, 2, 3, 4 };
            this.database = new Database.Database(testData);

            int expectedCount = testData.Length;
            int actualCount = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void TestIfConstructorThrowsExceptionWithBiggerCollection()
        {
            int[] extraData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            //Array size has to be 16
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database.Database(extraData);
            });
        }

        [Test]
        public void TestIfAddMethodIncreasesCount()
        {
            //Arrange
            int expected = 3;
            //Act
            this.database.Add(3);
            //Assert
            int actual = this.database.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestIfAddMethodThrowsExceptionWhenDatabaseIsFull()
        {
            //Arrange
            for (int i = this.initialData.Length + 1; i <= 16; i++)
            {
                this.database.Add(i);
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }
        [Test]
        public void TestIfRemoveDecreasesCountSuccessfully()
        {
            //Arrange
            int expected = 1;
            //Act
            this.database.Remove();
            //Assert
            int actual = this.database.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestIfRemoveThrowsExceptionFromEmptyDatabase()
        {
            this.database.Remove();
            this.database.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestIfFetchElementsCorrectly(int[] expectedData)
        {
            this.database = new Database.Database(expectedData);
            int[] actualData = this.database.Fetch();
            //Assert
            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}