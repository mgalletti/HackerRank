using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace ctci_4_6
{
    class Program
    {
        /*
         * Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree. 
         * Avoid storing additional nodes in a data structure. NOTE: This is not necessarily a binary search tree.
         */
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            int[] input = { 7, 5, 8, 6, 3, 4, 1 };
            foreach (var i in input)
                tree.Insert(i);

            int n1 = 1;
            int n2 = 6;
            Node n = CommonAnchestor(tree.GetRoot(), tree.Find(n1), tree.Find(n2));
            if (n != null)
                Console.WriteLine(string.Format("CommonAnchestor({0}, {1}) = {2}", n1, n2, n.Data));
            else
                Console.WriteLine("no common anchestor");

            Console.Read();
        }

        static Node CommonAnchestor(Node root, Node n1, Node n2)
        {
            if (root == null)
                return null;
            if (NodeBelongsTo(root.Left, n1) && NodeBelongsTo(root.Left, n2))
                return CommonAnchestor(root.Left, n1, n2);
            if (NodeBelongsTo(root.Right, n1) && NodeBelongsTo(root.Right, n2))
                return CommonAnchestor(root.Right, n1, n2);
            return root;
        }

        static bool NodeBelongsTo(Node root, Node n)
        {
            if (root == null)
                return false;
            if (root == n)
                return true;
            return NodeBelongsTo(root.Left, n) || NodeBelongsTo(root.Right, n);
        }


    }
}
