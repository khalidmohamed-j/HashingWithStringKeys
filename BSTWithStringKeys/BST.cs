using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace BSTWithStringKeys
{
    public class BST
    {

        internal class Node
        {
            //For demo purposes, this node has only a key.  No value.
            public string Key;
            public string Value;
            public Node Left;
            public Node Right;
        }

        internal Node Root;

        public BST()
        {
            Root = null;
        }


        public void Insert(string key, string value)
        {
            Root = Insert(Root, key, value);
        }
        private Node Insert(Node parent, string key, string value)
        {
            if (parent == null)
            {
                parent = new Node();
                parent.Key = key;
                parent.Value = value;
            }
            else if (string.Compare(key, parent.Key) == -1)
            {
                parent.Left = Insert(parent.Left, key, value);
                parent = BalanceTree(parent);
            }
            else
            {
                parent.Right = Insert(parent.Right, key, value);
                parent = BalanceTree(parent);
            }
            return parent;
        }

       
        private Node BalanceTree(Node node)
        {
            int balanceFactor = GetBalanceFactor(node);
            if (balanceFactor > 1)  //Left subtree is taller than right subtree
            {
                if (GetBalanceFactor(node.Left) > 0)  //Left.left is taller than left.right
                {
                    node = RotateRight(node);
                }
                else
                {
                    node = RotateLeftRight(node);
                }
            }
            else if (balanceFactor < -1) //Right subtree is taller than left
            {
                if (GetBalanceFactor(node.Right) > 0)  //Right.left is taller than right.right.
                {
                    node = RotateRightLeft(node);
                }
                else
                {
                    node = RotateLeft(node);
                }
            }
            return node;
        }

        private Node RotateRight(Node curr)
        {
            Node pivot = curr.Left;
            curr.Left = pivot.Right;
            pivot.Right = curr;
            return pivot;
        }

        private Node RotateLeft(Node curr)
        {
            Node pivot = curr.Right;
            curr.Right = pivot.Left;
            pivot.Left = curr;
            return pivot;
        }

        private Node RotateRightLeft(Node curr)
        {
            Node pivot = curr.Right;
            curr.Right = RotateRight(pivot);
            curr = RotateLeft(curr);
            return curr;
        }

        private Node RotateLeftRight(Node curr)
        {
            Node pivot = curr.Left;
            curr.Left = RotateLeft(pivot);
            return RotateRight(curr);
        }



        private int GetBalanceFactor(Node node)
        {
            int l = GetHeight(node.Left);
            int r = GetHeight(node.Right);
            int balanceFactor = l - r;
            return balanceFactor;
        }

        private int GetHeight(Node node)
        {
            int height = 0;
            if (node != null)
            {
                int l = GetHeight(node.Left);
                int r = GetHeight(node.Right);
                int m = l > r ? l : r;
                height = m + 1;
            }
            return height;
        }

        public void Traverse()
        {
            Traverse(Root);
        }
        private void Traverse(Node node)
        {
            if (node == null) return;
            Traverse(node.Left);
            WriteLine($"{node.Key} ({node.Value})."); 
            Traverse(node.Right);
        }

        public void Delete(string pKey)
        {
            Root = Delete(Root, pKey);
        }

        private Node Delete(Node node, string pKey)
        {
            if (node == null) return node;

            if (string.Compare(pKey, node.Key) == -1)
            {
                node.Left = Delete(node.Left, pKey);
                node = BalanceTree(node);

            }
            else if (string.Compare(pKey, node.Key) == 1)
            {
                node.Right = Delete(node.Right, pKey);
                node = BalanceTree(node);
            }
            else
            {
                //Case where node has zero or one child.  Just delete it.
                if (node.Right == null)
                {
                    node = node.Left;
                    if (node != null) node = BalanceTree(node);

                }
                else if (node.Left == null)
                {
                    node = node.Right;
                    if (node != null) node = BalanceTree(node);
                }
                else
                {

                    node.Key = MaxLeftChildValue(node.Left);
                    node.Left = Delete(node.Left, node.Key);
                    node = BalanceTree(node);
                }

            }

            return node;
        }


        private string MaxLeftChildValue(Node node)
        {
            string maxVal = node.Key;
            while (node.Right != null)
            {
                maxVal = node.Right.Key;
                node = node.Right;
            }

            return maxVal;
        }

        public string Find(string key)
        {
            return Find(Root, key);
        }

        private string Find(Node node, string pKey)
        {
            if (node == null) return null;

            if (string.Compare(pKey, node.Key) == 0) return node.Value;

            if (string.Compare(pKey, node.Key) == 1) 
            {
                if (node.Right == null)
                {
                    return null;
                }
                else
                {
                    node = node.Right;
                    return Find(node, pKey);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    return null;
                }
                else
                {
                    node = node.Left;
                    return Find(node, pKey);
                }
            }
        }

    }
}
