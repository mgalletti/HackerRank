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
            int[] ic = BuyIceCream(m, a);
            Console.WriteLine(string.Join(" ", ic));
        }
    }
    
    static int[] BuyIceCream(int money, int[] flavours)
    {
        int[] result = new int[2];
        for (int i = 0; i < flavours.Length; i++)
        {
            if (flavours[i] > money)
                continue;
            int complement = money - flavours[i];
            int j = BSFlavour(flavours, complement, 0, flavours.Length - 1, i);
            if (j >= 0)
            {
                if (i < j)
                {
                    result[0] = i + 1;
                    result[1] = j + 1;
                }
                else
                {
                    result[0] = j + 1;
                    result[1] = i + 1;
                }
                return result;
            }
        }
        throw new ArgumentException("There's no possible combination");
        
    }

    static int BSFlavour(int[] f, int cost, int low, int high, int skip)
    {
        if (low > high)
            return -1;
        int mid = low + (high - low) / 2;
        if (f[mid] == cost && mid != skip)
            return mid;
        else if (cost < f[mid])
            return BSFlavour(f, cost, low, mid - 1, skip);
        else if (cost > f[mid])
            return BSFlavour(f, cost, mid + 1, high, skip);
        else
            return -1;
    }
}