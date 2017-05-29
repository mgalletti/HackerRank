using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace ctci_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Implement a function to check if a tree is balanced. For the purposes of this question, 
             * a balanced tree is defined to be a tree such that no two leaf nodes differ in distance from the root by more than one.
             */

            //int[] inputs = { 6, 2, 7, 8, 4, 9 }; // no
            int[] inputs = { 16, 14, 17, 8, 24, 15 }; // yes
            BinarySearchTree tree = new BinarySearchTree();

            foreach (var item in inputs)
            {
                tree.Insert(item);
            }
            Console.WriteLine("inputs: " + string.Join(" ", inputs));

            if (CheckIfBalanced(tree))
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
            Console.Read();
        }

        // 1. Calc the height of the tree
        static int HeightOfTree(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(HeightOfTree(node.Left), HeightOfTree(node.Right));
        }

        // 2. tree is balanced if the abs value of difference between height of left node and right node is no more than 1 and
        //    the left tree is balanced and the right tree is balanced
        static bool IsBalanced(Node node)
        {
            if (node == null)
                return true;

            int lh = HeightOfTree(node.Left);
            int rh = HeightOfTree(node.Right);

            if (Math.Abs(lh - rh) <= 1 && IsBalanced(node.Left) && IsBalanced(node.Right))
                return true;
            else
                return false;
        }

        static bool CheckIfBalanced(BinarySearchTree tree)
        { 
            return IsBalanced(tree.GetRoot());
        }

    }
}
