using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 7, 3, 2, 4, 9, 5 };
            Console.WriteLine(string.Join(" ", numbers));
            MergeSort.Sort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
            Console.Read();
        }
    }

    class MergeSort
    {
        public static void Sort(int[] a)
        { 
            int[] tmp = new int[a.Length];
            SortHelper(a, tmp, 0, a.Length - 1);
        }

        private static void SortHelper(int[] arr, int[] tmp, int low, int high)
        {
            if (low >= high)
                return;
            int median = low + (high - low) / 2;
            SortHelper(arr, tmp, low, median);
            SortHelper(arr, tmp, median + 1, high);
            Merge(arr, tmp, low, median, high);
        }

        private static void Merge(int[] arr, int[] tmp, int low, int median, int high)
        {
            Array.Copy(arr, tmp, arr.Length);

            int l = low;
            int r = median + 1;
            int current = l;
            while (l <= median && r <= high)
            {
                if (tmp[l] <= tmp[r])
                {
                    arr[current] = tmp[l];
                    l++;
                }
                else
                {
                    arr[current] = tmp[r];
                    r++;
                }
                current++;
            }

            int offset = median - l;
            for (int i = 0; i <= offset; i++)
            {
                arr[current + i] = tmp[l + i];
            }
        }
    }
}
