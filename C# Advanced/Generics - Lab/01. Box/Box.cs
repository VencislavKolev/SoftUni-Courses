using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> data;
        public Box()
        {
            this.data = new Stack<T>();
        }
        public void Add(T element)
        {
            this.data.Push(element);
        }
        public T Remove()
        {
            T removedElement = this.data.Pop();
            return removedElement;
        }
        public int Count
        {
            get { return this.data.Count; }
        }
    }
}
