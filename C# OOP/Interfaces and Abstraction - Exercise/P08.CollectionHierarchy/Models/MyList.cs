using P08.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IUsable
    {
        public MyList()
            : base()
        {
        }

        public int Used => this.Collection.Count;
        public override T Remove()
        {
            //Remove fist element in collection
            T lastElement = this.Collection[0];
            this.Collection.RemoveAt(0);
            return lastElement;
        }
    }
}
