namespace System.Windows.Forms.Info
{
	internal interface IInfoWindow
	{
		void Show();

		void Close();

		void RebuidInfo(Control control);

		void ChangeControl(Control control);
	}
}