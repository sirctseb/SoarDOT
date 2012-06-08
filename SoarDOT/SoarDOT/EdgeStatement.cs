using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarDOT
{
	public class EdgeStatement : Statement
	{
		public class IDMissingException : Exception {
			public override string Message {
				get { return "ID for node or subgraph missing"; }
			}
		}

		// the right hand side of a statement
		public class EdgeRHS : IRenderable
		{
			public NodeStatement.NodeID nodeID = null;
			public string subgraphID = null;

			public EdgeRHS next = null;
			
			public string Render()
			{
				StringBuilder definition = new StringBuilder();

				// add arrow
				definition.Append("->");

				// add either nodeID or subgraphID
				if (nodeID != null)
				{
					definition.Append(nodeID.Render());
				}
				else if (subgraphID != null)
				{
					definition.Append(subgraphID);
				}
				else
				{
					throw new IDMissingException();
				}

				// add further RHS if the exist
				if (next != null)
				{
					definition.Append(next.Render());
				}

				return definition.ToString();
			}
		}

		// the node id if it exists
		public NodeStatement.NodeID nodeID = null;
		// the name of a subgraph if it exists
		public string subgraphID = null;

		// edge RHS
		public EdgeRHS rhs = null;
		// TODO callers have to set these fields manually until we provide a constructor

		public AttributeList attributes = new AttributeList();

		public override string Render()
		{
			StringBuilder definition = new StringBuilder();

			// add either nodeID or subgraphID
			if (nodeID != null)
			{
				definition.Append(nodeID.Render());
			}
			else if (subgraphID != null)
			{
				definition.Append(subgraphID);
			}
			else
			{
				throw new IDMissingException();
			}

			// render RHS
			definition.Append(rhs.Render());

			// add attribute list (may be empty)
			definition.Append(attributes.Render());

			return definition.ToString();
		}
	}
}
