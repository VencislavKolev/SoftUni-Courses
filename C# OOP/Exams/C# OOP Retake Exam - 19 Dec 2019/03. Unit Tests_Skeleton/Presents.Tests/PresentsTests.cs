namespace Presents.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        [SetUp]
        public void SetUpBag()
        {
            this.bag = new Bag();
        }
        [Test]
        public void TestIfPresentCtorWorksCorrectly()
        {
            string expName = "Present";
            double expMagic = 5;

            Present present = new Present(expName, expMagic);

            Assert.AreEqual(expName, present.Name);
            Assert.AreEqual(expMagic, present.Magic);
        }
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //Arrange
            Bag testBag = new Bag();

            //Assert
            Assert.IsNotNull(testBag.GetPresents());


        }
        //----- Create Method Tests -----
        [Test]
        public void CreateShouldThrowExceptionWhenPresentIsNull()
        {
            Present present = null;

            Assert.That(
                () => bag.Create(present),
                Throws.Exception.InstanceOf<ArgumentNullException>());

        }
        [Test]
        public void CreateShouldThrowExceptionIfPresentAlreadyExists()
        {
            string expName = "Present";
            double expMagic = 5;

            Present present = new Present(expName, expMagic);
            this.bag.Create(present);

            Assert.That(() =>
            {
                this.bag.Create(present);
            },
            Throws.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("This present already exists!"));
        }
        //[Test]
        //public void CreateShouldPhysicallyAddThePresents()
        //{
        //    string expName = "Present";
        //    double expMagic = 5;

        //    Present present = new Present(expName, expMagic);
        //    Present present2 = new Present(expName, expMagic + 1);
        //    this.bag.Create(present);
        //    this.bag.Create(present2);

        //    IReadOnlyCollection<Present> exp = new List<Present>()
        //    {
        //        present,present2
        //    };

        //    IReadOnlyCollection<Present> act = this.bag.GetPresents();

        //    CollectionAssert.AreEqual(exp, act);
        //}
        [Test]
        public void CreateShouldAddValidPresent()
        {
            string expName = "Present";
            double expMagic = 5;

            Present present = new Present(expName, expMagic);

            string expOutput = $"Successfully added present {expName}.";
            string actOutput = this.bag.Create(present);

            Assert.AreEqual(expOutput, actOutput);
        }

        //----- Remove Method Tests -----
        [Test]
        public void RemoveShouldReturnTrueWhenValidPresentIsRemoved()
        {
            string expName = "Present";
            double expMagic = 5;
            bool expRes = true;

            Present present = new Present(expName, expMagic);
            this.bag.Create(present);

            bool actRes = this.bag.Remove(present);

            Assert.AreEqual(expRes, actRes);
        }
        [Test]
        public void RemoveShouldReturnFalseWhenRemovingNonExistingPresent()
        {
            bool expRes = false;

            bool actRes = this.bag.Remove(new Present("NonExisting", 404));

            Assert.AreEqual(expRes, actRes);
        }

        //----- GetPresentWithLeastMagic Method Tests -----
        [Test]
        public void GetPresentWithLeastMagicShouldReturnValidPresent()
        {
            Present leastMagic = new Present("Least", 1);
            Present moreMagic = new Present("More", 2);
            this.bag.Create(moreMagic);
            this.bag.Create(leastMagic);

            Present actPresent = this.bag.GetPresentWithLeastMagic();
            Assert.AreEqual(leastMagic.Name, actPresent.Name);
            Assert.AreEqual(leastMagic.Magic, actPresent.Magic);
        }

        //----- GetPresentWithLeastMagic Method Tests -----
        [Test]
        public void GetPresentShouldReturnValidPresent()
        {
            Present first = new Present("First", 1);
            this.bag.Create(first);

            Present actPresent = this.bag.GetPresent(first.Name);
            Assert.AreEqual(first.Name, actPresent.Name);
        }
        [Test]
        public void GetPresentShouldReturnNullPresent()
        {
            Present actPresent = this.bag.GetPresent("SomeName");
            Assert.IsNull(actPresent);
        }
    }
}
