using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
	class Node
	{
		public int Data { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
		public Node(int data) : this(data, null, null) {}
		public Node(int data, Node left, Node right)
		{
			Data = data;
			Left = left;
			Right = right;
		}
	}
	
	class BinarySearchTree
	{
		private Node root;
		
		public void Insert(int data)
		{
			root = Insert(root, data);
		}
		
		private Node Insert(Node node, int data)
		{
			if (node == null)
				return new Node(data);
				
			if (data < node.Data)
			{
				node.Left = Insert(node.Left, data);
			}
			else 
			{
				node.Right = Insert(node.Right, data);
			}
            return node;
		}

        public Node GetRoot()
        {
            return root;
        }
	}
}