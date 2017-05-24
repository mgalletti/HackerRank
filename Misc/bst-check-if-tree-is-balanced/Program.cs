using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 4, 7, 2, 6, 8, 3, 1};
            BSTTree tree = new BSTTree();
            foreach (var n in numbers)
                tree.Add(n);
            
            Console.WriteLine("Height of tree: " + tree.Height());
            Console.WriteLine("Tree is balances? " + tree.IsBalanced().ToString());
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int data)
        {
            Data = data;
        }
    }
    public class BSTTree
    {
        private Node root;
        public void Add(int value)
        {   
            root = Add(root, value);
        }
        private Node Add(Node node, int value) 
        {
            if (node == null)
            {
                return new Node(value);
            }
            else
            {
                if (value < node.Data)
                    node.Left = Add(node.Left, value);
                else
                    node.Right = Add(node.Right, value);
                return node;
            }
        }		

        public bool IsBalanced()
        {
            return IsBalanced(root);
        }

        private bool IsBalanced(Node node)
        {
            int lh = 0, lr = 0;
            if (node == null)
                return true;

            lh = Height(node.Left);
            lr = Height(node.Right);
            if (Math.Abs(lh - lr) <= 1 && IsBalanced(node.Left) && IsBalanced(node.Right))
                return true;
            else
                return false;
        }

        public int Height()
        {
            if (root == null)
                return 0;
            else
                return Height(root) - 1;
        }

        public int Height(Node node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
    }
}
