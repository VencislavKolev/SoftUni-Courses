using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImplementMyList
{
    public class MyList<T> : IEnumerable<T>
    {
        private const int capacity = 4;
        private T[] data;

        public MyList()
            : this(capacity)
        {

        }

        public MyList(int capacity)
        {
            this.data = new T[capacity];
        }
        public int Count { get; private set; }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            T temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }
        public bool TrueForAll(Func<T, bool> condition)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (!condition(this.data[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public int RemoveAll(Func<T, bool> filter)
        {
            int removed = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (filter(this.data[i]))
                {
                    this.RemoveAt(i);
                    removed++;
                }
            }
            return removed;
        }
        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);
            T elementToRemove = this.data[index];
            for (int i = index + 1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }
            this.Count--;
            return elementToRemove;
        }
        public void Insert(int index, T element)
        {
            // 1 2 3 4  (2,100)
            // 1 2 100 3 4

            this.ValidateIndex(index);
            this.CheckIfResizeIsNeeded();

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.data[i + 1] = this.data[i];
            }
            this.data[index] = element;
            this.Count++;

        }
        public void Add(T element)
        {
            this.CheckIfResizeIsNeeded();
            this.data[this.Count] = element;
            this.Count++;
        }

        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.data[index] = value;
            }
        }
        private void Resize()
        {
            int newCapacity = this.data.Length * 2;
            T[] resizedData = new T[newCapacity];
            for (int i = 0; i < this.Count; i++)
            {
                resizedData[i] = this.data[i];
            }
            this.data = resizedData;
        }
        private void ValidateIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return;
            }
            string message = this.Count == 0
                ? "The list is empty"
                : $"The list has {this.Count - 1} elements and it is zero-based";
            throw new Exception($"Index out of range!! {message}");
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        => this.data
            .Take(this.Count)
            .ToList()
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
