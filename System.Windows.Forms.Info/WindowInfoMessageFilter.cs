namespace System.Windows.Forms.Info
{
	internal class WindowInfoMessageFilter : IMessageFilter
	{
		public const int WM_LBUTTONDOWN = 0x0201;
		public const int WM_RBUTTONDOWN = 0x0204;

		public bool PreFilterMessage(ref Message m)
		{
			Control sourceControl;

			// WM_CONTEXTMENU and WM_SETFOCUS is not capture :(
			switch (m.Msg)
			{
				case WM_LBUTTONDOWN:
					sourceControl = Control.FromHandle(m.HWnd);
					if (sourceControl != null)
						FormInfo.ChangeControl(sourceControl);
					break;

				case WM_RBUTTONDOWN:
					sourceControl = Control.FromHandle(m.HWnd);

					if (((MouseParam)m.WParam).HasFlag(MouseParam.Shift | MouseParam.Control) && sourceControl != null)
						FormInfo.Show(sourceControl);
					break;
			}

			return false;
		}

		[Flags]
		private enum MouseParam
		{
			RButton = 0x0002,
			Shift = 0x0004,
			Control = 0x0008,
		}
	}
}
