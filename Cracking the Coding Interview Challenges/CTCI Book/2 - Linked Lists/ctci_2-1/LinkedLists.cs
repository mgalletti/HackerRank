using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_2_1
{
    class SLNode
    {
        public int Data { get; set; }
        public SLNode Next { get; set; }
        public SLNode(int data)
        {
            Data = data;
        }
    }

    class SinglyLinkedList
    {
        private SLNode root;

        public void AddRange(int[] datas)
        {
            foreach (var item in datas)
            {
                Add(item);
            }
        }

        public void Add(int data)
        {
            root = Add(root, data);
        }

        private SLNode Add(SLNode node, int data)
        {
            if (node == null)
            {
                return new SLNode(data);
            }
            node.Next = Add(node.Next, data);
            return node;
        }

        public SLNode GetRoot()
        {
            return root;
        }

        public int[] ToArray()
        {
            SLNode curr = root;
            List<int> l = new List<int>();
            while (curr != null)
            {
                l.Add(curr.Data);
                curr = curr.Next;
            }
            return l.ToArray();
        }
    }
}