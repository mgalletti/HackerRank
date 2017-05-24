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
            
            Console.WriteLine("Distance between 4 and 6: " + tree.FindDistance(4, 6).ToString()); // expected: 2
            Console.WriteLine("Distance between 3 and 6: " + tree.FindDistance(3, 6).ToString()); // expected: 4
            Console.WriteLine("Distance between 3 and 6: " + tree.FindDistance(2, 8).ToString()); // expected: 3
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

        public Node FindNode(int value)
        {
            return FindNode(root, value);
        }

        private Node FindNode(Node node, int value)
        {
            if (node == null)
                return null;
            if (node.Data == value)
                return node;
            if (value < node.Data)
                return FindNode(node.Left, value);
            else
                return FindNode(node.Right, value);
        }

        private bool FindPath(Node node, Stack<int> path, int value)
        {
            if (node == null)
                return false;
            path.Push(value);
            if (node.Data == value)
                return true;
            if (FindPath(node.Left, path, value) || FindPath(node.Right, path, value))
                return true;
            path.Pop();
            return false;
        }
        public int FindDistance(int value1, int value2)
        {
            Stack<int> path1 = new Stack<int>(), path2 = new Stack<int>();
            if (!FindPath(root, path1, value1) || !FindPath(root, path2, value2))
                return -1;
            Queue<int> queue1 = new Queue<int>(path1);
            Queue<int> queue2 = new Queue<int>(path2);
            while (queue1.Count > 0 && queue2.Count > 0 && queue1.Dequeue() == queue2.Dequeue()){ }
            return queue1.Count + queue2.Count;
        }
    }
}
