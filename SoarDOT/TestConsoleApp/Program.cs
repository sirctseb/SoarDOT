using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoarDOT;

namespace TestConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Test1();
		}
		public static void Test1() {
			Graph graph = new Graph(Graph.EGraphType.GT_Digraph, "hellograph");
			// add edge
			EdgeStatement edgeStatement = new EdgeStatement();
			edgeStatement.nodeID = new NodeStatement.NodeID("A");
			edgeStatement.rhs = new EdgeStatement.EdgeRHS();
			edgeStatement.rhs.nodeID = new NodeStatement.NodeID("B");
			graph.statements.Add(edgeStatement);

			// display result
			Console.Write(graph.Render());

			Console.ReadKey();
		}
	}
}
