using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci_4_2
{
    class Node
    {
        public int Data { get; set; }
        public List<Node> Nodes { get; set; }
        public Node(int data, Node[] nodes = null)
        {
            Data = data;
            Nodes = new List<Node>();
            if (nodes != null)
                Nodes.AddRange(nodes);
        }
    }

    class Program
    {
        static Dictionary<int, Node> CreateGraph()
        {
            /*  ,-->2-->4-->6
             *  |   ^
             *  1   |
             *      |
             *  8-->3-->5
             */

            Dictionary<int, Node> graph = new Dictionary<int, Node>();
            graph.Add(5, new Node(5));
            graph.Add(6, new Node(6));
            graph.Add(4, new Node(4, new Node[] { graph[6] }));
            graph.Add(2, new Node(2, new Node[] { graph[4] }));
            graph.Add(3, new Node(3, new Node[] { graph[5], graph[2] }));
            graph.Add(1, new Node(1, new Node[] { graph[2] }));
            graph.Add(8, new Node(8, new Node[] { graph[3] }));
            return graph;

        }

        static void Main(string[] args)
        {
            Dictionary<int, Node> graph = CreateGraph();
            // start -> target
            int start = 8; 
            int target = 2;
            Console.Write(string.Format("{0} -> {1} with DFS: ", start, target));
            if (DFSFindNode(graph[start], target) != null)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

            Console.Write(string.Format("{0} -> {1} with BFS: ", start, target));
            if (BFSFindNode(graph[start], target) != null)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

            Console.Read();
        }


        static Node DFSFindNode(Node node, int value)
        {
            if (node == null)
                return null;
            if (node.Data == value)
                return node;
            foreach (var n in node.Nodes)
            {
                Node res = DFSFindNode(n, value);
                if (res != null)
                    return res;
            }

            return null;
        }

        static Node BFSFindNode(Node node, int value)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                Node n = q.Dequeue();
                if (n.Data == value)
                {
                    return n;
                }
                foreach (var item in n.Nodes)
                {
                    q.Enqueue(item);
                }
            }
            return null;
        }
    }
}
