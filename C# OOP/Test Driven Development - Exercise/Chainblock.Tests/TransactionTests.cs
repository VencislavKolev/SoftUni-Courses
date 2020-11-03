
using Chainblock.Common;
using Chainblock.Models;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private const int TestId = 1;
        private const TransactionStatus TestTs = TransactionStatus.Successfull;
        private const string TestFrom = "Ryan";
        private const string TestTo = "Villopoto";
        private const double TestAmount = 2;

        private Transaction transaction;

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //Arrange

            //Act
            this.transaction = new Transaction(TestId, TestTs, TestFrom, TestTo, TestAmount);
            //Assert
            Assert.AreEqual(TestId, transaction.Id);
            Assert.AreEqual(TestTs, transaction.Status);
            Assert.AreEqual(TestFrom, transaction.From);
            Assert.AreEqual(TestTo, transaction.To);
            Assert.AreEqual(TestAmount, transaction.Amount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        public void IdShouldThrowExceptionWhenZeroOrNegative(int invalidId)
        {
            Assert.That(
                () => this.transaction = new Transaction(invalidId, TestTs, TestFrom, TestTo, TestAmount),
                Throws.Exception.InstanceOf<ArgumentException>()
                .With.Message.EqualTo(ExceptionMessages.invalidIdMessage));
        }

        [Test]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        public void FromShouldThrowExceptionWhenSenderIsNullEmptyOrWhiteSpace(string invalidFrom)
        {
            Assert.That(
               () => this.transaction = new Transaction(TestId, TestTs, invalidFrom, TestTo, TestAmount),
               Throws.Exception.InstanceOf<ArgumentException>()
               .With.Message.EqualTo(ExceptionMessages.invalidSenderMessage));
        }

        [Test]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        public void ToShouldThrowExceptionWhenReceiverIsNullEmptyOrWhiteSpace(string invalidTo)
        {
            Assert.That(
               () => this.transaction = new Transaction(TestId, TestTs, TestFrom, invalidTo, TestAmount),
               Throws.Exception.InstanceOf<ArgumentException>()
               .With.Message.EqualTo(ExceptionMessages.invalidReceiverMessage));
        }

        [Test]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        public void AmountShouldThrowExceptionWhenZeroOrNegative(int invalidAmount)
        {
            Assert.That(
                () => this.transaction = new Transaction(TestId, TestTs, TestFrom, TestTo, invalidAmount),
                Throws.Exception.InstanceOf<ArgumentException>()
                .With.Message.EqualTo(ExceptionMessages.invalidAmountMessage));
        }
    }
}
