using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy.Contracts
{
    public interface IAddable<T>
    {
        public int AddElement(T element);
    }
}
