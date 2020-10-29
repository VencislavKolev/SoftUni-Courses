using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Custom_Doubly_Linked_List
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                T[] arr = this.ToArray();
                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Index outside of the bounds of the array.", nameof(index));
                }
                return arr[index];
            }
        }
        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                //this.head=new ListNode(element);
                //this.tail = new ListNode(element);
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                ListNode<T> oldHead = this.head;

                this.head = newHead;
                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;
            }
            this.Count++;
        }
        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode<T>(element);
                this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                ListNode<T> oldTail = this.tail;

                this.tail = newTail;
                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;
            }
            this.Count++;
        }
        public T RemoveFirst()
        {
            T removedElement = this.head.Value;
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
            else if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newHead = this.head.NextNode;
                newHead.PreviousNode = null;
                this.head = newHead;
            }
            this.Count--;
            return removedElement;
        }
        public T RemoveLast()
        {
            T elementToRemove = this.tail.Value;
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            else if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newTail = this.tail.PreviousNode;
                newTail.NextNode = null;
                this.tail = newTail;

            }
            this.Count--;
            return elementToRemove;
        }
        public void ForEach(Action<T> action)
        {
            ListNode<T> currNode = this.head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            ListNode<T> currNode = this.head;
            int counter = 0;
            while (currNode != null)
            {
                array[counter++] = currNode.Value;
                currNode = currNode.NextNode;
            }
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
            }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
