using System;
using System.Windows.Forms;

namespace FormsInfoExample
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			new Form2().Show();
		}
	}
}
