using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        
        Console.WriteLine(StringDeletion.DeletionNumber(a, b).ToString());
    }
    
    class AString
    {
        private Dictionary<char, int> s;
        private string original;

        public int Length { get { return original.Length; } }

        public AString(string value)
        {
            s = new Dictionary<char, int>();

            original = value;

            foreach (char c in value)
            {
                if (!s.ContainsKey(c))
                {
                    s.Add(c, 1);
                }
                else
                {
                    s[c]++;
                }
            }
        }

        public int CharCount(char c)
        {
            if (s.ContainsKey(c))
            {
                return s[c];
            }
            else
            {
                return 0;
            }
        }
    }

    class StringDeletion
    {
        static public int DeletionNumber(string a, string b)
        {
            int res = 0;
            AString aa = new AString(a), ab = new AString(b);

            for (char c = 'a'; c <= 'z'; c++)
            {
                res += Math.Abs(aa.CharCount(c) - ab.CharCount(c));
            }
            return res;
        }
    }
}