using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarDOT
{
	public class NodeStatement : Statement
	{
		// node id in the language is complicated enough to have its own class
		public class NodeID : IRenderable
		{
			enum ECompassPt
			{
				N, NE, E, SE, S, SW, W, NW, C, _, None
			}

			public static Dictionary<ECompassPt, string> compassPtNames = new Dictionary<ECompassPt, string> {
				{ECompassPt.N, "n"},
				{ECompassPt.NE, "ne"},
				{ECompassPt.E, "e"},
				{ECompassPt.SE, "se"},
				{ECompassPt.S, "s"},
				{ECompassPt.SW, "sw"},
				{ECompassPt.W, "w"},
				{ECompassPt.NW, "nw"},
				{ECompassPt.C, "c"},
				{ECompassPt._, "_"}
			};

			#region constructors
			public NodeID(string id)
			{
				ID = id;
			}
			public NodeID(string id, string port_ID)
			{
				ID = id;
				this.port_ID = port_ID;
			}
			public NodeID(string id, ECompassPt compass_pt)
			{
				ID = id;
				port_compass_pt = compass_pt;
			}
			public NodeID(string id, string port_ID, ECompassPt compass_pt)
			{
				ID = id;
				this.port_ID = port_ID;
				port_compass_pt = compass_pt;
			}
			#endregion

			// id of the node
			public string ID;

			// i don't really know what these do
			public string port_ID = null;
			public ECompassPt port_compass_pt = ECompassPt.None;

			// render
			public string Render()
			{
				string definition = ID;
				if (port_ID != null)
				{
					definition += ":" + port_ID;
				}
				if (port_compass_pt != ECompassPt.None)
				{
					definition += ":" + compassPtNames[port_compass_pt];
				}
				return definition;
			}
		}

		public NodeID nodeID;
		
		// attributes
		AttributeList attributes = new AttributeList();

		public NodeStatement(string id)
		{
			nodeID = new NodeID(id);
		}
		public NodeStatement(NodeID nodeID)
		{
			this.nodeID = nodeID;
		}

		// render
		public string Render()
		{
			StringBuilder definition = new StringBuilder();

			// render ID
			definition.Append(nodeID.Render());

			// render attribute list
			definition.Append(attributes.Render());

			return definition.ToString();
		}
	}
}
