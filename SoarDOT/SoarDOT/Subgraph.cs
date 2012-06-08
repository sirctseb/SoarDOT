using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarDOT
{
	// not really a Graph because it doesn't have (use) an EGraphType
	public class Subgraph : Graph
	{
		// arbitrary type because it's not used anyway
		public Subgraph() : base(EGraphType.GT_Digraph)
		{
		}
		public Subgraph(string id)
			: base(EGraphType.GT_Digraph, id)
		{
		}

		public override string Render()
		{
			StringBuilder definition = new StringBuilder();

			definition.Append("subgraph ");

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
