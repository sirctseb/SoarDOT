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

		// the type of object for which to declare attributes
		public EObjectType objectType;

		// the list of attributes
		public List<GraphAttribute> attributes = new List<GraphAttribute>();

		// render to a string
		public string Render()
		{
			StringBuilder definition = new StringBuilder();

			// add opening square bracket
			definition.Append("[ ");

			// add attributes
			foreach (GraphAttribute attribute in attributes)
			{
				// TODO comma not on last attribute?
				definition.Append(attribute.Render()).Append(", ");
			}

			return definition.ToString();
		}

	}
}
