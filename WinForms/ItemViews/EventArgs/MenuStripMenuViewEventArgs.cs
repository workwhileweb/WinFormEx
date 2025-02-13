namespace AdamsLair.WinForms.ItemViews.EventArgs
{
	public class MenuStripMenuViewEventArgs : System.EventArgs
	{
		private MenuStripMenuView	view	= null;

		public MenuStripMenuView View
		{
			get { return this.view; }
		}

		public MenuStripMenuViewEventArgs(MenuStripMenuView view)
		{
			this.view = view;
		}
	}
}
