using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarDOT
{
	public class AttributeStatement : Statement
	{
		public enum EObjectType
		{
			OT_Graph,
			OT_Node,
			OT_Edge
		};

		public static Dictionary<EObjectType, string> typeLabels = new Dictionary<EObjectType, string> {
			{EObjectType.OT_Edge, "edge"},
			{EObjectType.OT_Node, "node"},
			{EObjectType.OT_Graph, "graph"}
		};

		// the type of object for which to declare attributes
		public EObjectType objectType;

		// the list of attributes
		//public List<GraphAttribute> attributes = new List<GraphAttribute>();
		AttributeList attributes = new AttributeList();

		// add an attribute
		public void AddAttribute(GraphAttribute attribute)
		{
			attributes.Add(attribute);
		}

		// render to a string
		public string Render()
		{
			StringBuilder definition = new StringBuilder();

			// add type declaration
			definition.Append(typeLabels[objectType]);

			// render attribute list
			definition.Append(attributes.Render());

			return definition.ToString();
		}

	}
}
