
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private ICollection<Present> presents;
        public Bag(string color, int capacity)
        {
            this.Capacity = capacity;
            this.Color = color;
            this.presents = new List<Present>();
        }
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count => this.presents.Count;

        public void Add(Present present)
        {
            if (this.presents.Count < this.Capacity)
            {
                this.presents.Add(present);
            }
        }
        public bool Remove(string name)
        {
            Present present = this.presents
                .FirstOrDefault(p => p.Name == name);
            return this.presents.Remove(present);
        }
        public Present GetHeaviestPresent()
        {
            Present present = this.presents
                .OrderByDescending(x => x.Weight)
                .FirstOrDefault();
            return present;
        }
        public Present GetPresent(string name)
        {
            Present present = this.presents
                .FirstOrDefault(p => p.Name == name);
            return present;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (Present present in this.presents)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
