using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarDOT
{
	public class AttributeList : IRenderable
	{
		// the actual list of attributes
		public List<GraphAttribute> attributes = new List<GraphAttribute>();

		// expose methods? or just let client use attributes field?
		public void Add(GraphAttribute attribute)
		{
			attributes.Add(attribute);
		}

		// render to string
		public string Render()
		{
			// return empty string if no attributes
			// this simplifies things for callers, who can render on an empty list
			if (attributes.Count == 0)
			{
				return "";
			}

			StringBuilder definition = new StringBuilder();

			// add opening square bracket
			definition.Append("[ ");

			// add attributes
			foreach (GraphAttribute attribute in attributes)
			{
				// TODO comma not on last attribute?
				definition.Append(attribute.Render()).Append(", ");
			}

			// add closing square bracket
			definition.Append(" ]");

			return definition.ToString();
		}
	}
}
