using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarDOT
{
	// a class designed to match a graph the DOT language as closely as possible
	public class Graph : IRenderable
	{
		// the type of graph
		public enum EGraphType
		{
			GT_Graph,
			GT_Digraph
		};

		public EGraphType graphType = EGraphType.GT_Digraph;

		// the graph ID
		public string ID;

		// the statements contained in the graph definition
		public List<Statement> statements = new List<Statement>();

		// add a statement to the list
		void AddStatement(Statement statement)
		{
			statements.Add(statement);
		}

		// render the definition to a DOT language string
		public string Render()
		{
			StringBuilder definition = new StringBuilder();
			// add the type declaration
			definition.Append(graphType == EGraphType.GT_Digraph ? "digraph " : "graph ");
			// add the ID if it exists
			if (ID != null)
			{
				definition.Append(ID + " ");
			}

			// add opening brace
			definition.AppendLine("{");

			// add statements
			foreach (Statement statement in statements)
			{
				definition.AppendLine(statement.Render());
			}

			// add closing brace
			definition.AppendLine("}");

			return definition.ToString();
		}
	}
}
