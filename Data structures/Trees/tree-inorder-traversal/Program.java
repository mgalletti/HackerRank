/* you only have to complete the function given below.  
Node is defined as  

class Node {
    int data;
    Node left;
    Node right;
}

*/

void inOrder(Node root) {
    if (root != null)
    {
        inOrder(root.left);
        System.out.print(Integer.toString(root.data) + " ");
        inOrder(root.right);
    }
}