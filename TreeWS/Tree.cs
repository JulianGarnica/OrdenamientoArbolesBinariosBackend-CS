using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace TreeWS
{

   
    public class Tree
    {
        public static Node arbol { get; set; }

        
        public Tree(string listaDesordenada)
        {
            
            CrearArbol(listaDesordenada);
            
        }

        public static Node newNode(int item)
        {
            Node temp = new Node();
            temp.value = item;
            temp.children[0] = temp.children[1] = null;
            
            return temp;
        }

        public static void inorder(Node root, int[] arr, ref int i)
        {
            if (root != null)
            {
                inorder(root.children[0], arr, ref i);
                arr[i++] = root.value;
                inorder(root.children[1], arr, ref i);
            }
        }

        public static Node insertintoBST(Node node, int key)
        {
            if (node == null)
            {
                return newNode(key);
            }
            if (key < node.value)
            {
                node.children[0] = insertintoBST(node.children[0], key);
            }
            else if (key > node.value)
            {
                node.children[1] = insertintoBST(node.children[1], key);
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

            arbol = root;
            i = 0;
            inorder(root, arr, ref i);
        }

        public static void CrearArbol(string numerosString)
        {
            int[] arr = Array.ConvertAll(numerosString.Split(','), s => int.Parse(s));
            int n = arr.Length;

            treeSort(arr, n); // Sort elements in ascending order
        }

        public string devolverArbol()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(arbol, options);
            return jsonString;
        }
    }
}