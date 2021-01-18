
using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private ICollection<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public int Capacity { get; set; } = 100;

        public int Load => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
            => (IReadOnlyCollection<Item>)this.items;


        public void AddItem(Item item)
        {
            int currLoad = this.Load + item.Weight;
            if (currLoad > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item itemToFind = this.Items.FirstOrDefault(x => x.GetType().Name == name);
            if (itemToFind == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(itemToFind);

            return itemToFind;
        }
    }
}
