namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public bool IsRootDeleted { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            if (this.IsRootDeleted)
            {
                return result;
            }

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subTree = queue.Dequeue();
                result.Add(subTree.Value);

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            if (this.IsRootDeleted)
            {
                return result;
            }

            this.Dfs(this, result);
            return result;

            //  return this.OrderDfsWithStack();
        }
        private ICollection<T> OrderDfsWithStack()
        {
            var result = new Stack<T>();
            var toTraverse = new Stack<Tree<T>>();

            toTraverse.Push(this);

            while (toTraverse.Count > 0)
            {
                var subTree = toTraverse.Pop();
                foreach (var child in subTree.Children)
                {
                    toTraverse.Push(child);
                }
                result.Push(subTree.Value);
            }
            return new List<T>(result);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parentSubTree = this.FindByBfs(parentKey);
            //Tree<T> parentSubTree = this.FindByDfs(parentKey, this);
            this.CheckIfEmptyTree(parentSubTree);

            parentSubTree._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> currentNode = this.FindByBfs(nodeKey);
            this.CheckIfEmptyTree(currentNode);

            foreach (var child in currentNode.Children)
            {
                child.Parent = null;
            }

            currentNode._children.Clear();

            var parentNode = currentNode.Parent;
            if (parentNode == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                parentNode._children.Remove(currentNode);
                currentNode.Parent = null;
            }
            currentNode.Value = default;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindByBfs(firstKey);
            var secondNode = this.FindByBfs(secondKey);
            this.CheckIfEmptyTree(firstNode);
            this.CheckIfEmptyTree(secondNode);

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                this.SwapRoot(secondNode);
                return;
            }
            else if (secondParent == null)
            {
                this.SwapRoot(firstNode);
                return;
            }

            int indexOfFirst = firstParent._children.IndexOf(firstNode);
            int indexOfSecond = secondParent._children.IndexOf(secondNode);

            firstParent._children[indexOfFirst] = secondNode;
            secondParent._children[indexOfSecond] = firstNode;
        }
        private void SwapRoot(Tree<T> nodeToSwap)
        {
            this.Value = nodeToSwap.Value;
            this._children.Clear();
            foreach (var child in nodeToSwap.Children)
            {
                this._children.Add(child);
            }
        }

        private void Dfs(Tree<T> subTree, List<T> result)
        {
            foreach (var child in subTree.Children)
            {
                this.Dfs(child, result);
            }
            result.Add(subTree.Value);
        }
        private void CheckIfEmptyTree(Tree<T> subTree)
        {
            if (subTree == null)
            {
                throw new ArgumentNullException();
            }
        }
        private Tree<T> FindByBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                if (subTree.Value.Equals(parentKey))
                {
                    return subTree;
                }
                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        private Tree<T> FindByDfs(T value, Tree<T> subTree)
        {
            foreach (var child in subTree.Children)
            {
                Tree<T> current = this.FindByDfs(value, child);

                if (current != null && current.Value.Equals(value))
                {
                    return current;
                }
            }

            if (subTree.Value.Equals(value))
            {
                return subTree;
            }

            return null;
        }
    }
}
