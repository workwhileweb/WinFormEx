using System.Drawing;

namespace AdamsLair.WinForms.ItemViews.EventArgs
{
	public class TiledViewItemAppearanceEventArgs : TiledViewItemEventArgs
	{
		private string text = null;
		private Image image = null;

		public string DisplayedText
		{
			get { return this.text; }
			set { this.text = value; }
		}
		public Image DisplayedImage
		{
			get { return this.image; }
			set { this.image = value; }
		}

		internal TiledViewItemAppearanceEventArgs(TiledView view) : this(view, -1, null) {}
		public TiledViewItemAppearanceEventArgs(TiledView view, int modelIndex, object item) : base(view, modelIndex, item) {}
	}
}
