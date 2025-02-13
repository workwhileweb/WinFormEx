namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineViewEventArgs : System.EventArgs
	{
		private TimelineView view = null;

		public TimelineView View
		{
			get { return this.view; }
		}

		public TimelineViewEventArgs(TimelineView view)
		{
			this.view = view;
		}
	}
}
