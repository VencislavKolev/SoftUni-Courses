
using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction validTestTransaction;

        private int id = 5;
        private TransactionStatus ts = TransactionStatus.Successfull;
        private string from = "Me";
        private string to = "You";
        private double amount = 10;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Core.Chainblock();
            this.validTestTransaction = new Transaction(id, ts, from, to, amount);
        }
        [Test]
        public void TestIfContructorWorksCorrectly()
        {
            int expCount = 0;
            IChainblock chainblock = new Core.Chainblock();

            Assert.AreEqual(expCount, chainblock.Count);
        }

        //----- Add Method Tests -----
        [Test]
        public void AddTransactionShouldIncreaseCountIfSuccessful()
        {
            //Arrange
            int expCount = 1;

            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Yamaha";
            string to = "Kawasaki";
            double amount = 250;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            //Act
            this.chainblock.Add(transaction);
            //Assert
            Assert.AreEqual(expCount, this.chainblock.Count);
        }
        [Test]
        public void AddSameTransactionWithDifferentIdShouldBeValid()
        {
            //Arrange
            int expCount = 2;

            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Yamaha";
            string to = "Kawasaki";
            double amount = 250;

            ITransaction transaction = new Transaction(2, ts, from, to, amount);
            ITransaction transactionTwo = new Transaction(3, ts, from, to, amount);

            //Act
            this.chainblock.Add(transaction);
            this.chainblock.Add(transactionTwo);

            //Assert
            Assert.AreEqual(expCount, this.chainblock.Count);
        }
        [Test]
        public void AddingExistingTransactionShouldThrowException()
        {
            //Arrange
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Yamaha";
            string to = "Kawasaki";
            double amount = 250;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);
            this.chainblock.Add(transaction);

            //Assert
            Assert.That(
                () => this.chainblock.Add(transaction),
                Throws.Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo(ExceptionMessages.existingTransactionMessage));
        }

        //----- Contains Tests -----
        [Test]
        public void ContainsIdShouldReturnTrueIfIdOfTransactionAlreadyExists()
        {
            //Arrange
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Yamaha";
            string to = "Kawasaki";
            double amount = 250;
            ITransaction transaction = new Transaction(id, ts, from, to, amount);
            //Act
            this.chainblock.Add(transaction);
            //Assert
            bool actResult = this.chainblock.Contains(id);
            Assert.IsTrue(actResult);
        }
        [Test]
        public void ContainsIdShouldReturnFalseIfIdOfTransactionDoesNotExists()
        {
            //Arrange
            int nonExistingId = 99;
            //Act
            bool actResult = this.chainblock.Contains(nonExistingId);
            //Assert
            Assert.IsFalse(actResult);
        }
        [Test]
        public void ContainsShouldReturnTrueIfTranscationAlreadyExists()
        {
            //Arrange
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Yamaha";
            string to = "Kawasaki";
            double amount = 250;
            ITransaction transaction = new Transaction(id, ts, from, to, amount);
            //Act
            this.chainblock.Add(transaction);
            //Assert
            bool actResult = this.chainblock.Contains(id);
            Assert.IsTrue(actResult);
        }
        [Test]
        public void ContainsShouldReturnFalseIfTranscationDoesNotExists()
        {
            //Arrange
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Yamaha";
            string to = "Kawasaki";
            double amount = 250;
            ITransaction transaction = new Transaction(id, ts, from, to, amount);
            //Act
            bool actResult = this.chainblock.Contains(transaction);
            //Assert
            Assert.IsFalse(actResult);
        }

        //----- ChangeTransactionStatus Tests -----
        [Test]
        public void ChangeStatusShouldUpdateStatusOfExistingTranscation()
        {
            //Arrange
            this.chainblock.Add(this.validTestTransaction);
            TransactionStatus newStatus = TransactionStatus.Failed;
            //Act
            this.chainblock.ChangeTransactionStatus(validTestTransaction.Id, newStatus);
            //Assert
            Assert.AreEqual(newStatus, this.validTestTransaction.Status);
        }
        [Test]
        public void ChangeStatusShouldThrowExceptionWhenTransactionDoesNotExist()
        {
            //Assert
            Assert.That(
                 //Act
                 () => this.chainblock.ChangeTransactionStatus(validTestTransaction.Id, TransactionStatus.Failed),
                Throws.Exception.InstanceOf<ArgumentException>()
                .With.Message.EqualTo(ExceptionMessages.nonExistingTransactionMessage));
        }
        //----- RemoveTransactionById Tests -----
        [Test]
        public void RemoveByIdShouldRemoveAndDecreaseCountIfExistingTransaction()
        {
            //Arrange
            int expCount = 0;
            this.chainblock.Add(this.validTestTransaction);
            //Act
            this.chainblock.RemoveTransactionById(validTestTransaction.Id);
            //Assert
            int actCount = this.chainblock.Count;
            Assert.AreEqual(expCount, actCount);
        }
        [Test]
        public void RemoveByIdShouldThrowExceptionWhenTransactionDoesNotExist()
        {
            //Arrange
            int nonExistingId = 66;
            //Assert
            Assert.That(
                 //Act
                 () => this.chainblock.RemoveTransactionById(nonExistingId),
                Throws.Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo(ExceptionMessages.nonExistingTransactionMessage));
        }

        //----- GetById Tests -----

        [Test]
        public void ShouldReturnTheCorrectTransaction()
        {
            //Arrange
            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Yamaha";
            string to = "Kawasaki";
            double amount = 250;
            ITransaction transaction = new Transaction(id, ts, from, to, amount);
            this.chainblock.Add(transaction);
            //Act
            ITransaction actTransaction = this.chainblock.GetById(id);
            //Assert
            Assert.AreEqual(id, actTransaction.Id);
            Assert.AreEqual(ts, actTransaction.Status);
            Assert.AreEqual(from, actTransaction.From);
            Assert.AreEqual(to, actTransaction.To);
            Assert.AreEqual(amount, actTransaction.Amount);
        }
        [Test]
        public void GetByIdShouldThrowExceptionWhenTransactionDoesNotExist()
        {
            //Arrange
            int nonExistingId = 66;
            //Assert
            Assert.That(
                 //Act
                 () => this.chainblock.GetById(nonExistingId),
                Throws.Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo(ExceptionMessages.nonExistingTransactionMessage));
        }

        //----- GetByTransactionStatus Tests -----
        [Test]
        public void GetByTransactionStatusShouldReturnTheCorrectTransaction()
        {
            //Arrange
            var expTransactions = new List<ITransaction>();

            int id = 2;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Yamaha";
            string to = "Kawasaki";
            double amount = 250;
            ITransaction transaction = new Transaction(id, ts, from, to, amount);
            ITransaction transactionTwo = new Transaction(id + 1, ts, from, to, amount + 1);

            expTransactions.Add(transactionTwo);
            expTransactions.Add(transaction);

            this.chainblock.Add(transaction);
            this.chainblock.Add(transactionTwo);
            //Act
            var actTransactions = this.chainblock.GetByTransactionStatus(ts)
                .OrderByDescending(tr => tr.Amount);
            //Assert
            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }
        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenTransactionDoesNotExist()
        {
            //Arrange
            TransactionStatus nonExistingStatus = TransactionStatus.Unauthorized;
            //Assert
            Assert.That(
                 //Act
                 () => this.chainblock.GetByTransactionStatus(nonExistingStatus),
                Throws.Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo(ExceptionMessages.emptyTranscationCollection));
        }

        //----- GetAllSendersWithTransactionStatus Tests -----

        [Test]
        public void AddSendersByStatusShouldReturnCorrectOrderedCollection()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)i;
                string from = "Yamaha" + i;
                string to = "Kawasaki" + i;
                double amount = 10;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currTransaction);
                }
                this.chainblock.Add(currTransaction);
            }
            ITransaction succTr = new Transaction(5, TransactionStatus.Successfull, "Yamaha4", "Kawasaki4", 15);
            expTransactions.Add(succTr);
            this.chainblock.Add(succTr);

            IEnumerable<string> actTransactionSenders = this.chainblock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            IEnumerable<string> expTransactionsSenders = expTransactions
                .OrderByDescending(x => x.Amount)
                .Select(x => x.From);

            CollectionAssert.AreEqual(expTransactionsSenders, actTransactionSenders);
        }
        [Test]
        public void AllSendersByStatusShouldThrowExceptionIfNonTransactions()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Aborted;
                string from = "Yamaha" + i;
                string to = "Kawasaki" + i;
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currTransaction);
            }
            //Assert
            TransactionStatus statusToLookFor = TransactionStatus.Successfull;
            Assert.That(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(statusToLookFor);
            },
            Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo(ExceptionMessages.emptyTranscationCollection));
        }
        //----- GetAllReceiversWithTransactionStatus Tests -----

        [Test]
        public void GetReceiversByStatusShouldReturnCorrectOrderedCollection()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)i;
                string from = "Yamaha" + i;
                string to = "Kawasaki" + i;
                double amount = 10;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currTransaction);
                }
                this.chainblock.Add(currTransaction);
            }
            ITransaction succTr = new Transaction(5, TransactionStatus.Successfull, "Yamaha4", "Kawasaki4", 15);
            expTransactions.Add(succTr);
            this.chainblock.Add(succTr);

            IEnumerable<string> actTransactionReceivers = this.chainblock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            IEnumerable<string> expTransactionsReceivers = expTransactions
                .OrderByDescending(x => x.Amount)
                .Select(x => x.To);

            CollectionAssert.AreEqual(expTransactionsReceivers, actTransactionReceivers);
        }
        [Test]
        public void GetReceiversByStatusShouldThrowExceptionIfNonTransactions()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Aborted;
                string from = "Yamaha" + i;
                string to = "Kawasaki" + i;
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currTransaction);
            }
            //Assert
            TransactionStatus statusToLookFor = TransactionStatus.Successfull;
            Assert.That(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(statusToLookFor);
            },
            Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo(ExceptionMessages.emptyTranscationCollection));
        }

        //----- GetAllOrderedByAmountDescendingThenById Tests -----
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnCorrectOrderedCollectionWithNoDuplicates()
        {
            ICollection<ITransaction> expTransactons = new List<ITransaction>();
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Yamaha" + i;
                string to = "Kawasaki" + i;
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currTransaction);
                expTransactons.Add(currTransaction);
            }
            IEnumerable<ITransaction> actTransactions = this.chainblock
                .GetAllOrderedByAmountDescendingThenById();

            expTransactons = expTransactons
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id)
                .ToList();
            CollectionAssert.AreEqual(expTransactons, actTransactions);
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnCorrectOrderedCollectionWithDuplicateAmounts()
        {
            ICollection<ITransaction> expTransactons = new List<ITransaction>();
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Yamaha" + i;
                string to = "Kawasaki" + i;
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currTransaction);
                expTransactons.Add(currTransaction);
            }
            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Yamaha10", "Kawasaki10", 10);
            this.chainblock.Add(transaction);
            expTransactons.Add(transaction);

            IEnumerable<ITransaction> actTransactions = this.chainblock
                .GetAllOrderedByAmountDescendingThenById();

            expTransactons = expTransactons
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactons, actTransactions);
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnEmptyCollection()
        {
            IEnumerable<ITransaction> actTransactions = this.chainblock
                .GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.IsEmpty(actTransactions);
        }

        //----- GetBySenderOrderedByAmountDescending Tests -----
        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnValidCollection()
        {
            ICollection<ITransaction> expTransactons = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Yamaha";
                string to = "Kawasaki" + i;
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currTransaction);
                expTransactons.Add(currTransaction);
            }

            IEnumerable<ITransaction> actTransactions = this.chainblock
                .GetBySenderOrderedByAmountDescending("Yamaha");

            expTransactons = expTransactons
                .OrderByDescending(tr => tr.Amount)
                .ToList();

            CollectionAssert.AreEqual(expTransactons, actTransactions);
        }
        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionIfNoSuchTransactions()
        {
            Assert.That(
                () => this.chainblock
                .GetBySenderOrderedByAmountDescending("None"),
                Throws.Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo(ExceptionMessages.emptyTranscationCollection));

        }

        //----- GetByReceiverOrderedByAmountThenById Tests -----
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnValidCollection()
        {
            ICollection<ITransaction> expTransactons = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Yamaha" + i;
                string to = "Kawasaki";
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currTransaction);
                expTransactons.Add(currTransaction);
            }

            IEnumerable<ITransaction> actTransactions = this.chainblock
                .GetByReceiverOrderedByAmountThenById("Kawasaki");

            expTransactons = expTransactons
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactons, actTransactions);
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionIfNoSuchTransactions()
        {
            Assert.That(
                () => this.chainblock
                .GetByReceiverOrderedByAmountThenById("None"),
                Throws.Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo(ExceptionMessages.emptyTranscationCollection));
        }
        //----- GetByTransactionStatusAndMaximumAmount Tests -----
        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnValidCollection()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Yamaha" + i;
                string to = "Kawasaki" + i;
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currTransaction);
                }
                this.chainblock.Add(currTransaction);
            }
            double maxAmount = 16;
            IEnumerable<ITransaction> actTransactions = this.chainblock
                 .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, maxAmount);

            expTransactions = expTransactions
                .Where(x => x.Amount <= maxAmount)
                .OrderByDescending(x => x.Amount)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollection()
        {
            double maxAmount = 999;
            IEnumerable<ITransaction> actTransactions = this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, maxAmount);

            CollectionAssert.IsEmpty(actTransactions);
        }

        //----- GetBySenderAndMinimumAmountDescending Tests -----
        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnValidCollection()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Yamaha";
                string to = "Kawasaki" + i;
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                expTransactions.Add(currTransaction);
                this.chainblock.Add(currTransaction);
            }
            string sender = "Yamaha";
            double minAmount = 11;
            IEnumerable<ITransaction> actTransactions = this.chainblock
                 .GetBySenderAndMinimumAmountDescending(sender, minAmount);

            expTransactions = expTransactions
                .Where(x => x.Amount > minAmount)
                .OrderByDescending(x => x.Amount)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }
        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowExceptionIfNoSuchTransactions()
        {
            Assert.That(
                () => this.chainblock
                .GetBySenderAndMinimumAmountDescending("None", 1),
                Throws.Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo(ExceptionMessages.emptyTranscationCollection));
        }

        //----- GetByReceiverAndAmountRange Tests -----
        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnValidCollection()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Yamaha" + i;
                string to = "Kawasaki";
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                expTransactions.Add(currTransaction);
                this.chainblock.Add(currTransaction);
            }
            string receiver = "Kawasaki";
            double minAmountInc = 10;
            double maxAmountExcl = 13;
            IEnumerable<ITransaction> actTransactions = this.chainblock
                 .GetByReceiverAndAmountRange(receiver, minAmountInc, maxAmountExcl);

            expTransactions = expTransactions
                .Where(x => x.Amount >= minAmountInc && x.Amount < maxAmountExcl)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }
        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionIfNoSuchTransactions()
        {
            Assert.That(
                () => this.chainblock
                .GetByReceiverAndAmountRange("None", 1, 10),
                Throws.Exception.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo(ExceptionMessages.emptyTranscationCollection));
        }
        //----- GetByReceiverAndAmountRange Tests -----
        [Test]
        public void GetAllInAmountRangeShouldReturnValidCollection()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);
                string from = "Yamaha" + i;
                string to = "Kawasaki" + i;
                double amount = 10 + i;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                expTransactions.Add(currTransaction);
                this.chainblock.Add(currTransaction);
            }
            double minAmountInc = 10;
            double maxAmountInc = 15;
            IEnumerable<ITransaction> actTransactions = this.chainblock
                 .GetAllInAmountRange(minAmountInc, maxAmountInc);

            expTransactions = expTransactions
                .Where(x => x.Amount >= minAmountInc && x.Amount <= maxAmountInc)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }
        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollection()
        {
            IEnumerable<ITransaction> actTransactions = this.chainblock
                .GetAllInAmountRange(10, 20);

            CollectionAssert.IsEmpty(actTransactions);
        }
        //•	GetAllInAmountRange(lo, hi) – returns all transactions within a range by insertion order (the range is inclusive). Returns an empty collection if no such transactions were found.
        //----- Add Contains Tests -----
    }
}
