using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
    {
        public Box()
        {
            this.Values = new List<T>();
        }
        public List<T> Values { get; set; }
        public void Swap(int firstIndex, int secondIndex)
        {
            bool isInRange = firstIndex >= 0 && firstIndex < this.Values.Count &&
                secondIndex >= 0 && secondIndex < this.Values.Count;
            if (isInRange)
            {
                T temp = this.Values[firstIndex];
                this.Values[firstIndex] = this.Values[secondIndex];
                this.Values[secondIndex] = temp;
            }
            else
            {
                throw new InvalidOperationException("Values are not in range!");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}