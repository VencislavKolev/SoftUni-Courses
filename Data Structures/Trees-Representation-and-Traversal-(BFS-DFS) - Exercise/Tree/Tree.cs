namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder result = new StringBuilder();

            this.OrderDfsByString(0, result, this);

            return result.ToString().TrimEnd();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            Func<Tree<T>, bool> leafPredicate =
                (node) => this.IsLeaf(node);
            var leafNodes = this.GetTreesByBfs(leafPredicate);

            int deepestNodeDepth = 0;
            Tree<T> deepestNode = null;

            foreach (var node in leafNodes)
            {
                int currentDepth = this.GetDepthToParent(node);
                if (currentDepth > deepestNodeDepth)
                {
                    deepestNodeDepth = currentDepth;
                    deepestNode = node;
                }
            }
            return deepestNode;
        }
        public List<T> GetLongestPath()
        {
            Tree<T> deepestNode = this.GetDeepestLeftomostNode();
            Tree<T> currentNode = deepestNode;

            var path = new Stack<T>();
            while (currentNode != null)
            {
                path.Push(currentNode.Key);
                currentNode = currentNode.Parent;
            }
            return path.ToList();
        }
        public List<T> GetLeafKeys()
        {
            Func<Tree<T>, bool> leafPredicate =
                (node) => this.IsLeaf(node);

            return this.OrderBfs(leafPredicate);
        }

        public List<T> GetMiddleKeys()
        {
            Func<Tree<T>, bool> middleKeyPredicate =
                (node) => this.IsMiddle(node);

            return this.OrderBfs(middleKeyPredicate);
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();

            var currentPath = new List<T>() { this.Key };
            int currentSum = Convert.ToInt32(this.Key);

            this.GetPathSumByDfs(result, currentPath, this, ref currentSum, sum);

            return result;
        }

        private void GetPathSumByDfs(List<List<T>> result, List<T> currentPath, Tree<T> currentNode, ref int currentSum, int wantedSum)
        {
            foreach (var child in currentNode.Children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);

                this.GetPathSumByDfs(result, currentPath, child, ref currentSum, wantedSum);
            }

            if (currentSum == wantedSum)
            {
                result.Add(new List<T>(currentPath));
            }
            currentSum -= Convert.ToInt32(currentNode.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            Func<Tree<T>, int, bool> substreeSumPredicate =
                (currentNode, wantedSum) => this.HasGivenSum(currentNode, wantedSum);

            return this.GetTreesByBfs(substreeSumPredicate, sum);

            //var result = new List<Tree<T>>();
            //this.GetSubTreeSumByDfs(result, this, sum); // 75/100
            //return result;
        }

        private bool IsLeaf(Tree<T> subTree)
        {
            return subTree.Children.Count == 0;
        }
        private bool IsRoot(Tree<T> subTree)
        {
            return subTree.Parent == null;
        }
        private bool IsMiddle(Tree<T> subTree)
        {
            return subTree.Parent != null && subTree.Children.Count > 0;
        }

        private List<T> OrderBfs(Func<Tree<T>, bool> predicate)
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (predicate.Invoke(subTree))
                {
                    result.Add(subTree.Key);
                }
                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private bool HasGivenSum(Tree<T> node, int sum)
        {
            int actualSum = this.GetSubtreeSumDfs(node);

            return actualSum == sum;
        }
        private int GetSubtreeSumDfs(Tree<T> currentNode)
        {
            int currentSum = Convert.ToInt32(currentNode.Key);
            int childSum = 0;

            foreach (var child in currentNode.Children)
            {
                childSum += this.GetSubtreeSumDfs(child);
            }

            return currentSum + childSum;
        }
        private List<Tree<T>> GetTreesByBfs(Func<Tree<T>, bool> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (predicate.Invoke(subTree))
                {
                    result.Add(subTree);
                }
                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
        private List<Tree<T>> GetTreesByBfs(Func<Tree<T>, int, bool> predicate, int sum)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (predicate.Invoke(subTree, sum))
                {
                    result.Add(subTree);
                }
                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
        private int GetDepthToParent(Tree<T> node)
        {
            int depth = 0;
            var current = node;
            while (current.Parent != null)
            {
                depth++;
                current = current.Parent;
            }
            return depth;
        }
        private void OrderDfsByString(int depth, StringBuilder result, Tree<T> subTree)
        {
            result.AppendLine(new string(' ', depth) + subTree.Key);

            foreach (var child in subTree.Children)
            {
                this.OrderDfsByString(depth + 2, result, child);
            }
        }
        //private void GetSubTreeSumByDfs(List<Tree<T>> result, Tree<T> subTree, int wantedSum)
        //{
        //    int currentSum = Convert.ToInt32(subTree.Key);

        //    foreach (var child in subTree.Children)
        //    {
        //        currentSum += Convert.ToInt32(child.Key);
        //        this.GetSubTreeSumByDfs(result, child, wantedSum);
        //    }
        //    if (currentSum == wantedSum)
        //    {
        //        result.Add(subTree);
        //    }
        //}
    }
}
