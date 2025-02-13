using System;
using System.Collections.Generic;
using AdamsLair.WinForms.TimelineControls.EventArgs;

namespace AdamsLair.WinForms.TimelineControls.Models
{
	public interface ITimelineGraphTrackModel : ITimelineTrackModel
	{
		IEnumerable<ITimelineGraphModel> Graphs { get; }

		event EventHandler<TimelineGraphCollectionEventArgs> GraphsAdded;
		event EventHandler<TimelineGraphCollectionEventArgs> GraphsRemoved;
		event EventHandler<TimelineGraphRangeEventArgs> GraphChanged;
	}
}
