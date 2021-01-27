namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _heapElements;

        public MaxHeap()
        {
            this._heapElements = new List<T>();
        }
        public int Size => this._heapElements.Count;

        public void Add(T element)
        {
            this._heapElements.Add(element);

            this.HeapifyUp();
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

        private void Swap(int index, int parentIndex)
        {
            T temp = this._heapElements[index];
            this._heapElements[index] = this._heapElements[parentIndex];
            this._heapElements[parentIndex] = temp;
        }

        private bool IsValidIndex(int index)
        {
            return index > 0;
        }
        private bool IsGreater(int index, int parentIndex)
        {
            return this._heapElements[index]
                .CompareTo(this._heapElements[parentIndex]) > 0;
        }
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._heapElements[0];
        }

        private void EnsureNotEmpty()
        {
            if (this._heapElements.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty!");
            }
        }
    }
}
