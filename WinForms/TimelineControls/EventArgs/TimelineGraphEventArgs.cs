using AdamsLair.WinForms.TimelineControls.Models;

namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineGraphEventArgs : System.EventArgs
	{
		private ITimelineGraphModel graph;
		public ITimelineGraphModel Graph
		{
			get { return this.graph; }
		}
		public TimelineGraphEventArgs(ITimelineGraphModel graph)
		{
			this.graph = graph;
		}
	}
}
