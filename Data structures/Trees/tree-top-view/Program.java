/*
   class Node 
       int data;
       Node left;
       Node right;
*/
void top_view(Node root)
{
    printLeft(root.left);
    printData(root);
    printRight(root.right);
}

void printData(Node root)
{
    System.out.print(Integer.toString(root.data)+" ");
}

void printLeft(Node root)
{
    if (root != null)
    {
        if (root.left != null) {
            printLeft(root.left);
        }
        printData(root);
    }
}

void printRight(Node root)
{    
    if (root != null)
    {
        printData(root);
        if (root.right != null) {
            printRight(root.right);
        }
    }
}