namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private const string EmptyQueueMsg = "Queue is empty.";

        private Node<T> _head;
        private Node<T> _tail;

        public FastQueue()
        {
            this._head = null;
            this._tail = null;
            this.Count = 0;
        }
        public FastQueue(Node<T> head)
        {
            this._head = this._tail = head;
            this.Count = 1;
        }
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> current = this._head;
            if (current.Next == null)
            {
                return false;
            }
            else
            {
                while (current != null)
                {
                    if (current.Item.Equals(item))
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
        }

        public T Dequeue()
        {
            this.CheckIfEmpty();
            Node<T> toRemove = this._head;

            if (this.Count == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                this._head = this._head.Next;
            }
            this.Count--;
            return toRemove.Item;
        }


        public void Enqueue(T item)
        {
            Node<T> toInsert = new Node<T>()
            {
                Item = item
            };

            if (this.Count == 0)
            {
                this._head = this._tail = toInsert;
            }
            else
            {
                this._tail.Next = toInsert;
                this._tail = toInsert;
            }
            this.Count++;
        }

        public T Peek()
        {
            this.CheckIfEmpty();
            Node<T> currentHead = this._head;
            return currentHead.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;
            while (current.Next != this._tail)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EmptyQueueMsg);
            }
        }
    }
}