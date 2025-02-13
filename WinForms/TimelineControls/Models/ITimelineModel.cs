using System;
using System.Collections.Generic;
using AdamsLair.WinForms.TimelineControls.EventArgs;

namespace AdamsLair.WinForms.TimelineControls.Models
{
	public interface ITimelineModel
	{
		string UnitName { get; }
		string UnitDescription { get; }
		float UnitBaseScale { get; }
		IEnumerable<ITimelineTrackModel> Tracks { get; }

		event EventHandler<System.EventArgs> UnitChanged; 
		event EventHandler<TimelineTrackModelCollectionEventArgs> TracksAdded;
		event EventHandler<TimelineTrackModelCollectionEventArgs> TracksRemoved;
	}
}
