using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_m = Console.ReadLine().Split(' ');
        int m = Convert.ToInt32(tokens_m[0]);
        int n = Convert.ToInt32(tokens_m[1]);
        string[] magazine = Console.ReadLine().Split(' ');
        string[] ransom = Console.ReadLine().Split(' ');
        
        Dictionary<string, int> tracer = new Dictionary<string, int>(m);
        foreach (var word in magazine) {
            if (tracer.ContainsKey(word))
                tracer[word]++;
            else
                tracer.Add(word, 1);
        }
        foreach (var word in ransom) {
            if (tracer.ContainsKey(word) && tracer[word]>0) {
                n--;
                tracer[word]--;
            }
        }
        if (n == 0) {
            Console.WriteLine("Yes");
        }
        else {
            Console.WriteLine("No");
        }
    }
}