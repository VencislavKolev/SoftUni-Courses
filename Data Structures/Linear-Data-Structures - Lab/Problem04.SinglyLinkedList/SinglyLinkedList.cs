namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private const string EmptyLinkedListMessage = "Linked list is empty";
        private Node<T> _head;

        public SinglyLinkedList()
        {
        }
        public SinglyLinkedList(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newHead = new Node<T>(item);
            newHead.Next = this._head;
            this._head = newHead;

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newLast = new Node<T>(item);
            if (this._head == null)
            {
                this._head = newLast;
            }
            else
            {
                Node<T> current = this._head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newLast;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException(EmptyLinkedListMessage);
            }
            return this._head.Value;
        }

        public T GetLast()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException(EmptyLinkedListMessage);
            }
            Node<T> current = this._head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public T RemoveFirst()
        {
            Node<T> toRemove = this._head;
            if (toRemove == null)
            {
                throw new InvalidOperationException(EmptyLinkedListMessage);
            }
            this._head = this._head.Next;
            this.Count--;

            return toRemove.Value;
        }

        public T RemoveLast()
        {
            Node<T> current = this._head;
            if (current == null)
            {
                throw new InvalidOperationException(EmptyLinkedListMessage);
            }
            while (current.Next != null)
            {
                current = current.Next;
            }
            T element = current.Value;
            current = default;
            this.Count--;

            return element;
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
            => this.GetEnumerator();
    }
}