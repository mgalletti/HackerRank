using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        Trie trie = new Trie();
        
        int n = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < n; a0++){
            string[] tokens_op = Console.ReadLine().Split(' ');
            string op = tokens_op[0];
            string contact = tokens_op[1];
            
            if (op.Equals("add"))
                trie.AddString(contact);
            else
                Console.WriteLine(trie.FindOccurences(contact).ToString());
        }
    }
}

class Node
{
    private char value;
    public int Count { get; set; }

    public char Value { get { return value; } }

    public Node(char c) : this(c, 1) { }
    public Node(char c, int count)
    {
        value = c;
        Count = count;
        children = new Dictionary<char, Node>();
    }

    private Dictionary<char, Node> children;

    public Node Add(char c)
    {
        if (children.ContainsKey(c))
        {
            Node n = children[c];
            n.Count++;
            return n;
        }
        else
        {
            Node n = new Node(c);
            children.Add(c, n);
            return n;
        }
    }

    public Node FindChar(char c)
    { 
        if (children.ContainsKey(c))
        {
            return children[c];
        }
        else
        {
            return null;
        }
    }

}

class Trie
{
    private Node root;
    public Trie()
    {
        root = new Node('*');
    }

    private void AddNodes(Node node, string value)
    {
        if (value != "")
        {
            char c = value[0];
            value = value.Remove(0, 1);
            AddNodes(node.Add(c), value);
        }
        else
        {
            node.Add('$');
        }
    }

    public void AddString(string value)
    {
        AddNodes(root, value);
    }

    private int CountNodes(Node node, string value)
    {
        if (node == null)
        {
            return 0;
        }
        else if (value != "")
        {
            char c = value[0];
            value = value.Remove(0, 1);
            return CountNodes(node.FindChar(c), value);
        }
        else
        {
            return node.Count;
        }
    }

    public int FindOccurences(string value)
    {
        return CountNodes(root, value);
    }
}
