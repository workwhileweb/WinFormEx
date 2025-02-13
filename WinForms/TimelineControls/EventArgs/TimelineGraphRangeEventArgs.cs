using AdamsLair.WinForms.TimelineControls.Models;

namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineGraphRangeEventArgs : TimelineGraphEventArgs
	{
		private float beginTime;
		private float endTime;

		public float BeginTime
		{
			get { return this.beginTime; }
		}
		public float EndTime
		{
			get { return this.endTime; }
		}

		public TimelineGraphRangeEventArgs(ITimelineGraphModel graph, float beginTime, float endTime) : base(graph)
		{
			this.beginTime = beginTime;
			this.endTime = endTime;
		}
	}
}
