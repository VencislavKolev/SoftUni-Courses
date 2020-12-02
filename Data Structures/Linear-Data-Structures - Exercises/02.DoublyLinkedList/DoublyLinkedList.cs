namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private const string EmptyDoublyLinkedListMsg = "DoublyLinked is empty.";

        private Node<T> _head;
        private Node<T> _tail;
        public DoublyLinkedList()
        {
            
        }
        public DoublyLinkedList(Node<T> node)
        {
            this._head = this._tail = node;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> toInsert = new Node<T>
            {
                Item = item
            };
            if (this.Count == 0)
            {
                this._head = this._tail = toInsert;
            }
            else
            {
                this._head.Previous = toInsert;
                toInsert.Next = this._head;
                this._head = toInsert;

            }
            // +1 2 3
            this.Count++;
        }
        public void AddLast(T item)
        {
            Node<T> toInsert = new Node<T>
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
                toInsert.Previous = this._tail;
                this._tail = toInsert;
            }
            // 2 3 +4
            this.Count++;
        }

        public T GetFirst()
        {
            this.CheckIfEmpty();

            return this._head.Item;
        }


        public T GetLast()
        {
            this.CheckIfEmpty();

            return this._tail.Item;
        }

        public T RemoveFirst()
        {
            this.CheckIfEmpty();

            Node<T> toRemove = this._head;
            this._head = this._head.Next;
            this.Count--;

            return toRemove.Item;
        }

        public T RemoveLast()
        {
            this.CheckIfEmpty();

            Node<T> toRemove = this._tail;
            this._tail = this._tail.Previous;
            this.Count--;

            return toRemove.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;
            while (current != null)
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
                throw new InvalidOperationException(EmptyDoublyLinkedListMsg);
            }
        }
    }
}