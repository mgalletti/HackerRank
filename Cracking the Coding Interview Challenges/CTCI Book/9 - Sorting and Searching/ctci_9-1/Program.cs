using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_9_1
{
    class Program
    {
        /*
         * You are given two sorted arrays, A and B, and A has a large enough buffer at the end to hold B. 
         * Write a method to merge B into A in sorted order.
         */
        static void Main(string[] args)
        {
            int[] a = { 45, 67, 87, 142, 166, 246, 367 };
            int[] slave = { 1, 55, 366, 477, 688, 799 };
            int[] master = new int[a.Length + slave.Length];
            List<int> result = new List<int>();
            result.AddRange(a);
            result.AddRange(slave);
            result.Sort();

            Array.Copy(a, 0, master, 0, a.Length);
            MergeSortedArrays(master, slave);
            Console.WriteLine("first: " + string.Join(" ", a));
            Console.WriteLine("second: " + string.Join(" ", slave));
            Console.WriteLine("merged: " + string.Join(" ", master));
            Console.WriteLine("expected: " + string.Join(" ", result.ToArray()));

            Console.Read();
        }

        static void MergeSortedArrays(int[] master, int[] slave)
        {
            Stack<int> s = new Stack<int>(slave);
            int j = master.Length - slave.Length - 1;
            for (int i = (master.Length - 1); i >= 0 ; --i)
            {
                if (s.Count == 0)
                    break;
                if (j >= 0 && master[j] > s.Peek() && j != i)
                {
                    master[i] = master[j];
                    j--;
                }
                else
                    master[i] = s.Pop();
            }
        }
    }
}
