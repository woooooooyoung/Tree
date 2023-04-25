using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node root;
        // Node타입의 root변수 선언

        public BinarySearchTree()
        {
            this.root = null;
        }
        public class Node
        {
            public T item;
            public Node parent;
            public Node left;
            public Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }
            public T Item { get { return item; } set { item = value; } }
            public Node Parent { get { return parent; } set { parent = value; } }
            public Node Left { get { return left; } set { left = value; } }
            public Node Right { get { return right; } set { right = value; } }

            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            public bool HasNoChild { get { return left == null && right == null; } }
            public bool HasLeftChild { get { return left != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
        }
        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);

            if (root == null)
            {
                root = newNode;
                return;
            }
            Node current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)
                {
                    if(current.left !=null)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current.left = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    if (current.right != null)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        private void EraseNode(Node node)
        {
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)
                    node.Parent.Left = null;
                else if (node.IsRightChild)
                    node.parent.Right = null;
                else
                    root = null;
            }
            else if (node.HasLeftChild || node.HasRightChild)
            {
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.Left : node.Right;
                if(node.IsLeftChild)
                {
                    parent.Left = child;
                    child.parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.Right = child;
                    child.parent = parent;
                }
                else
                {
                    root = child;
                    child.Parent = null;
                }
            }
        }
        public bool Remove(T item)
        {
            if (root == null)
            {
                return false;
            }
            Node findNode = FindNode(item);
            if (findNode == null)
            {
                return false;
            }
            else
            {
                EraseNode(findNode);
                return true;
            }
        }
        public void Clear()
        {
            root = null;
        }
        public bool TryGetValue( T item, out T outValue)
        {
            if (root == null)
            {
                outValue = default(T);
                return false;
            }
            Node findNode = FindNode(item);
            if (findNode == null)
            {
                outValue = default(T);
                return false;
            }
            else
            {
                outValue = findNode.item;
                return true;
            }
        }
        public Node FindNode(T item)
        {
            if (root == null)
            {
                return null;
            }
            Node current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)
                {
                    current = current.Left;
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

    }
}
