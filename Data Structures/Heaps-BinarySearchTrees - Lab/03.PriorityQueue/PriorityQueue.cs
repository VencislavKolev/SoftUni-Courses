namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public PriorityQueue()
        {
            this._elements = new List<T>();
        }
        public int Size => this._elements.Count;

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._elements[0];
        }

        public void Add(T element)
        {
            this._elements.Add(element);

            this.HeapifyUp();
        }

        public T Dequeue()
        {
            T firstElement = this.Peek();
            this.Swap(0, this.Size - 1);
            this._elements.RemoveAt(this.Size - 1);

            this.HeapifyDown();

            return firstElement;
        }

        private void HeapifyUp()
        {
            int index = this.Size - 1;
            int parentIndex = this.GetParentIndex(index);

            while (this.IsValidIndex(index) && this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            int leftChildIndex = this.GetLeftChildIndex(index);
            while (this.IsValidIndex(leftChildIndex) && this.IsLess(index, leftChildIndex))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(index);

                if (this.IsValidIndex(rightChildIndex) && this.IsLess(toSwapWith, rightChildIndex))
                {
                    toSwapWith = rightChildIndex;
                }

                this.Swap(index, toSwapWith);

                index = toSwapWith;
                leftChildIndex = this.GetLeftChildIndex(index);
            }
        }

        private void Swap(int index, int newIndex)
        {
            T temp = this._elements[index];
            this._elements[index] = this._elements[newIndex];
            this._elements[newIndex] = temp;
        }

        private bool IsValidIndex(int index)
        {
            return index < this.Size;
        }
        private bool IsGreater(int index, int parentIndex)
        {
            return this._elements[index]
                .CompareTo(this._elements[parentIndex]) > 0;
        }

        private bool IsLess(int index, int parentIndex)
        {
            return this._elements[index]
                .CompareTo(this._elements[parentIndex]) < 0;
        }
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void EnsureNotEmpty()
        {
            if (this._elements.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty!");
            }
        }
    }
}
