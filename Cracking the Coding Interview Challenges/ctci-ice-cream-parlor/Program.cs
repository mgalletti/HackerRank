using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp,Int32.Parse);
            Console.WriteLine(string.Join(" ", BuyIceCream(m, a)));
        }
    }

    static int[] BuyIceCream(int money, int[] flavours)
    {
        Dictionary<int, List<int>> prices = new Dictionary<int, List<int>>();

        for (int i = 0; i < flavours.Length; i++)
        {
            if (!prices.ContainsKey(flavours[i]))
                prices.Add(flavours[i], new List<int>());

            prices[flavours[i]].Add(i);
        }

        for (int i = 0; i < flavours.Length; i++)
        {
            int complement = money - flavours[i];
            if (prices.ContainsKey(complement))
            {
                prices[complement].Remove(i);
                return new int[] { i + 1, prices[complement][0] + 1 };
            }
        }
        return new int[] { 0, 0 };
    }
}
