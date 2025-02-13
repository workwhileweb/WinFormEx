using AdamsLair.WinForms.TimelineControls.Models;

namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineTrackModelChangedEventArgs : TimelineTrackModelEventArgs
	{
		private ITimelineTrackModel oldModel = null;
		public ITimelineTrackModel OldModel
		{
			get { return this.oldModel; }
		}
		public TimelineTrackModelChangedEventArgs(ITimelineTrackModel oldModel, ITimelineTrackModel model) : base(model)
		{
			this.oldModel = oldModel;
		}
	}
}
