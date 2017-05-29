using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_2_4
{
    class Program
    {
        /*
         * You have two numbers represented by a linked list, where each node contains a single digit. 
         * The digits are stored in reverse order, such that the 1’s digit is at the head of the list. 
         * Write a function that adds the two numbers and returns the sum as a linked list.
         * 
         * EXAMPLE
         * Input: (3 -> 1 -> 5) + (5 -> 9 -> 2)
         * Output: 8 -> 0 -> 8
         */
        static void Main(string[] args)
        {
            SinglyLinkedList l1 = new SinglyLinkedList();
            SinglyLinkedList l2 = new SinglyLinkedList();
            l1.AddRange(new int[] { 3, 1, 5 });
            l2.AddRange(new int[] { 5, 9, 2 });

            SinglyLinkedList res = SumLists(l1, l2);
            
            Console.WriteLine(string.Join(" ", res.ToArray()));

            Console.Read();
        }

        static SinglyLinkedList SumLists(SinglyLinkedList l1, SinglyLinkedList l2)
        {
            SinglyLinkedList res = new SinglyLinkedList();
            SLNode n1 = l1.GetRoot();
            SLNode n2 = l2.GetRoot();

            int mod = 0;

            while (n1 != null || n2 != null)
            {
                int d1 = 0;
                int d2 = 0;
                if (n1 != null)
                    d1 = n1.Data;
                if (n2 != null)
                    d2 = n2.Data;
                int sum = d1 + d2 + mod;
                mod = sum / 10;
                res.Add(sum - mod * 10);

                if (n1 != null)
                    n1 = n1.Next;
                if (n2 != null)
                    n2 = n2.Next;
            }
            if (mod > 0)
            {
                res.Add(mod);
            }
            return res;
        }
    }
}
