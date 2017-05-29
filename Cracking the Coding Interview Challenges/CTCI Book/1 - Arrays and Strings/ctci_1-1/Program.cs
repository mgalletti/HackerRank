using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_1_1
{
    class Program
    {
        /*
         * Implement an algorithm to determine if a string has all unique characters. 
         * What if you can not use additional data structures?
         */
        static void Main(string[] args)
        {
            string value = "alskfiemju";
            //if (HasAllUniqueChars1(value.ToArray<char>()))
            //if (HasAllUniqueChars2(value))
            if (HasAllUniqueChars3(value))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");

            Console.ReadLine();
        }

        static bool HasAllUniqueChars1(char[] value)
        {
            Array.Sort(value);
            for (int i = 0; i < value.Length - 1; i++)
            {
                if (value[i] == value[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool HasAllUniqueChars2(string value)
        {
            bool[] flags = new bool[256];
            for (int i = 0; i < value.Length; i++)
            {
                if (flags[value[i]])
                {
                    return false;
                }
                flags[value[i]] = true;
            }
            return true;
        }
        
        static bool HasAllUniqueChars3(string value)
        {
            int checker = 0;
            for (int i = 0; i < value.Length; i++)
            {
                int val = value[i] - 'a';
                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }
                checker |= (1 << val);
            }
            return true;
        }
    }
}
