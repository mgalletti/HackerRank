
static Node _root = null;

static void decode(string S ,Node root)
{
	if (_root == null)
		_root = root;
	if (root != null)
	{
		if (S != "")
		{
			char c = S[0];
			if (c == '0' && root.left != null)
			{
				S = S.Remove(0, 1);
				decode(S, root.left);
			}
			else if (c == '1' && root.right != null)
			{
				S = S.Remove(0, 1);
				decode(S, root.right);
			}
			else
			{
				Console.Write(root.data);
				decode(S, _root);
			}
		}
		else
			Console.Write(root.data);
	}
}