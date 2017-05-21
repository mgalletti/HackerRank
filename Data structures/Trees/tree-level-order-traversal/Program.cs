/* 

    class Node 
       int data;
       Node left;
       Node right;
   */

void LevelOrder(Node root)
{
	Queue<Node> queue=new Queue<Node>(); 
	queue.Enqueue(root); 
	while(queue.Count != 0) 
	{ 
		Node tempNode=queue.Dequeue(); 
		Console.Write(tempNode.data.ToString() + " "); 
		if(tempNode.left != null) 
			queue.Enqueue(tempNode.left); 
		if(tempNode.right != null) 
			queue.Enqueue(tempNode.right); 
	}
}