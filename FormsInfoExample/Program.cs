using System;
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
			Application.AddMessageFilter(System.Windows.Forms.Info.FormInfo.MessageFilter);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
