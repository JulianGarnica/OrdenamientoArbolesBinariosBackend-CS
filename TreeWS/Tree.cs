using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TreeWS.Node;

namespace TreeWS;

public class Tree
{
    public Tree(string listaDesordenada)
    {
        CrearArbol(listaDesordenada);
    }
    
    public static void CrearArbol(string numerosString)
    {
        //List<string> stringArr = Array.ConvertAll(numerosString.Split(','), s => int.Parse(s));
        int[] arr = Array.ConvertAll(numerosString.Split(','), s => int.Parse(s));
        int n = arr.Length;
        Console.Write("Input array: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i]);
            Console.Write(" ");
        }
        Console.Write("\n");

        Globals.treeSort(arr, n); // Sort elements in ascending order
        Console.Write("Output array: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i]);
            Console.Write(" ");
        }
        Console.Write("\n");
    }
}