using Newtonsoft.Json.Bson;
using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;

        private string owner = "venci";
        private string id = "1";
        private Item item;
        [SetUp]
        public void Setup()
        {
            item = new Item(owner, id);
            this.bankVault = new BankVault();
        }

        [Test]
        public void ItemCtorShouldWorkCorrectly()
        {
            string owner = "venci";
            string id = "1";
            Item item = new Item(owner, id);

            Assert.AreEqual(owner, item.Owner);
            Assert.AreEqual(id, item.ItemId);
        }

        [Test]
        public void BankVoltCtorShouldWorkCorrectly()
        {
            this.bankVault = new BankVault();

            Assert.IsNotNull(bankVault);
        }
        [Test]
        public void AddItemOnInvalidCellShouldThrowException()
        {
            Assert.That(() =>
            {
                this.bankVault.AddItem("invalid", this.item);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("Cell doesn't exists!"));
        }
        [Test]
        public void AddItemOnTakenCellShouldThrowException()
        {
            this.bankVault.AddItem("A1", this.item);
            Assert.That(() =>
            {
                this.bankVault.AddItem("A1", this.item);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("Cell is already taken!"));
        }
        [Test]
        public void AddItemOnExistingCellShouldThrowException()
        {
            this.bankVault.AddItem("A1", this.item);
            Assert.That(() =>
            {
                this.bankVault.AddItem("A2", this.item);
            }, Throws.Exception.InstanceOf<InvalidOperationException>()
            .With.Message.EqualTo("Item is already in cell!"));
        }
        [Test]
        public void AddItemShouldWork()
        {
            string eMessage = $"Item:{this.item.ItemId} saved successfully!";
            string aMessage = this.bankVault.AddItem("A1", this.item);

            Assert.AreEqual(eMessage, aMessage);
        }

        [Test]
        public void RemoveItemShouldThrowExceptionWhenCellDoesntExist()
        {
            Assert.That(() =>
            {
                this.bankVault.RemoveItem("none", this.item);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo("Cell doesn't exists!"));
        }
        [Test]
        public void RemoveItemShouldThrowExceptionInvalidItem()
        {
            this.bankVault.AddItem("A1", this.item);
            Item invalidItem = new Item("none", "none");
            Assert.That(() =>
            {
                this.bankVault.RemoveItem("A1", invalidItem);
            }, Throws.Exception.InstanceOf<ArgumentException>()
            .With.Message.EqualTo($"Item in that cell doesn't exists!"));
        }

        [Test]
        public void RemoveItemShouldWork()
        {
            this.bankVault.AddItem("A1", this.item);

            string eMessgae= $"Remove item:{this.item.ItemId} successfully!";
            string aMessage = this.bankVault.RemoveItem("A1", this.item);

            Assert.AreEqual(eMessgae, aMessage);
            Assert.IsNull(this.bankVault.VaultCells["A1"]);

        }
    }
}