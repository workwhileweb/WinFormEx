using System.Collections.Generic;
using System.Linq;

namespace AdamsLair.WinForms.ItemModels.EventArgs
{
	public class MenuModelItemsEventArgs : System.EventArgs
	{
		private IMenuModelItem[]	items			= null;
		private bool				sortingAffected	= false;

		public IEnumerable<IMenuModelItem> Items
		{
			get { return this.items; }
		}
		public bool IsSortingAffected
		{
			get { return this.sortingAffected; }
		}

		public MenuModelItemsEventArgs(IEnumerable<IMenuModelItem> items, bool affectsSorting = false)
		{
			if (items == null) items = Enumerable.Empty<IMenuModelItem>();
			this.items = items.Distinct().ToArray();
			this.sortingAffected = affectsSorting;
		}
	}
}
