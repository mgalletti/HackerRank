using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        
        HashSet<int> result = new HashSet<int>();
        foreach (int i in a) {
            if (!result.Contains(i))
                result.Add(i);
            else
                result.Remove(i);
        }
        IEnumerator<int> e = result.GetEnumerator();
        if (e.MoveNext())
            Console.WriteLine(e.Current.ToString());
    }
}