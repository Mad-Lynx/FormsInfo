using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsInfoExample
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			// Register new image for MyNumericUpDown
			System.Windows.Forms.Info.FormInfo.ImageCollection.RegisterType<MyNumericUpDown>(Image.FromFile("Img/MyControl.png"));

			// Register SomeUserControl with same image as Panel
			System.Windows.Forms.Info.FormInfo.ImageCollection.RegisterType<SomeUserControl>("Panel");

			// Change image for Forms
			System.Windows.Forms.Info.FormInfo.ImageCollection.RegisterImage("Form", Image.FromFile("Img/AllForms.png"));

			System.Windows.Forms.Info.FormInfo.RegisterMessageFilter();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
