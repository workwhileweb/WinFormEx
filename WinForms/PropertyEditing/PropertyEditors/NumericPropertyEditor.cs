﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AdamsLair.WinForms.PropertyEditing.EditorTemplates;

namespace AdamsLair.WinForms.PropertyEditing.PropertyEditors
{
	public class NumericPropertyEditor : PropertyEditor
	{
		private	NumericEditorTemplate	numEditor = null;
		private	decimal	val			= 0m;
		private	bool	valMultiple	= false;

		public override object DisplayedValue
		{
			get { return Convert.ChangeType(this.val, this.EditedType); }
		}
		public decimal Minimum
		{
			get { return this.numEditor.Minimum; }
			set
			{
				this.numEditor.Minimum = value;
				this.UpdateHeight();
			}
		}
		public decimal Maximum
		{
			get { return this.numEditor.Maximum; }
			set
			{
				this.numEditor.Maximum = value;
				this.UpdateHeight();
			}
		}
		public decimal ValueBarMinimum
		{
			get { return this.numEditor.ValueBarMinimum; }
			set { this.numEditor.ValueBarMinimum = value; }
		}
		public decimal ValueBarMaximum
		{
			get { return this.numEditor.ValueBarMaximum; }
			set { this.numEditor.ValueBarMaximum = value; }
		}
		public decimal Increment
		{
			get { return this.numEditor.Increment; }
			set
			{
				this.numEditor.Increment = value;
				this.UpdateHeight();
			}
		}
		public int DecimalPlaces
		{
			get { return this.numEditor.DecimalPlaces; }
			set { this.numEditor.DecimalPlaces = value; }
		}


		public NumericPropertyEditor()
		{
			this.numEditor = new NumericEditorTemplate(this);
			this.numEditor.Invalidate += this.numEditor_Invalidate;
			this.numEditor.Edited += this.numEditor_Edited;
			this.numEditor.EditingFinished += this.numEditor_EditingFinished;

			//this.Height = 18;
		}
		protected override void OnParentEditorChanged()
		{
			base.OnParentEditorChanged();
			this.UpdateHeight();
		}


		protected override void OnGetValue()
		{
			base.OnGetValue();
			this.BeginUpdate();
			object[] values = this.GetValue().ToArray();

			// Apply values to editors
			if (!values.Any())
				this.val = 0m;
			else
			{
				this.val = values.Any(o => o != null) ? values.Where(o => o != null).Average(o => SafeToDecimal(o)) : 0m;
				this.valMultiple = values.Any(o => o == null) || !values.All(o => SafeToDecimal(o) == this.val);
			}

			this.numEditor.Value = this.val;
			this.EndUpdate();
		}
		
		protected internal override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			this.numEditor.OnPaint(e, this.Enabled, this.valMultiple);
		}
		protected internal override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.numEditor.OnGotFocus(e);
			this.numEditor.Select();
		}
		protected internal override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.numEditor.OnLostFocus(e);
		}
		protected internal override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			this.numEditor.OnKeyPress(e);
		}
		protected internal override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			this.numEditor.OnKeyDown(e);
		}
		protected internal override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			this.numEditor.OnKeyUp(e);
		}
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.numEditor.OnMouseMove(e);
		}
		protected internal override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.numEditor.OnMouseLeave(e);
		}
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.numEditor.OnMouseDown(e);
		}
		protected internal override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.numEditor.OnMouseUp(e);
		}
		protected internal override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
			this.numEditor.OnMouseDoubleClick(e);
		}

		private void UpdateHeight()
		{
			if (this.ControlRenderer == null) return;

			bool showMinMaxBar = false;
			if (this.ValueBarMinimum > decimal.MinValue / 2 && this.ValueBarMaximum < decimal.MaxValue / 2)
			{
				showMinMaxBar = (float)((this.ValueBarMaximum - this.ValueBarMinimum) / this.Increment) < 10000.0f;
			}

			int prefHeight = 5 + (int)Math.Round((float)this.ControlRenderer.FontRegular.Height);
			if (showMinMaxBar) prefHeight += 3;
			this.Height = prefHeight;
			this.numEditor.ShowMinMaxBar = showMinMaxBar;
		}
		protected override void UpdateGeometry()
		{
			base.UpdateGeometry();
			this.numEditor.Rect = new Rectangle(
				this.ClientRectangle.X + 1,
				this.ClientRectangle.Y + 1,
				this.ClientRectangle.Width - 2,
				this.ClientRectangle.Height - 1);
		}
		protected internal override void OnReadOnlyChanged()
		{
			base.OnReadOnlyChanged();
			this.numEditor.ReadOnly = this.ReadOnly;
		}
		protected override void OnEditedTypeChanged()
		{
			base.OnEditedTypeChanged();
			if (this.EditedType == typeof(byte))
			{
				this.numEditor.DecimalPlaces = 0;
				this.numEditor.Minimum = byte.MinValue;
				this.numEditor.Maximum = byte.MaxValue;
			}
			else if (this.EditedType == typeof(sbyte))
			{
				this.numEditor.DecimalPlaces = 0;
				this.numEditor.Minimum = sbyte.MinValue;
				this.numEditor.Maximum = sbyte.MaxValue;
			}
			else if (this.EditedType == typeof(short))
			{
				this.numEditor.DecimalPlaces = 0;
				this.numEditor.Minimum = short.MinValue;
				this.numEditor.Maximum = short.MaxValue;
			}
			else if (this.EditedType == typeof(ushort))
			{
				this.numEditor.DecimalPlaces = 0;
				this.numEditor.Minimum = ushort.MinValue;
				this.numEditor.Maximum = ushort.MaxValue;
			}
			else if (this.EditedType == typeof(int))
			{
				this.numEditor.DecimalPlaces = 0;
				this.numEditor.Minimum = int.MinValue;
				this.numEditor.Maximum = int.MaxValue;
			}
			else if (this.EditedType == typeof(uint))
			{
				this.numEditor.DecimalPlaces = 0;
				this.numEditor.Minimum = uint.MinValue;
				this.numEditor.Maximum = uint.MaxValue;
			}
			else if (this.EditedType == typeof(long))
			{
				this.numEditor.DecimalPlaces = 0;
				this.numEditor.Minimum = long.MinValue;
				this.numEditor.Maximum = long.MaxValue;
			}
			else if (this.EditedType == typeof(ulong))
			{
				this.numEditor.DecimalPlaces = 0;
				this.numEditor.Minimum = ulong.MinValue;
				this.numEditor.Maximum = ulong.MaxValue;
			}
			else if (this.EditedType == typeof(float))
			{
				this.numEditor.DecimalPlaces = 2;
				this.numEditor.Increment = 0.1m;
				this.numEditor.Minimum = decimal.MinValue;
				this.numEditor.Maximum = decimal.MaxValue;
			}
			else if (this.EditedType == typeof(double))
			{
				this.numEditor.DecimalPlaces = 2;
				this.numEditor.Minimum = decimal.MinValue;
				this.numEditor.Maximum = decimal.MaxValue;
			}
			else if (this.EditedType == typeof(decimal))
			{
				this.numEditor.DecimalPlaces = 2;
				this.numEditor.Minimum = decimal.MinValue;
				this.numEditor.Maximum = decimal.MaxValue;
			}
		}

		private void numEditor_Edited(object sender, EventArgs e)
		{
			if (this.IsUpdating) return;
			if (this.Disposed) return;

			this.val = this.numEditor.Value;
			this.PerformSetValue();
			this.PerformGetValue();
		}
		private void numEditor_Invalidate(object sender, EventArgs e)
		{
			this.Invalidate();
		}
		private void numEditor_EditingFinished(object sender, PropertyEditingFinishedEventArgs e)
		{
			this.OnEditingFinished(e.Reason);
			this.PerformGetValue();
		}

		private static decimal SafeToDecimal(object o)
		{
			double v = Convert.ToDouble(o);
			if (double.IsNaN(v))
				return decimal.Zero;
			else if (v <= (double)decimal.MinValue || double.IsNegativeInfinity(v))
				return decimal.MinValue;
			else if (v >= (double)decimal.MaxValue || double.IsPositiveInfinity(v))
				return decimal.MaxValue;
			else
				return (decimal)v;
		}
	}
}
