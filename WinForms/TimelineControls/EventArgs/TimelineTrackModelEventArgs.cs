using AdamsLair.WinForms.TimelineControls.Models;

namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineTrackModelEventArgs : System.EventArgs
	{
		private ITimelineTrackModel model = null;
		public ITimelineTrackModel Model
		{
			get { return this.model; }
		}
		public TimelineTrackModelEventArgs(ITimelineTrackModel model)
		{
			this.model = model;
		}
	}
}
