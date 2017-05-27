using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print all uniques permutations of a string
			string value = "aabc"; // permutations: aabc aacb abac abca acab acba baac baca bcaa caab caba cbaa

            Permuter p = new Permuter();
            Console.WriteLine(string.Join(" ", p.Calc(value)));
            Console.ReadLine();
        }
    }

    class Permuter
    {
        private class Element
        {
            public char Letter { get; set; }
            public int Count { get; set; }
            public Element(char letter, int count)
            {
                Letter = letter;
                Count = count;
            }
        }

        private List<string> permutations = new List<string>();

        private Element[] InitElements(string value)
        {
            Dictionary<char, int> counter = new Dictionary<char, int>();
            foreach (var c in value)
            {
                if (counter.ContainsKey(c))
                    counter[c]++;
                else
                    counter.Add(c, 1);
            }
            return counter.Select(x => new Element(x.Key, x.Value)).ToArray<Element>();
        }

        public string[] Calc(string value)
        {
            permutations.Clear();
            Element[] e = InitElements(value);
            CalcElements(e, new char[value.Length], 0);
            return permutations.ToArray();
        }
        
        private void CalcElements(Element[] items, char[] value, int index)
        {
            if (index == value.Length)
            {
                permutations.Add(new string(value));
                return;
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Count == 0)
                    continue;
                value[index] = items[i].Letter;
                items[i].Count--;
                CalcElements(items, value, index + 1);
                items[i].Count++;
            }
        }
    }
}
