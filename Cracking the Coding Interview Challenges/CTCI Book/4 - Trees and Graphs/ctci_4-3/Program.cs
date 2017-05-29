using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace ctci_4_3
{
    class Program
    {
        /*
         * Given a sorted (increasing order) array, write an algorithm to create a binary tree with minimal height.
         */
        static void Main(string[] args)
        {
            int[] input = { 1, 4, 8, 9, 12, 15, 17, 22, 31 };
            BinarySearchTree tree = new BinarySearchTree();
            AddInputBalancingTree(tree, input);
            Console.Write("Is tree balanced? ");
            if (tree.IsBalanced())
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
            Console.Read();
        }

        static void AddInputBalancingTree(BinarySearchTree tree, int[] input)
        {
            AddToTree(tree, input, 0, input.Length - 1);
        }

        static void AddToTree(BinarySearchTree tree, int[] input, int low, int high)
        {
            if (low > high)
                return;
            int median = low + (high - low) / 2;
            tree.Insert(input[median]);
            AddToTree(tree, input, low, median - 1);
            AddToTree(tree, input, median + 1, high);
        }
    }
}
