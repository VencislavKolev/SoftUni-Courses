using P08.CollectionHierarchy.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy.Models
{
    public class AddCollection<T> : IAddable<T>
    {
        private List<T> collection;
        public AddCollection()
            : base()
        {
            this.collection = new List<T>(100);
        }
        protected List<T> Collection => this.collection;

        public virtual int AddElement(T element)
        {
            this.Collection.Add(element);
            return this.Collection.Count - 1;
        }
    }
}
