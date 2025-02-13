using AdamsLair.WinForms.TimelineControls.Models;

namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineGraphChangedEventArgs : TimelineGraphEventArgs
	{
		private ITimelineGraphModel oldGraph = null;
		public ITimelineGraphModel OldGraph
		{
			get { return this.oldGraph; }
		}
		public TimelineGraphChangedEventArgs(ITimelineGraphModel oldGraph, ITimelineGraphModel graph) : base(graph)
		{
			this.oldGraph = oldGraph;
		}
	}
}
