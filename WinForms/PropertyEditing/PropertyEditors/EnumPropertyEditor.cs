﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AdamsLair.WinForms.Internal;
using AdamsLair.WinForms.PropertyEditing.EditorTemplates;

namespace AdamsLair.WinForms.PropertyEditing.PropertyEditors
{
	public class EnumPropertyEditor : PropertyEditor, IPopupControlHost
	{
		private	ComboBoxEditorTemplate	stringSelector	= null;
		private Enum	val				= null;
		private	bool	valMultiple		= false;

		public override object DisplayedValue
		{
			get { return this.val != null ? Convert.ChangeType(this.val, this.EditedType) : this.EditedType.GetDefaultInstanceOf(); }
		}
		public bool IsDropDownOpened
		{
			get { return this.stringSelector.IsDropDownOpened; }
		}
		public string DropDownHoveredName
		{
			get { return this.stringSelector.DropDownHoveredObject as string; }
		}
		

		public EnumPropertyEditor()
		{
			this.stringSelector = new ComboBoxEditorTemplate(this);
			this.stringSelector.Invalidate += this.stringSelector_Invalidate;
			this.stringSelector.Edited += this.stringSelector_Edited;

			//this.Height = 18;
		}
		protected override void OnParentEditorChanged()
		{
			base.OnParentEditorChanged();
			this.Height = 5 + (int)Math.Round((float)this.ControlRenderer.FontRegular.Height);
		}
		
		public void ShowDropDown()
		{
			this.stringSelector.ShowDropDown();
		}
		public void HideDropDown()
		{
			this.stringSelector.HideDropDown();
		}
		protected override void OnGetValue()
		{
			base.OnGetValue();
			this.BeginUpdate();
			Enum[] values = this.GetValue().Select(o => o is Enum ? (Enum)o : null).ToArray();
			IEnumerable<Enum> valuesNotNull = values.Where(o => o != null);

			// Apply values to editors
			if (!valuesNotNull.Any())
			{
				this.val = null;
			}
			else
			{
				Enum firstVal = valuesNotNull.First();

				this.val = firstVal;
				this.valMultiple = values.Any(o => o == null) || !values.All(o => Enum.Equals(o, firstVal));
			}

			this.stringSelector.SelectedObject = this.val != null ? this.val.ToString() : null;
			this.EndUpdate();
		}

		protected internal override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			this.stringSelector.OnPaint(e, this.Enabled, this.valMultiple);
		}
		protected internal override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.stringSelector.OnGotFocus(e);
		}
		protected internal override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.stringSelector.OnLostFocus(e);
		}
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.stringSelector.OnMouseMove(e);
		}
		protected internal override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.stringSelector.OnMouseLeave(e);
		}
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.stringSelector.OnMouseDown(e);
		}
		protected internal override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.stringSelector.OnMouseUp(e);
		}
		protected internal override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			this.stringSelector.OnKeyDown(e);
		}
		protected internal override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			this.stringSelector.OnKeyUp(e);
		}

		protected override void UpdateGeometry()
		{
			base.UpdateGeometry();
			this.stringSelector.Rect = new Rectangle(
				this.ClientRectangle.X + 1,
				this.ClientRectangle.Y + 1,
				this.ClientRectangle.Width - 2,
				this.ClientRectangle.Height - 1);
		}
		protected internal override void OnReadOnlyChanged()
		{
			base.OnReadOnlyChanged();
			this.stringSelector.ReadOnly = this.ReadOnly;
		}
		protected override void OnEditedTypeChanged()
		{
			base.OnEditedTypeChanged();
			this.stringSelector.DropDownItems = Enum.GetNames(this.EditedType);
		}

		private void stringSelector_Invalidate(object sender, EventArgs e)
		{
			this.Invalidate();
		}
		private void stringSelector_Edited(object sender, EventArgs e)
		{
			if (this.IsUpdating) return;
			if (this.Disposed) return;

			object selection = this.stringSelector.SelectedObject;
			if (selection == null) return;

			this.val = (Enum)Enum.Parse(this.EditedType, selection.ToString());
			this.Invalidate();
			this.PerformSetValue();
			this.PerformGetValue();
			this.OnEditingFinished(FinishReason.LeapValue);
		}
	}
}
