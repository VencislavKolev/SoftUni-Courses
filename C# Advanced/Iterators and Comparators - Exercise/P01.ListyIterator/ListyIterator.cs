
using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> data;
        private int index;
        public ListyIterator(params T[] elements)
        {
            this.data = elements.ToList();
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
            int nextIndex = this.index;
            return ++nextIndex < this.data.Count;
        }
        public void Print()
        {
            if (this.data.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                //  throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                System.Console.WriteLine(this.data[this.index]);
            }
        }
    }
}
