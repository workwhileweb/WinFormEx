using System;

namespace AdamsLair.WinForms.TimelineControls.Models
{
	public abstract class TimelineTrackModel : ITimelineTrackModel
	{
		private	string	trackName	= "A Timeline Track";

		public string TrackName
		{
			get { return this.trackName; }
			set
			{
				if (this.trackName != value)
				{
					this.trackName = value;
					if (this.TrackNameChanged != null)
						this.TrackNameChanged(this, System.EventArgs.Empty);
				}
			}
		}
		public abstract float EndTime { get; }
		public abstract float BeginTime { get; }

		public event EventHandler TrackNameChanged;
	}
}
