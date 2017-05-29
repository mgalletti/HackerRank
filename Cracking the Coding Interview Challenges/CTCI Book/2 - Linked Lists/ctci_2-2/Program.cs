using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_2_2
{
    class Program
    {
        /*
         * Implement an algorithm to find the nth to last element of a singly linked list.
         */
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();
            int[] numbers = { 5, 28, 15, 5, 48, 15, 7 };
            list.AddRange(numbers);
            Console.WriteLine(string.Join(" ", numbers));
            int n = 2;
            SLNode subList = SubListN2Last(list.GetRoot(), n);
            Console.WriteLine(string.Format("last {0} nodes: ", n) + string.Join(" ", SinglyLinkedList.ToArray(subList)));
            Console.Read();
        }

        static SLNode SubListN2Last(SLNode listHead, int n)
        {
            if (listHead == null || n < 1)
            {
                return null;
            }
            SLNode start = listHead;
            SLNode end = listHead;
            for (int i = 0; i < n; i++)
            {
                if (end == null)
                    return null;
                end = end.Next;
            }
            while (end != null)
            {
                start = start.Next;
                end = end.Next;
            }
            return start;
        }
    }
}
