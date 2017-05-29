using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_5_1
{
    class Program
    {
        /*
         * You are given two 32-bit numbers, N and M, and two bit positions, i and j. 
         * Write a method to set all bits between i and j in N equal to M 
         * (e.g., M becomes a substring of N located at i and starting at j).
         * EXAMPLE:
         * Input: N = 10000000000 (1024), M = 10101 (21), i = 2, j = 6
         * Output: N = 10001010100 (1108)
        */
        static void Main(string[] args)
        {
            int N = 1024, M = 21, i = 2, j = 6;
            Console.WriteLine(MergeNumbers(N, M, i, j));
            Console.Read();
        }

        static int MergeNumbers(int n, int m, int i, int j)
        {
            int max = ~0; // not 0;
            int left = max - ((1 << j) - 1);
            int right = (1 << i) - 1;
            int mask = right | left;
            return (n & mask) | (m << i);
        }
    }
}
