namespace SoarViz
{
	partial class MainView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TextView = new System.Windows.Forms.TextBox();
			this.ConnectButton = new System.Windows.Forms.Button();
			this.AgentList = new System.Windows.Forms.ComboBox();
			this.ParseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TextView
			// 
			this.TextView.Location = new System.Drawing.Point(9, 38);
			this.TextView.Multiline = true;
			this.TextView.Name = "TextView";
			this.TextView.Size = new System.Drawing.Size(503, 378);
			this.TextView.TabIndex = 0;
			// 
			// ConnectButton
			// 
			this.ConnectButton.Location = new System.Drawing.Point(12, 9);
			this.ConnectButton.Name = "ConnectButton";
			this.ConnectButton.Size = new System.Drawing.Size(93, 23);
			this.ConnectButton.TabIndex = 1;
			this.ConnectButton.Text = "Connect to Soar";
			this.ConnectButton.UseVisualStyleBackColor = true;
			this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
			// 
			// AgentList
			// 
			this.AgentList.FormattingEnabled = true;
			this.AgentList.Location = new System.Drawing.Point(111, 9);
			this.AgentList.Name = "AgentList";
			this.AgentList.Size = new System.Drawing.Size(121, 21);
			this.AgentList.TabIndex = 2;
			this.AgentList.SelectedIndexChanged += new System.EventHandler(this.AgentList_SelectedIndexChanged);
			// 
			// ParseButton
			// 
			this.ParseButton.Location = new System.Drawing.Point(433, 7);
			this.ParseButton.Name = "ParseButton";
			this.ParseButton.Size = new System.Drawing.Size(75, 23);
			this.ParseButton.TabIndex = 3;
			this.ParseButton.Text = "Parse";
			this.ParseButton.UseVisualStyleBackColor = true;
			this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(520, 425);
			this.Controls.Add(this.ParseButton);
			this.Controls.Add(this.AgentList);
			this.Controls.Add(this.ConnectButton);
			this.Controls.Add(this.TextView);
			this.Name = "MainView";
			this.Text = "Main View";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextView;
		private System.Windows.Forms.Button ConnectButton;
		private System.Windows.Forms.ComboBox AgentList;
		private System.Windows.Forms.Button ParseButton;
	}
}

