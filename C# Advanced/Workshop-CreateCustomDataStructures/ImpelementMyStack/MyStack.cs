using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImpelementMyStack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly int capacity;
        private T[] data;
        public MyStack()
            : this(4)
        {

        }
        public MyStack(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
        }
        public int Count { get; private set; }
        public void Push(T element)
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
            this.data[this.Count] = element;
            this.Count++;
        }
        public T Pop()
        {
            this.ValidateEmptyStack();
            T elementToRemove = this.data[this.Count - 1];
            this.Count--;
            return elementToRemove;
        }
        public T Peek()
        {
            this.ValidateEmptyStack();
            return this.data[this.Count - 1];
        }

        private void ValidateEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is empty.");
            }
        }

        public void Clear()
        {
            this.data = new T[capacity];
            this.Count = 0;
        }
        public void ForEach(Action<T> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.data[i]);
            }
        }
        private T[] Resize()
        {
            int newCapacity = this.data.Length * 2;
            T[] biggerArray = new T[newCapacity];
            for (int i = 0; i < this.data.Length; i++)
            {
                biggerArray[i] = this.data[i];
            }
            this.data = biggerArray;
            return this.data;
        }

        public IEnumerator<T> GetEnumerator()

            => this.data
                .Take(this.Count)
                .Reverse()
                .ToList()
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
