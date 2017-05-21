	/*
    class Node 
    	int data;
    	Node left;
    	Node right;
	*/
	static int height(Node root) {
      	// Write your code here.
        if (root == null)  
            return 0;
        int h = 0;
        if (root.right != null)
            h = height(root.right) + 1;
        else if (root.left != null)
            h = height(root.left) + 1;
       return h;
    }