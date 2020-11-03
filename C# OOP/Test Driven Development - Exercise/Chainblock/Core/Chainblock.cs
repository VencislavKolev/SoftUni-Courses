
using Chainblock.Common;
using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chainblock.Core
{
    public class Chainblock : IChainblock
    {
        private ICollection<ITransaction> transactions;
        private HashSet<int> transactionId;
        private Dictionary<int, ITransaction> transactionsById;
        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
            this.transactionId = new HashSet<int>();
            this.transactionsById = new Dictionary<int, ITransaction>();
        }
        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactionId.Contains(tx.Id))
            {
                throw new InvalidOperationException(ExceptionMessages.existingTransactionMessage);
            }
            this.transactions.Add(tx);
            this.transactionId.Add(tx.Id);
            this.transactionsById.Add(tx.Id, tx);
        }

        public bool Contains(ITransaction tx)
        {
            if (!this.transactionId.Contains(tx.Id))
            {
                return false;
            }
            return true;
        }
        public bool Contains(int id)
        {
            if (!this.transactionId.Contains(id))
            {
                return false;
            }
            return true;
        }
        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.transactionId.Contains(id))
            {
                throw new ArgumentException(ExceptionMessages.nonExistingTransactionMessage);
            }
            ITransaction transaction = transactionsById[id];
            transaction.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            if (!transactionId.Contains(id))
            {
                throw new InvalidOperationException(ExceptionMessages.nonExistingTransactionMessage);
            }
            ITransaction transactionToRemove = transactionsById[id];

            transactions.Remove(transactionToRemove);
            transactionId.Remove(id);
            transactionsById.Remove(id);

        }
        public ITransaction GetById(int id)
        {
            if (!transactionId.Contains(id))
            {
                throw new InvalidOperationException(ExceptionMessages.nonExistingTransactionMessage);
            }
            ITransaction transaction = transactionsById[id];
            return transaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!transactions.Any(x => x.Status == status))
            {
                throw new InvalidOperationException(ExceptionMessages.emptyTranscationCollection);
            }
            var sameStatusTransactions = transactions
                                        .Where(x => x.Status == status)
                                        .OrderByDescending(x => x.Amount);
            return sameStatusTransactions;
        }
        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> senders = this.GetByTransactionStatus(status)
                .Select(tr => tr.From);
            return senders;
        }
        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> receivers = this.GetByTransactionStatus(status)
                 .Select(tr => tr.To);
            return receivers;
        }
        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> transactions =
                this.transactions
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id);

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> transactions =
              this.transactions
              .Where(tr => tr.From == sender)
              .OrderByDescending(tr => tr.Amount);

            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.emptyTranscationCollection);
            }
            return transactions;
        }
        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> transactions =
             this.transactions
             .Where(tr => tr.To == receiver)
             .OrderByDescending(tr => tr.Amount)
             .ThenBy(tr => tr.Id);

            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.emptyTranscationCollection);
            }
            return transactions;
        }
        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            IEnumerable<ITransaction> transactionsReturned = transactions
                .Where(x => x.Status == status && x.Amount <= amount)
                .OrderByDescending(x => x.Amount);
            return transactionsReturned;
        }
        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> transactions =
             this.transactions
             .Where(tr => tr.From == sender && tr.Amount > amount)
             .OrderByDescending(tr => tr.Amount)
             .ThenBy(tr => tr.Id);

            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.emptyTranscationCollection);
            }
            return transactions;
        }
        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> transactions =
            this.transactions
            .Where(tr => tr.To == receiver && tr.Amount >= lo && tr.Amount < hi)
            .OrderByDescending(tr => tr.Amount)
            .ThenBy(tr => tr.Id);

            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.emptyTranscationCollection);
            }
            return transactions;
        }
        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            IEnumerable<ITransaction> transactionsInRange = this.transactions
                .Where(tr => tr.Amount >= lo && tr.Amount <= hi);
            return transactionsInRange;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return this.transactions.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
