namespace AdamsLair.WinForms.ItemViews.EventArgs
{
	public class TiledViewEventArgs : System.EventArgs
	{
		private TiledView view;
		public TiledView View
		{
			get { return this.view; }
		}
		public TiledViewEventArgs(TiledView view)
		{
			this.view = view;
		}
	}
}
