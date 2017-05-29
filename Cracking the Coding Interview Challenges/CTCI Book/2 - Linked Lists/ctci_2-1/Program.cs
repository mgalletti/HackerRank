using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_2_1
{
    class Program
    {
        /*
         * Write code to remove duplicates from an unsorted linked list.
         * FOLLOW UP
         * How would you solve this problem if a temporary buffer is not allowed?
         */
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();
            int[] numbers = { 5, 28, 15, 5, 48, 15, 7 };
            list.AddRange(numbers);
            Console.WriteLine(string.Join(" ", numbers));
            RemoveDuplicates(list);
            Console.WriteLine(string.Join(" ", list.ToArray()));
            Console.Read();
        }

        static void RemoveDuplicates(SinglyLinkedList list)
        {
            SLNode root = list.GetRoot();
            SLNode curr = root;
            int counter = 0;
            while (curr != null)
            {
                if (curr.Next == null)
                    break;
                if ((counter & (1 << curr.Next.Data)) > 0)
                {
                    curr.Next = curr.Next.Next;
                }
                counter |= 1 << curr.Data;
                curr = curr.Next;
            }
        }
    }
}
