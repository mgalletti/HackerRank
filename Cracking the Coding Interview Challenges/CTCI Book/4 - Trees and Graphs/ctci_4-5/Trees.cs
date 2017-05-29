using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
	class Node
	{
		public int Data { get; set; }
        public Node Parent { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
		public Node(int data, Node parent)
		{
			Data = data;
            Parent = parent;
		}
	}
	
	class BinarySearchTree
	{
		private Node root;
		
		public void Insert(int data)
		{
			root = Insert(null, root, data);
		}
		
		private Node Insert(Node parent, Node node, int data)
		{
			if (node == null)
                return new Node(data, parent);
				
			if (data < node.Data)
			{
				node.Left = Insert(node, node.Left, data);
			}
			else 
			{
                node.Right = Insert(node, node.Right, data);
			}
            return node;
		}

        public Node GetRoot()
        {
            return root;
        }

        private int MinHeight(Node node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Min(MinHeight(node.Left), MinHeight(node.Right));
        }

        private int MaxHeight(Node node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(MaxHeight(node.Left), MaxHeight(node.Right));
        }

        public bool IsBalanced()
        {
            return (MaxHeight(root) - MinHeight(root)) <= 1;
        }

        public Node Find(int data)
        {
            return BFSFindNode(root, data);
        }

        private Node BFSFindNode(Node node, int value)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                Node n = q.Dequeue();
                if (n.Data == value)
                    return n;
                if (n.Left != null)
                    q.Enqueue(n.Left);
                if (n.Right != null)
                    q.Enqueue(n.Right);
            }
            return null;
        }
	}
}