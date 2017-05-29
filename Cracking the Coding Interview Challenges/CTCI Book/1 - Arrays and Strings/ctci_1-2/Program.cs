using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_1_2
{
    class Program
    {
        /*
         * Write code to reverse a C-Style String.
         * (C-String means that “abcd” is represented as five characters, including the null character.)
         */
        static void Main(string[] args)
        {
            string name = "olleh";
            Console.WriteLine(ReverseString(name));
            Console.Read();
        }

        static string ReverseString(string value)
        {
            string result = "";
            for (int i = value.Length - 1; i >= 0; i--)
            {
                result += value[i];
            }
            return result;
        }
    }
}
