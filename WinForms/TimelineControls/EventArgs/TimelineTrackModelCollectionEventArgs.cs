using System.Collections.Generic;
using System.Linq;
using AdamsLair.WinForms.TimelineControls.Models;

namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineTrackModelCollectionEventArgs : System.EventArgs
	{
		private ITimelineTrackModel[] tracks = null;

		public IEnumerable<ITimelineTrackModel> Tracks
		{
			get { return this.tracks; }
		}

		public TimelineTrackModelCollectionEventArgs(IEnumerable<ITimelineTrackModel> tracks)
		{
			this.tracks = tracks.ToArray();
		}
	}
}
