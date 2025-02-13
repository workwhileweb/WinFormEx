using System;

namespace AdamsLair.WinForms.TimelineControls.Models
{
	public interface ITimelineTrackModel
	{
		string TrackName { get; }
		float EndTime { get; }
		float BeginTime { get; }

		event EventHandler TrackNameChanged;
	}
}
