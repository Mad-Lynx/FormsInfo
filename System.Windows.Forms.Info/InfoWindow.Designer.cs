namespace System.Windows.Forms.Info
{
	partial class InfoWindow
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
			this.outlineTreeView = new System.Windows.Forms.TreeView();
			this.splitter = new System.Windows.Forms.Splitter();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.infoGroupBox = new System.Windows.Forms.GroupBox();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.topLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.expandButton = new System.Windows.Forms.Button();
			this.collapseButton = new System.Windows.Forms.Button();
			this.mainPanel.SuspendLayout();
			this.infoGroupBox.SuspendLayout();
			this.topLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// outlineTreeView
			// 
			this.outlineTreeView.Dock = System.Windows.Forms.DockStyle.Left;
			this.outlineTreeView.HideSelection = false;
			this.outlineTreeView.Location = new System.Drawing.Point(16, 16);
			this.outlineTreeView.Name = "outlineTreeView";
			this.outlineTreeView.ShowLines = false;
			this.outlineTreeView.ShowNodeToolTips = true;
			this.outlineTreeView.Size = new System.Drawing.Size(278, 446);
			this.outlineTreeView.TabIndex = 0;
			this.outlineTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.outlineTreeView_AfterSelect);
			// 
			// splitter
			// 
			this.splitter.Location = new System.Drawing.Point(294, 16);
			this.splitter.Margin = new System.Windows.Forms.Padding(4);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(7, 446);
			this.splitter.TabIndex = 1;
			this.splitter.TabStop = false;
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.infoGroupBox);
			this.mainPanel.Controls.Add(this.topLayoutPanel);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(301, 16);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(550, 446);
			this.mainPanel.TabIndex = 2;
			// 
			// infoGroupBox
			// 
			this.infoGroupBox.Controls.Add(this.propertyGrid);
			this.infoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoGroupBox.Location = new System.Drawing.Point(0, 53);
			this.infoGroupBox.Name = "infoGroupBox";
			this.infoGroupBox.Size = new System.Drawing.Size(550, 393);
			this.infoGroupBox.TabIndex = 1;
			this.infoGroupBox.TabStop = false;
			this.infoGroupBox.Text = "Information";
			// 
			// propertyGrid
			// 
			this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid.Location = new System.Drawing.Point(3, 18);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(544, 372);
			this.propertyGrid.TabIndex = 0;
			// 
			// topLayoutPanel
			// 
			this.topLayoutPanel.ColumnCount = 5;
			this.topLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.topLayoutPanel.Controls.Add(this.expandButton, 0, 0);
			this.topLayoutPanel.Controls.Add(this.collapseButton, 1, 0);
			this.topLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.topLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.topLayoutPanel.Name = "topLayoutPanel";
			this.topLayoutPanel.Padding = new System.Windows.Forms.Padding(8);
			this.topLayoutPanel.RowCount = 1;
			this.topLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.topLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.topLayoutPanel.Size = new System.Drawing.Size(550, 53);
			this.topLayoutPanel.TabIndex = 0;
			// 
			// expandButton
			// 
			this.expandButton.Location = new System.Drawing.Point(12, 12);
			this.expandButton.Margin = new System.Windows.Forms.Padding(4);
			this.expandButton.Name = "expandButton";
			this.expandButton.Size = new System.Drawing.Size(30, 29);
			this.expandButton.TabIndex = 0;
			this.expandButton.Text = "+";
			this.expandButton.UseVisualStyleBackColor = true;
			this.expandButton.Click += new System.EventHandler(this.expandButton_Click);
			// 
			// collapseButton
			// 
			this.collapseButton.Location = new System.Drawing.Point(50, 12);
			this.collapseButton.Margin = new System.Windows.Forms.Padding(4);
			this.collapseButton.Name = "collapseButton";
			this.collapseButton.Size = new System.Drawing.Size(30, 29);
			this.collapseButton.TabIndex = 1;
			this.collapseButton.Text = "-";
			this.collapseButton.UseVisualStyleBackColor = true;
			this.collapseButton.Click += new System.EventHandler(this.collapseButton_Click);
			// 
			// InfoWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 478);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.splitter);
			this.Controls.Add(this.outlineTreeView);
			this.Name = "InfoWindow";
			this.Padding = new System.Windows.Forms.Padding(16);
			this.Text = "Properties";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InfoWindow_FormClosed);
			this.Load += new System.EventHandler(this.InfoWindow_Load);
			this.mainPanel.ResumeLayout(false);
			this.infoGroupBox.ResumeLayout(false);
			this.topLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private TreeView outlineTreeView;
		private Splitter splitter;
		private Panel mainPanel;
		private GroupBox infoGroupBox;
		private PropertyGrid propertyGrid;
		private TableLayoutPanel topLayoutPanel;
		private Button expandButton;
		private Button collapseButton;
	}
}