using P08.CollectionHierarchy.Contracts;

namespace P08.CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : AddCollection<T>, IRemovable<T>
    {
        public AddRemoveCollection()
            : base()
        {
        }

        public override int AddElement(T element)
        {
            this.Collection.Insert(0, element);
            return 0;
        }

        public virtual T Remove()
        {
            //Remove last element
            int lastIndex = this.Collection.Count - 1;
            T lastElement = this.Collection[lastIndex];
            this.Collection.RemoveAt(lastIndex);
            return lastElement;
        }
    }
}
