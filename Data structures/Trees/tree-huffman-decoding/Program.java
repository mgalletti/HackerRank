/*  
   class Node
      public  int frequency; // the frequency of this tree
       public  char data;
       public  Node left, right;
    
*/ 

static Node _root = null;
void decode(String S ,Node root)
{
    if (_root == null)
        _root = root;
    if (root != null)
    {
        if (S != "")
        {
            char c = S.charAt(0);
            if (c == '0' && root.left != null) {
                S = RemoveFirst(S);
                decode(S, root.left);
            }
            else if (c == '1' && root.right != null) {
                S = RemoveFirst(S);
                decode(S, root.right);
            }
            else {
                System.out.print(root.data);
                decode(S, _root);
            }
        }
        else
            System.out.print(root.data);
    }
}

String RemoveFirst(String S)
{
    if (S.length() > 1)
        S = S.substring(1);
    else
        S = "";
    return S;
}