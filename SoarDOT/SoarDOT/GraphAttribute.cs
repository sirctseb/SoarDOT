using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarDOT
{
	public class GraphAttribute : IRenderable
	{
		public string ID;

		public GraphAttribute(string id)
		{
			ID = id;
		}

		public string Render()
		{
			return ID;
		}
	}

	public class IntAttribute : GraphAttribute
	{
		public int value;

		public IntAttribute(string id, int val)
			: base(id)
		{
			value = val;
		}

		public string Render()
		{
			return ID + "=" + value;
		}
	}

	public class DoubleAttribute : GraphAttribute
	{
		public double value;

		public DoubleAttribute(string id, double val)
			: base(id)
		{
			value = val;
		}

		public string Render()
		{
			return ID + "=" + value;
		}
	}

	public class StringAttribute : GraphAttribute
	{
		public string value;

		public StringAttribute(string id, string val)
			: base(id)
		{
			value = val;
		}

		public string Render()
		{
			return ID + "=" + value;
		}
	}
}
