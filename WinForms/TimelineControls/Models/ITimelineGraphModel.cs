using System;
using AdamsLair.WinForms.TimelineControls.EventArgs;

namespace AdamsLair.WinForms.TimelineControls.Models
{
	public interface ITimelineGraphModel
	{
		float EndTime { get; }
		float BeginTime { get; }

		float GetValueAtX(float units);
		float GetMaxValueInRange(float begin, float end);
		float GetMinValueInRange(float begin, float end);

		event EventHandler<TimelineGraphRangeEventArgs> GraphChanged;
	}
}
