using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_5_5
{
    class Program
    {
        /*
        Write a function to determine the number of bits required to convert integer A to integer B.
        Input: 31, 14
        Output: 2
        */
        static void Main(string[] args)
        {
            int a = 31, b = 14;

            Console.WriteLine(string.Format("number of bits to get {0} out of {1}: {2}", b, a, CountBitConversion(a, b)));
            Console.Read();
        }

        static int CountBitConversion(int a, int b)
        {
            int count = 0;
            for (int i = a ^ b; i != 0; i = i >> 1)
            {
                count += i & 1;
            }
            return count;
        }
    }
}
