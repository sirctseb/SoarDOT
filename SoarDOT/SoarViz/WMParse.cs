using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;
using SoarDOT;

namespace SoarViz
{
	public class WMParse
	{
		public class WME
		{
			private static int newID = 0;
			public string ID;
			public string attribute;
			public string value;

			public bool IsIdentifier()
			{
				// if value matches [A-z][0-9]+ we assume value refers to an object
				return Regex.Match(value, @"[A-z][0-9]+").Length == value.Length;
			}
			// TODO will need to do other preferences
			public bool IsOperatorAcceptable()
			{
				return System.Text.RegularExpressions.Regex.IsMatch(value, @"O[0-9]+ \+");
			}

			// returns a list of statements because we may need to declare node attribute statments
			// or other things to describe the WME
			public IEnumerable<Statement> GetStatement()
			{
				List<Statement> statements = new List<Statement>();
				if (IsIdentifier())
				{
					// add an edge statement
					EdgeStatement statement = EdgeStatement.EdgeBetweenNodes(ID, value);
					statement.attributes.Add(new StringAttribute("label", attribute.Replace("-", "_")));
					statements.Add(statement);
				}
				else
				{
					// get a new id for the value
					string newID = getNewID();
					// make edge statement
					EdgeStatement statement = EdgeStatement.EdgeBetweenNodes(ID, newID);
					statement.attributes.Add(new StringAttribute("label", attribute.Replace("-", "_")));
					statements.Add(statement);
					// add a node attribute statement to label the child
					NodeStatement nodeStatement = new NodeStatement(newID);
					nodeStatement.attributes.Add(new StringAttribute("label", value.Replace("-", "_")));
					statements.Add(nodeStatement);
				}
				return statements;
			}
			// create a unique id for nodes
			private string getNewID()
			{
				return "XX" + newID++;
			}
		}

		// match things that look like (ID ^attr val ^attr2 val2...)
		static string wmedeclaration = @"(?:(?:\s|\n)*\(" +				// open paren
											@"(?<ID>[A-z][0-9]+)" +	// ID
											@"(?:\s*" +				// space between ID or previous child and this child
												@"\^(?<attr>(?:\w|-)+)" +	// attribute name
												@"\s*(?<val>[^\s]+(?:\s\+)?)" +	// value
											@")+" +					// end child group, match multiple
										@"\))";					// close paren
		static Regex wmeprint = new Regex(wmedeclaration);

		public static IEnumerable<WME> ParseWM(string trace)
		{
			List<WME> wmes = new List<WME>();

			// parse trace
			MatchCollection matches = wmeprint.Matches(trace);
			foreach (Match match in matches)
			{
				string id = match.Groups["ID"].Value;
				int i = 0;
				foreach (Capture capture in match.Groups["attr"].Captures)
				{
					string attr = capture.Value;
					string val = match.Groups["val"].Captures[i].Value;
					wmes.Add(new WME { ID = id, attribute = attr, value = val });
					i++;
				}
			}

			return wmes;
		}
	}
}
