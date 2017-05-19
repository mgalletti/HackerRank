/* Hidden stub code will pass a root argument to the function below. Complete the function to solve the challenge. Hint: you may want to write one or more helper functions.  

The Node class is defined as follows:
    class Node {
        int data;
        Node left;
        Node right;
     }
*/
    boolean checkBST(Node root) {
        return checkNodes(root, Integer.MIN_VALUE, Integer.MAX_VALUE);
    }


    boolean checkNodes(Node current, int min, int max) {
        if (current == null)
            return true;
        if (current.data > min && current.data < max)
            return checkNodes(current.left, min, current.data) && checkNodes(current.right, current.data, max);
        else
            return false;
    }