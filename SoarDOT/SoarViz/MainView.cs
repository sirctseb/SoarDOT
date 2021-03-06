﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoarViz
{
	public partial class MainView : Form
	{
		private static sml.Kernel kernel = null;
		public static sml.Agent agent = null;
		List<string> agentNames = new List<string>();

		public MainView()
		{
			InitializeComponent();
		}

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			string x = System.IO.Directory.GetCurrentDirectory();
			// create connection to Soar
			kernel = sml.Kernel.CreateRemoteConnection();

			// report failed connection
			if (kernel.HadError())
			{
				TextView.Text = "Error connecting to Soar";
			}

			// read list of agents
			agentNames.Clear();
			for (int i = 0; i < kernel.GetNumberAgents(); i++)
			{
				agentNames.Add(kernel.GetAgentByIndex(i).GetAgentName());
				// TODO this should be able to read from agentNames but it's not
			}
			// set drop-down data source
			AgentList.DataSource = agentNames;
			// select first agent if it exists
			if (kernel.GetNumberAgents() > 0)
			{
				// TODO I don't we have to set agent here because SelectedIndexChanged will fire
				//agent = kernel.GetAgentByIndex(0);
				AgentList.SelectedIndex = 0;
			}

			sml.ConnectionInfo ci = kernel.GetConnectionInfo(0);
		}

		private void AgentList_SelectedIndexChanged(object sender, EventArgs e)
		{
			agent = kernel.GetAgentByIndex(AgentList.SelectedIndex);
			if (agent == null)
			{
				TextView.Text = "Error selecting agent";
				return;
			}

			// show agent info
			TextView.Text = agent.GetCurrentPhase().ToString();
		}

		private void ParseButton_Click(object sender, EventArgs e)
		{
			// get text from soar
			string output = kernel.ExecuteCommandLine(@"print <s> --depth 4", agent.GetAgentName());
			TextView.Text = output;
			// parse into wme structures
			IEnumerable<WMParse.WME> wmes = WMParse.ParseWM(output);
			// construct graph statements from those
			SoarDOT.Graph graph = new SoarDOT.Graph(SoarDOT.Graph.EGraphType.GT_Digraph);
			foreach (WMParse.WME wme in wmes)
			{
				foreach(SoarDOT.Statement statement in wme.GetStatement()) {
					graph.statements.Add(statement);
				}
			}
			// render graph to text
			string dot = graph.Render();
			// put in text box
			TextView.Text = dot;
		}
	}
}
