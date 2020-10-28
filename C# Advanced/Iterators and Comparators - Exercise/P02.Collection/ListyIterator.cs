
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index;
        public ListyIterator(params T[] elements)
        {
            this.data = new List<T>(elements);
        }
        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return this.index + 1 < this.data.Count;
        }
        public void Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.data[this.index]);

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
