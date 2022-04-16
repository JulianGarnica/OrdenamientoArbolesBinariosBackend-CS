using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeWS
{
	public class Node
	{
		public int value { get; set; }

		public Node[] _children = new Node[2];
			
		/*
		 * 0 = izq
		 * 1 = der
		 */
		public Node[] children
		{
			get { return _children; }
			set { _children = children; }
		} 
		// public Node left { get; set; }
		// public Node right { get; set; }
	}
}
