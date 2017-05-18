using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    
    public class MyQueue {
        private Stack<int> oldTop;
        private Stack<int> newTop;

        public MyQueue() {
            oldTop = new Stack<int>();
            newTop = new Stack<int>();
        }

        private void ReverseStacks(Stack<int> source, Stack<int> target) {
            while (source.Count > 0) {
                target.Push(source.Pop());
            }
        }

        public void Enqueue(int val) {
            newTop.Push(val);
        }

        private void FeedOldTops() {
            if (oldTop.Count == 0)
                ReverseStacks(newTop, oldTop);
        }

        public void Dequeue() {
            FeedOldTops();
            oldTop.Pop();
        }

        public int Peek() {
            FeedOldTops();
            return oldTop.Peek();
        }
    }
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = Convert.ToInt32(Console.ReadLine());
        MyQueue queue = new MyQueue();
        for (int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            switch (input[0])
            {
                case 1: // enqueue input[1] element
                    queue.Enqueue(input[1]);
                break;
                case 2: // dequeue
                    queue.Dequeue();
                break;
                case 3: // print front element
                    Console.WriteLine(queue.Peek().ToString());
                break;
            }
        }
    }
}