namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Reflection.Metadata.Ecma335;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity <= 0)
            {
                throw new IndexOutOfRangeException($"{capacity} cannot be zero or negative!");
            }
            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.CheckIfResizeIsNeeded())
            {
                this.Resize();
            }
            this._items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.CheckIfResizeIsNeeded();

            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }
            this._items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int indexOfElement = this.IndexOf(item);

            if (indexOfElement == -1)
            {
                return false;
            }

            this.RemoveAt(indexOfElement);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }
            this._items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private bool CheckIfResizeIsNeeded()
        {
            if (this.Count == this._items.Length)
            {
                return true;
            }
            return false;
        }
        private void Resize()
        {
            int newCapacity = this._items.Length * 2;
            T[] newArr = new T[newCapacity];
            for (int i = 0; i < this._items.Length; i++)
            {
                newArr[i] = this._items[i];
            }
            this._items = newArr;
        }
        private void ValidateIndex(int index)
        {
            if (0 > index || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"Index is out of range!");
            }
        }
    }
}