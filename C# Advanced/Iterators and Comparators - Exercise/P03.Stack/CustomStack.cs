using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace P03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] data;
        private int capacity = 4;
        private int count;

        public CustomStack()
        {
            this.data = new T[capacity];
        }
        public void Push(T element)
        {
            if (this.NeedsResize())
            {
                this.Resize();
            }
            this.data[this.count++] = element;
        }
        public void Pop()
        {
            if (this.count > 0)
            {
                this.data[--this.count] = default;
            }
            else
            {
                Console.WriteLine("No elements");
            }

        }
        public int Count
        {
            get { return this.count; }
            private set { }
        }
        public T this[int index]
        {
            get { return this.data[index]; }
            set { this.data[index] = value; }
        }
        public void Clear()
        {
            this.data = new T[capacity];
            this.count = 0;
        }
        private T[] Resize()
        {
            int newCapacity = this.data.Length * 2;
            T[] resizedArr = new T[newCapacity];
            for (int i = 0; i < this.data.Length; i++)
            {
                resizedArr[i] = this.data[i];
            }
            this.data = resizedArr;
            return this.data;
        }
        private bool NeedsResize()
        {
            return this.count >= this.data.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.data.Reverse()
                .Where(x => x != null))
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
