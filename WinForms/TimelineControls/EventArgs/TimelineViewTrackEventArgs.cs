namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineViewTrackEventArgs : TimelineViewEventArgs
	{
		private TimelineViewTrack track = null;

		public TimelineViewTrack Track
		{
			get { return this.track; }
		}

		public TimelineViewTrackEventArgs(TimelineViewTrack track) : base(track.ParentView)
		{
			this.track = track;
		}
	}
}
