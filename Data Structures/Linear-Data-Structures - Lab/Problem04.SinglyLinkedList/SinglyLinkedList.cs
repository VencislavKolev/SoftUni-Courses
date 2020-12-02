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
            Node<T> newHead = new Node<T>(item, this._head);
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
            this.CheckIfEmpty();
            return this._head.Value;
        }

        public T GetLast()
        {
            this.CheckIfEmpty();
            Node<T> current = this._head;

            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public T RemoveFirst()
        {
            Node<T> firstNode = this._head;
            this.CheckIfEmpty();
            this._head = this._head.Next;
            this.Count--;

            return firstNode.Value;
        }

        public T RemoveLast()
        {
            this.CheckIfEmpty();

            Node<T> current = this._head;
			Node<T> last = null;// T element;
            if (current.Next == null)
            {
                last = this.head;
                this._head = null;
            }
            else
            {
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
				last = current.Next;
                current.Next = null;
            }

            this.Count--;
            return last.item;
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


        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EmptyLinkedListMessage);
            }
        }
    }
}