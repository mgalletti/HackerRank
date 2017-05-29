using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace ctci_4_5
{
    /*
     * Write an algorithm to find the ‘next’ node (i.e., in-order successor) 
     * of a given node in a binary search tree where each node has a link to its parent.
     */

    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            int[] input = { 7, 5, 8, 6, 3, 4, 1 };
            foreach (var i in input)
                tree.Insert(i);

            int start = 7;
            Node succ = FindInorderSucc(tree.Find(start));
            Console.WriteLine(string.Join(" ", input));
            if (succ != null)
                Console.WriteLine(string.Format("in order successor of {0}: {1}", start, succ.Data));
            else
                Console.WriteLine("no in order successor");
            Console.Read();
        }

        static Node FindInorderSucc(Node start)
        {
            if (start == null)
                return null;
            if (start.Right != null)
            {
                return LeftMost(start.Right);
            }
            else
            {
                Node c = start;
                Node p;
                while ((p = c.Parent) != null)
                {
                    if (p.Left == c)
                        break;
                    c = c.Parent;
                }
                return p;
            }
        }

        static Node LeftMost(Node node)
        {
            if (node == null)
                return null;
            Node n = node;
            while (n.Left != null) 
            {
                n = n.Left;
            }
            return n;
        }
    }
}
