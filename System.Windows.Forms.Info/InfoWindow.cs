using System.ComponentModel;
using System.Windows.Forms.PropertyGridInternal;

namespace System.Windows.Forms.Info
{
	public partial class InfoWindow : Form, IInfoWindow
	{
		private readonly Form parentForm;

		public InfoWindow(Form parentForm)
		{
			InitializeComponent();

			this.parentForm = parentForm;
			Init();
		}

		private void InfoWindow_Load(object sender, EventArgs e)
		{
			FormInfo.InfoWindows.Add(parentForm, this);
		}

		private void InfoWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			FormInfo.InfoWindows.Remove(parentForm);

			Properties.Settings.Default.Save();
		}

		private void expandButton_Click(object sender, EventArgs e)
		{
			outlineTreeView.ExpandAll();
		}

		private void collapseButton_Click(object sender, EventArgs e)
		{
			outlineTreeView.CollapseAll();
		}

		private void outlineTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var controlInfo = e.Node?.Tag as ControlInfo;
			if (controlInfo != null)
				UpdateInfo(controlInfo);
		}

		private void filterBox_TextChanged(object sender, EventArgs e)
		{
			var ept = propertyGrid.SelectedTab as ExtendedPropertiesTab;
			if (ept != null)
			{
				ept.Filter = filterBox.Text;
				propertyGrid.Refresh();
			}
		}

		public void ChangeControl(Control control)
		{
			var node = outlineTreeView.Nodes.Find(n => ((ControlInfo)n.Tag).SourceControl == control);
			if (node != null)
				outlineTreeView.SelectedNode = node;
		}

		public void RebuidInfo(Control control)
		{
			outlineTreeView.SuspendLayout();
			outlineTreeView.Nodes.Clear();

			AddTreeViewNode(control, outlineTreeView.Nodes, parentForm);

			outlineTreeView.ExpandAll();
			outlineTreeView.ResumeLayout();
		}

		private void Init()
		{
			propertyGrid.PropertyTabs.RemoveTabType(typeof(PropertiesTab));
			propertyGrid.PropertyTabs.AddTabType(typeof(ExtendedPropertiesTab), PropertyTabScope.Static);

			Text = $"Properties: {parentForm.Name}";
			outlineTreeView.ImageList = ImageCollection.ImageList;

			parentForm.FormClosed += (s, e) => Close();
		}

		private void AddTreeViewNode(Control selectedControl, TreeNodeCollection treeNodeCollection, Control control)
		{
			var ci = new ControlInfo(control);

			var controlName = String.IsNullOrEmpty(ci.SourceControl.Name)
				? "(empty)"
				: ci.SourceControl.Name;
			var treeNode = new TreeNode(controlName)
				{
					ToolTipText = ci.Type.Name,
					Tag = ci,
					ImageKey = ci.ImageKey,
					SelectedImageKey = ci.ImageKey,
				};

			treeNodeCollection.Add(treeNode);

			if (control == selectedControl)
				outlineTreeView.SelectedNode = treeNode;

			foreach (Control children in control.Controls)
			{
				AddTreeViewNode(selectedControl, treeNode.Nodes, children);
			}
		}

		private void UpdateInfo(ControlInfo controlInfo)
		{
			propertyGrid.SelectedObject = controlInfo.SourceControl;
		}
	}
}
