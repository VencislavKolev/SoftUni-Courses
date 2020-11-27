namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            this._head = null;
            this.Count = 0;
        }
        public Queue(Node<T> head)
        {
            this._head = head;
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
                    if (current.Value.Equals(item))
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
            this.ValidateEmpty();
            Node<T> toRemove = this._head;
            this._head = toRemove.Next;
            this.Count--;

            return toRemove.Value;
        }

        public void Enqueue(T item)
        {

            Node<T> current = this._head;
            Node<T> toInsert = new Node<T>(item);

            if (current == null)
            {
                this._head = toInsert;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = toInsert;
            }
            this.Count++;
        }

        public T Peek()
        {
            this.ValidateEmpty();
            return this._head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotImplementedException();

        private void ValidateEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
        }
    }
}