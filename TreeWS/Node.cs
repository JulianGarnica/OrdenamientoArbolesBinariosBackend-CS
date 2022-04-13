using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrdenamientoArbolesBinariosCS
{

	public class Node
	{
		public int key;
		public Node left;
		public Node right;
	}

	public static class Globals
	{
		public static Node newNode(int item)
		{
			Node temp = new Node();
			temp.key = item;
			temp.left = temp.right = null;
			return temp;
		}

		public static void inorder(Node root, int[] arr, ref int i)
		{
			if (root != null)
			{
				inorder(root.left, arr, ref i);
				arr[i++] = root.key;
				inorder(root.right, arr, ref i);
			}
		}

		public static Node insertintoBST(Node node, int key)
		{
			if (node == null)
			{
				return newNode(key);
			}
			if (key < node.key)
			{
				node.left = insertintoBST(node.left, key);
			}
			else if (key > node.key)
			{
				node.right = insertintoBST(node.right, key);
			}
			return node;
		}

		public static void treeSort(int[] arr, int n)
		{
			Node root = null;
			int i;
			root = insertintoBST(root, arr[0]);
			for (i = 1; i < n; i++)
			{
				root = insertintoBST(root, arr[i]);
			}
			i = 0;
			inorder(root, arr, ref i);
		}

	}

}
