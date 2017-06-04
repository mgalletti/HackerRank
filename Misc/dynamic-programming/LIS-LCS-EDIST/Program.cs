using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            // Longest Increasing Subsequence
            Console.WriteLine(" ## Longest Increasing Subsequence");
            int[] n = { 10, 22, 9, 33, 21, 50, 41, 60, 80 }; // result = 6
            LIS lis = new LIS();
            int[] res = lis.CalcLength(n);
            Console.WriteLine("Numbers: " + string.Join(" ", n));
            Console.WriteLine("Length of LIS: " + res.Length.ToString());
            Console.WriteLine("Sequence: " + string.Join(" ", res));
            Console.WriteLine();

            // Longest Common Subsequeces
            Console.WriteLine(" ## Longest Common Subsequeces");
            string a = "nematode knowledge";
            string b = "empty bottle";
            LCS lcs = new LCS();
            Console.WriteLine("string a: " + a);
            Console.WriteLine("string b: " + b);
            Console.WriteLine("Length of LCS: " + lcs.CalcLength(a, b).ToString());
            
            Console.WriteLine();

            // Edit Distance
            Console.WriteLine(" ## Edit Distance");
            a = "sunday";
            b = "saturday";
            EDIST e = new EDIST();
            Console.WriteLine("string a: " + a);
            Console.WriteLine("string b: " + b);
            Console.WriteLine("Cost: " + e.CalcCost(a, b).ToString());

            Console.WriteLine();
            Console.WriteLine(" ## Maximum sum such that no two elements are adjacent");

            n = new int[] { 5, 5, 10, 100, 10, 5 };
            Console.WriteLine(string.Join(" ", n));
            Console.WriteLine("Sum: "+MaxSum.Calc(n).ToString()); // 110;
            Console.WriteLine();

            // Assembly Line Scheduling
            Console.WriteLine(" ## Assembly Line Scheduling");

            AssemblyLine l1 = new AssemblyLine(1, new int[] { 4, 5, 3, 2 });
            l1.Entry = 10;
            l1.Exit = 18;
            l1.AddTransitions(2, new int[] { 0, 7, 4, 5 });
            AssemblyLine l2 = new AssemblyLine(2, new int[] { 2, 10, 1, 4 });
            l2.Entry = 12;
            l2.Exit = 7;
            l2.AddTransitions(1, new int[] { 0, 9, 2, 8 });
            Console.WriteLine("Minimum assembly time: " + AssemblyLineScheduling.FindMinimumTime(l1, l2).ToString());


            Console.Read();
        }
    }

    // Longest Increasing Subsequence
    class LIS
    {
        private List<int> seq = new List<int>();

        public int[] CalcLength(int[] a)
        {
            int n = a.Length;
            if (n == 1)
                return a;

            int i = 0;
            int l = 0;
            int max = 0;
            int[] res = null;
            while (i < n && max < n - i)
            {
                seq.Clear();
                l = SubCalcLength(a, 0, i);
                if (l > max)
                {
                    res = seq.ToArray();
                    max = l;
                }

                // if only length is required..
                //max = Math.Max(SubCalcLength(a, 0, i), max);
                i++;
            }
            return res;
        }

        private int SubCalcLength(int[] a, int prev, int start)
        {
            if (start >= a.Length)
                return 0;
            if (a[start] > prev)
            {
                seq.Add(a[start]);
                return 1 + SubCalcLength(a, a[start], start + 1);
            }
            else
                return 0 + SubCalcLength(a, a[start], start + 1);
        }
    }
    // Longest Common Subsequence
    class LCS
    {
        int[][] l;
        char[] _a;
        char[] _b;

        private void InitStorage(int n, int m)
        {
            l = new int[n][];
            for (int i = 0; i < n; i++)
            {
                l[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    l[i][j] = -1;
                }
            }
        }

        public int CalcLength(string a, string b)
        {
            _a = a.ToCharArray();
            _b = b.ToCharArray();
            InitStorage(a.Length, b.Length);
            return SubCalcLength(0, 0);
        }

        private int SubCalcLength(int i, int j)
        {
            if (i >= _a.Length || j >= _b.Length)
                return 0;
            if (l[i][j] < 0)
            {
                if (_a[i] == _b[j])
                {
                    l[i][j] = 1 + SubCalcLength(i + 1, j + 1);
                }
                else
                    l[i][j] = Math.Max(SubCalcLength(i, j + 1), SubCalcLength(i + 1, j));
            }
            return l[i][j];
        }
    }
    // Edit Distance
    class EDIST
    {
        private int CalcMin(int x, int y, int z)
        {
            if (x < y && x < z)
                return x;
            else if (y < x && y < z)
                return y;
            else
                return z;
        }

        public int CalcCost(string a, string b)
        {
            //return SubCalcCost_Recursive(a.ToCharArray(), b.ToCharArray(), a.Length - 1, b.Length - 1);
            return SubCalcCost_Iterative(a, b);
        }

        private int SubCalcCost_Recursive(char[] a, char[] b, int i, int j)
        {
            if (i < 0 || j < 0)
                return 0;
            if (i == 0)
                return j;
            if (j == 0)
                return i;

            if (a[i] == b[j])
                return SubCalcCost_Recursive(a, b, i - 1, j - 1);

            return 1 + CalcMin(  
                SubCalcCost_Recursive(a, b, i, j - 1), // insert
                SubCalcCost_Recursive(a, b, i - 1, j), // remove
                SubCalcCost_Recursive(a, b, i - 1, j - 1)); // replace
        }

        private int[][] GetStorageMatrix(int w, int h)
        {
            int[][] m = new int[w][];
            for (int i= 0; i < w; i++)
            {
                m[i] = new int[h];
            }
            return m;
        }

        private int SubCalcCost_Iterative(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;
            int[][] l = GetStorageMatrix(n + 1, m + 1);
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0)
                        l[i][j] = j;
                    else if (j == 0)
                        l[i][j] = i;
                    else if (a[i - 1] == b[j - 1])
                        l[i][j] = l[i - 1][j - 1];
                    else
                        l[i][j] = 1 + CalcMin(l[i][j - 1], l[i - 1][j], l[i - 1][j - 1]);

                }
            }
            return l[n][m];
        }
    }
    // Maximum sum such that no two elements are adjacent
    class MaxSum
    {
        /*Algorithm:
         * Loop for all elements in arr[] and maintain two sums incl and excl where incl = Max sum 
         * including the previous element and excl = Max sum excluding the previous element.

         * Max sum excluding the current element will be max(incl, excl) and max sum including 
         * the current element will be excl + current element (Note that only excl is considered because elements cannot be adjacent).

         * At the end of the loop return max of incl and excl.
         */
        public static int Calc(int[] a)
        {
            int n = a.Length;
            if (n == 0)
                return 0;

            int incl = a[0];
            int excl = 0;
            int tmp;
            for (int i = 1; i < n; i++)
            {
                // current max excluding i
                tmp = Math.Max(incl, excl);
                incl = a[i] + excl;
                excl = tmp;
            }
            return Math.Max(excl, incl);
        }
    }

    // rif.: http://www.geeksforgeeks.org/dynamic-programming-set-34-assembly-line-scheduling/
    class AssemblyLine
    {
        private int _id;
        public int Entry { get; set; }
        public int Exit { get; set; }
        public int[] Stations { get; set; }
        public int ID { get { return _id; } }
        public Dictionary<int, int[]> Transitions { get; set; }
        public int[] PartialTimes { get; set; }

        public AssemblyLine (int id, int[] stations)
	    {
            _id = id;
            Stations = stations;
            Transitions = new Dictionary<int,int[]>();
            PartialTimes = new int[stations.Length];
	    }

        public void AddTransitions(int lineId, int[] t)
        {
            if (Transitions.ContainsKey(lineId))
                Transitions.Remove(lineId);
            Transitions.Add(lineId, t);
        }
    }

    class AssemblyLineScheduling
    {
        public static int FindMinimumTime(AssemblyLine line1, AssemblyLine line2)
        {
            int n = line1.Stations.Length;
            int[] T1 = new int[n];
            int[] T2 = new int[n];

            T1[0] = line1.Entry + line1.Stations[0];
            T2[0] = line2.Entry + line2.Stations[0];
            for (int i = 1; i < n; ++i)
            {
                T1[i] = Math.Min(T1[i - 1] + line1.Stations[i], T2[i - 1] + line2.Transitions[line1.ID][i] + line1.Stations[i]);
                T2[i] = Math.Min(T2[i - 1] + line2.Stations[i], T1[i - 1] + line1.Transitions[line2.ID][i] + line2.Stations[i]);
            }
            return Math.Min(T1[n - 1] + line1.Exit, T2[n - 1] + line2.Exit);
        }
    }
}
