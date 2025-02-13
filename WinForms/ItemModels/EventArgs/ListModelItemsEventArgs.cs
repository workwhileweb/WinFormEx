﻿using System;

namespace AdamsLair.WinForms.ItemModels.EventArgs
{
	public class ListModelItemsEventArgs : System.EventArgs
	{
		private int index;
		private int count;

		public int Index
		{
			get { return this.index; }
		}
		public int Count
		{
			get { return this.count; }
		}

		public ListModelItemsEventArgs(int index, int count)
		{
			if (index < 0) throw new ArgumentException("Index needs to be > 0.");
			if (count < 1) throw new ArgumentException("Count needs to be >= 1.");
			this.index = index;
			this.count = count;
		}
	}
}
