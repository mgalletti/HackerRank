using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_2_3
{
    class Program
    {
        /*
        * Implement an algorithm to delete a node in the middle of a single linked list, given only access to that node.
        * EXAMPLE
        * Input: the node ‘c’ from the linked list a->b->c->d->e
        * Result: nothing is returned, but the new linked list looks like a->b->d->e
        */
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();
            int[] numbers = { 1, 2, 3, 4, 5 };
            list.AddRange(numbers);
            Console.WriteLine(string.Join(" ", numbers));
            RemoveNode(list.FindNode(3));
            Console.WriteLine(string.Join(" ", list.ToArray()));
            Console.Read();
        }

        static bool RemoveNode(SLNode node)
        {
            if (node == null || node.Next == null)
            {
                return false;
            }
            SLNode next = node.Next;
            node.Data = next.Data;
            node.Next = next.Next;
            return true;
        }
    }
}
