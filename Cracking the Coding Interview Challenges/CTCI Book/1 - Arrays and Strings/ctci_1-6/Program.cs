using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_1_6
{
    class Program
    {
        /*
         * Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, 
         * write a method to rotate the image by 90 degrees. Can you do this in place?
         */
        static void Main(string[] args)
        {
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 1, 0, 2, 2 };
            matrix[1] = new int[] { 1, 1, 0, 2, 2 };
            matrix[2] = new int[] { 0, 0, 0, 0, 0 };
            matrix[3] = new int[] { 4, 4, 0, 3, 3 };
            matrix[4] = new int[] { 4, 4, 0, 3, 3 };
            RotateMatrix(matrix, 5);
            for (int i = 0; i < 5; i++)
			{
                Console.WriteLine(string.Join(" ", matrix[i]));
			}
            Console.Read();
        }

        static void RotateMatrix(int[][] m, int length)
        {
            for (int level = 0; level < length / 2; level++)
            {
                int last = length - 1 - level;
                for (int i = level; i < last; i++)
                {
                    int offset = i - level;
                    int tmp = m[level][i];
                    m[level][i] = m[last - offset][level];
                    m[last - offset][level] = m[last][last - offset];
                    m[last][last - offset] = m[i][last];
                    m[i][last] = tmp;
                }
            }
        }
    }
}
