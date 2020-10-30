using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> bag;
        public Bag(string color,int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.bag = new List<Present>();
        }
        public int Capacity { get; set; }
        public string Color { get; set; }

        public int Count
        {
            get { return this.bag.Count; }
        }
        public void Add(Present present)
        {
            if (this.bag.Count < this.Capacity)
            {
                this.bag.Add(present);
            }
        }
        public bool Remove(string name)
        {
            Present present = GetPresent(name);
            if (present != null)
            {
                this.bag.Remove(present);
                return true;
            }
            return false;
        }

        public Present GetPresent(string name)
        {
            return this.bag
                            .FirstOrDefault(x => x.Name == name);
        }

        public Present GetHeaviestPresent()
        {
            Present present = this.bag
                .OrderByDescending(x => x.Weight)
                .FirstOrDefault();
            return present;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var present in this.bag)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
