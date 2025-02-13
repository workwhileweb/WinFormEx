using System.Drawing;

namespace AdamsLair.WinForms.TimelineControls.EventArgs
{
	public class TimelineViewPaintEventArgs : TimelineViewEventArgs
	{
		private Graphics	graphics	= null;
		private	Rectangle	targetRect	= Rectangle.Empty;

		public Graphics Graphics
		{
			get { return this.graphics; }
		}
		public TimelineViewControlRenderer Renderer
		{
			get { return this.View.Renderer; }
		}
		public Rectangle TargetRect
		{
			get { return this.targetRect; }
		}

		public TimelineViewPaintEventArgs(TimelineView view, Graphics graphics, Rectangle targetRect) : base(view)
		{
			this.graphics = graphics;
			this.targetRect = targetRect;
		}
	}
}
