﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using AdamsLair.WinForms.ItemModels;
using AdamsLair.WinForms.ItemModels.EventArgs;
using AdamsLair.WinForms.ItemViews.EventArgs;

namespace AdamsLair.WinForms.ItemViews
{
	public class MenuStripMenuView
	{
		private	ToolStripItemCollection						target				= null;
		private	IMenuModel									model				= null;
		private	Dictionary<IMenuModelItem,ToolStripItem>	viewItems			= new Dictionary<IMenuModelItem,ToolStripItem>();
		private	HashSet<ToolStripItem>						visibleSeparators	= new HashSet<ToolStripItem>();
		private	Comparison<IMenuModelItem>					comparison			= DefaultItemComparison;

		public event EventHandler<MenuStripMenuViewItemEventArgs> ItemInserted = null;
		public event EventHandler<MenuStripMenuViewItemEventArgs> ItemRemoved = null;

		public IMenuModel Model
		{
			get { return this.model; }
			set
			{
				if (this.model != value)
				{
					if (this.model != null)
					{
						this.model.ItemsAdded -= this.model_ItemsAdded;
						this.model.ItemsRemoved -= this.model_ItemsRemoved;
						this.model.ItemsChanged -= this.model_ItemsChanged;
						this.model_ItemsRemoved(this.model, new MenuModelItemsEventArgs(this.model.Items));
					}

					this.model = value;

					if (this.model != null)
					{
						this.model_ItemsAdded(this.model, new MenuModelItemsEventArgs(this.model.Items));
						this.model.ItemsAdded += this.model_ItemsAdded;
						this.model.ItemsRemoved += this.model_ItemsRemoved;
						this.model.ItemsChanged += this.model_ItemsChanged;
					}
				}
			}
		}
		public Comparison<IMenuModelItem> ItemSortComparison
		{
			get { return this.comparison; }
			set
			{
				value = value ?? DefaultItemComparison;
				if (this.comparison != value)
				{
					this.comparison = value;
					this.SortItems();
				}
			}
		}


		public MenuStripMenuView(ToolStripItemCollection target)
		{
			if (target == null) throw new ArgumentNullException("target");
			this.target = target;
		}
		
		public ToolStripItem GetViewItem(IMenuModelItem modelItem)
		{
			ToolStripItem viewItem;
			if (this.viewItems.TryGetValue(modelItem, out viewItem))
			{
				return viewItem;
			}
			else
			{
				return null;
			}
		}
		public IMenuModelItem GetModelItem(ToolStripItem viewItem)
		{
			return this.viewItems.Where(p => p.Value == viewItem).Select(p => p.Key).FirstOrDefault();
		}

		public void SortItems()
		{
			if (this.model == null) return;
			if (this.model.Items == null) return;

			IMenuModelItem[] items = this.model.Items.ToArray();
			this.model_ItemsRemoved(this.model, new MenuModelItemsEventArgs(items));
			this.model_ItemsAdded(this.model, new MenuModelItemsEventArgs(items));
		}

		protected virtual ToolStripItem CreateViewItem(IMenuModelItem modelItem)
		{
			switch (modelItem.TypeHint)
			{
				default:
				case MenuItemTypeHint.Item:			return new ToolStripMenuItem();
				case MenuItemTypeHint.Separator:	return new ToolStripSeparator();
			}
		}
		protected virtual void UpdateItemProperties(IMenuModelItem modelItem, ToolStripItem viewItem)
		{
			bool wasVisible = viewItem.Available;

			viewItem.Tag		= modelItem.Tag;
			viewItem.Image		= modelItem.Icon;
			viewItem.Name		= modelItem.Name;
			viewItem.Text		= modelItem.Name;
			viewItem.Available	= modelItem.Visible && (modelItem.TypeHint != MenuItemTypeHint.Separator || this.visibleSeparators.Contains(viewItem));
			viewItem.Enabled	= modelItem.Enabled;

			ToolStripMenuItem viewMenuItem = viewItem as ToolStripMenuItem;
			if (viewMenuItem != null)
			{
				viewMenuItem.ShortcutKeys	= modelItem.ShortcutKeys;
				viewMenuItem.CheckOnClick	= modelItem.Checkable;
				viewMenuItem.Checked		= modelItem.Checked;
			}

			if (wasVisible != viewItem.Available)
				this.UpdateSeparatorVisibility(this.GetTargetViewItemCollection(modelItem));
		}
		
		private void UpdateSeparatorVisibility(ToolStripItemCollection parentCollection)
		{
			this.visibleSeparators.Clear();
			bool separatorStreak = false;
			bool isFirstVisibleItem = true;
			int lastSeparatorIndex = -1;
			for (int i = 0; i < parentCollection.Count; i++)
			{
				ToolStripItem viewItem = parentCollection[i];
				IMenuModelItem modelItem = this.GetModelItem(viewItem);
				if (!modelItem.Visible) continue;

				bool isSeparator = modelItem.TypeHint == MenuItemTypeHint.Separator;

				if (isSeparator)
				{
					viewItem.Available = false;
					separatorStreak = true;
					lastSeparatorIndex = i;
				}
				else if (separatorStreak && !isFirstVisibleItem)
				{
					ToolStripItem lastViewItem = parentCollection[lastSeparatorIndex];
					IMenuModelItem lastModelItem = this.GetModelItem(lastViewItem);
					lastViewItem.Available = lastModelItem.Visible;
					this.visibleSeparators.Add(lastViewItem);
				}

				if (!isSeparator)
				{
					isFirstVisibleItem = false;
					separatorStreak = false;
				}
			}
		}
		private void InsertViewItem(ToolStripItemCollection parentCollection, ToolStripItem viewItem, IMenuModelItem modelItem)
		{
			ToolStripMenuItem viewMenuItem = viewItem as ToolStripMenuItem;

			// Determine where to insert the item
			int insertIndex = parentCollection.Count;
			for (int i = 0; i < parentCollection.Count; i++)
			{
				IMenuModelItem item = this.GetModelItem(parentCollection[i]);
				if (comparison(item, modelItem) > 0)
				{
					insertIndex = i;
					break;
				}
			}

			// Insert the item
			if (insertIndex < parentCollection.Count)
				parentCollection.Insert(insertIndex, viewItem);
			else
				parentCollection.Add(viewItem);

			this.viewItems.Add(modelItem, viewItem);
			viewItem.Click += this.viewMenuItem_Click;
			if (viewMenuItem != null)
			{
				viewMenuItem.CheckedChanged += this.viewMenuItem_CheckedChanged;
				viewMenuItem.DropDown.Closing += this.viewMenuItem_DropDown_Closing;
			}

			this.UpdateSeparatorVisibility(parentCollection);
			this.RaiseItemInserted(modelItem, viewItem);
		}
		private void RemoveViewItem(ToolStripItemCollection parentCollection, ToolStripItem viewItem, IMenuModelItem modelItem)
		{
			ToolStripMenuItem viewMenuItem = viewItem as ToolStripMenuItem;

			parentCollection.Remove(viewItem);
			this.viewItems.Remove(modelItem);
			viewItem.Click -= this.viewMenuItem_Click;
			if (viewMenuItem != null)
			{
				viewMenuItem.CheckedChanged -= this.viewMenuItem_CheckedChanged;
				viewMenuItem.DropDown.Closing -= this.viewMenuItem_DropDown_Closing;
			}

			this.UpdateSeparatorVisibility(parentCollection);
			this.RaiseItemRemoved(modelItem, viewItem);
		}
		private void CreateViewItems(ToolStripItemCollection parentCollection, IEnumerable<IMenuModelItem> modelItems)
		{
			foreach (IMenuModelItem modelItem in modelItems)
			{
				ToolStripItem viewItem = this.CreateViewItem(modelItem);
				this.UpdateItemProperties(modelItem, viewItem);

				this.InsertViewItem(parentCollection ?? this.GetTargetViewItemCollection(modelItem), viewItem, modelItem);

				ToolStripMenuItem viewMenuItem = viewItem as ToolStripMenuItem;
				if (viewMenuItem != null)
				{
					this.CreateViewItems(viewMenuItem.DropDownItems, modelItem.Items);
				}
			}
		}
		private void DestroyViewItems(ToolStripItemCollection parentCollection, IEnumerable<IMenuModelItem> modelItems)
		{
			foreach (IMenuModelItem modelItem in modelItems)
			{
				ToolStripItem viewItem;
				if (!this.viewItems.TryGetValue(modelItem, out viewItem)) continue;

				this.RemoveViewItem(parentCollection ?? this.GetTargetViewItemCollection(modelItem), viewItem, modelItem);

				ToolStripMenuItem viewMenuItem = viewItem as ToolStripMenuItem;
				if (viewMenuItem != null)
				{
					this.DestroyViewItems(viewMenuItem.DropDownItems, modelItem.Items);
				}

				viewItem.Dispose();
			}
		}
		private ToolStripItemCollection GetTargetViewItemCollection(IMenuModelItem modelItem)
		{
			if (modelItem.Parent == null) return this.target;

			ToolStripItem viewItemParent;
			if (!this.viewItems.TryGetValue(modelItem.Parent, out viewItemParent)) return this.target;

			ToolStripMenuItem viewMenuItem = viewItemParent as ToolStripMenuItem;
			if (viewMenuItem == null) return this.target;

			return viewMenuItem.DropDownItems;
		}
		
		private void RaiseItemInserted(IMenuModelItem modelItem, ToolStripItem viewItem)
		{
			if (this.ItemInserted != null)
				this.ItemInserted(this, new MenuStripMenuViewItemEventArgs(modelItem, viewItem, this));
		}
		private void RaiseItemRemoved(IMenuModelItem modelItem, ToolStripItem viewItem)
		{
			if (this.ItemRemoved != null)
				this.ItemRemoved(this, new MenuStripMenuViewItemEventArgs(modelItem, viewItem, this));
		}

		private void viewMenuItem_DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			if (e.CloseReason != ToolStripDropDownCloseReason.ItemClicked) return;

			ToolStripDropDownMenu menu = sender as ToolStripDropDownMenu;
			ToolStripItem viewItem = menu != null ? menu.GetItemAt(menu.PointToClient(Cursor.Position)) : null;
			if (viewItem == null) return;

			IMenuModelItem modelItem = this.GetModelItem(viewItem);
			if (modelItem == null) return;

			if (modelItem.Checkable) e.Cancel = true;
		}
		private void viewMenuItem_CheckedChanged(object sender, System.EventArgs e)
		{
			ToolStripMenuItem viewItem = sender as ToolStripMenuItem;
			if (viewItem == null) return;

			IMenuModelItem modelItem = this.GetModelItem(viewItem);
			if (modelItem != null)
			{
				modelItem.Checked = viewItem.Checked;
			}
		}
		private void viewMenuItem_Click(object sender, System.EventArgs e)
		{
			ToolStripItem viewItem = sender as ToolStripItem;
			if (viewItem == null) return;

			IMenuModelItem modelItem = this.GetModelItem(viewItem);
			if (modelItem != null)
			{
				modelItem.RaisePerformAction();
			}
		}
		private void model_ItemsAdded(object sender, MenuModelItemsEventArgs e)
		{
			this.CreateViewItems(null, e.Items);
		}
		private void model_ItemsRemoved(object sender, MenuModelItemsEventArgs e)
		{
			this.DestroyViewItems(null, e.Items);
		}
		private void model_ItemsChanged(object sender, MenuModelItemsEventArgs e)
		{
			foreach (IMenuModelItem modelItem in e.Items)
			{
				ToolStripItem viewItem;
				if (this.viewItems.TryGetValue(modelItem, out viewItem))
				{
					this.UpdateItemProperties(modelItem, viewItem);
					if (e.IsSortingAffected)
					{
						ToolStripItemCollection collection = null;
						ToolStripItem parentViewItem;
						if (modelItem.Parent != null && this.viewItems.TryGetValue(modelItem.Parent, out parentViewItem) && parentViewItem is ToolStripMenuItem)
						{
							collection = (parentViewItem as ToolStripMenuItem).DropDownItems;
						}
						else if (modelItem.Parent == null)
						{
							collection = this.target;
						}
						if (collection != null)
						{
							this.RemoveViewItem(collection, viewItem, modelItem);
							this.InsertViewItem(collection, viewItem, modelItem);
						}
					}
				}
			}
		}

		private static int DefaultItemComparison(IMenuModelItem itemA, IMenuModelItem itemB)
		{
			return itemA.SortValue - itemB.SortValue;
		}
	}
}
