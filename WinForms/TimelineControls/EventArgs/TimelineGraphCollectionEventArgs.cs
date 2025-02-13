using System.Collections.Generic;
using System.Linq;
using AdamsLair.WinForms.TimelineControls.Models;

namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineGraphCollectionEventArgs : System.EventArgs
	{
		private ITimelineGraphModel[] graphs;
		public IEnumerable<ITimelineGraphModel> Graphs
		{
			get { return this.graphs; }
		}
		public TimelineGraphCollectionEventArgs(IEnumerable<ITimelineGraphModel> graphs)
		{
			this.graphs = graphs.ToArray();
		}
	}
}
