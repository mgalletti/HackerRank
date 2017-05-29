using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_1_3
{
    class Program
    {
        /*
         * Design an algorithm and write code to remove the duplicate characters in a string 
         * without using any additional buffer. NOTE: One or two additional variables are fine. 
         * An extra copy of the array is not.
	    */
        static void Main(string[] args)
        {
            string value = "aajjcjkallmmm";
            Console.WriteLine(RemoveDuplicates(value)); // ajcklm
            Console.WriteLine(new string(RemoveDuplicates(value.ToArray<char>()))); // ajcklm
            Console.Read();
        }

        // O(n) complexity
        static string RemoveDuplicates(string value)
        {
            int checker = 0;
            string result = "";
            for (int i = 0; i < value.Length; i++)
            {
                int val = value[i] - 'a';
                if ((checker & (1 << val)) > 0)
                {
                    continue;
                }
                checker |= (1 << val);
                result += value[i];
            }
            return result;
        }

        // O(n) complexity
        static char[] RemoveDuplicates(char[] value)
        {
            if (value == null) 
                return value;
            int len = value.Length;
            if (len < 2) 
                return value;
            
            int tail = 1;

            for (int i = 1; i < len; ++i)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (value[i] == value[j]) break;
                }
                if (j == tail)
                {
                    value[tail] = value[i];
                    ++tail;
                }
            }
            while (tail < len)
            {
                value[tail] = '\0';
                tail++;
            }
            return value;
        }
    }
}
