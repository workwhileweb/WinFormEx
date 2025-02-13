﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

using AdamsLair.WinForms.Drawing;
using AdamsLair.WinForms.Internal;

namespace AdamsLair.WinForms.PropertyEditing
{
	public class PropertyEditorEventArgs : EventArgs
	{
		PropertyEditor editor;

		public PropertyEditor Editor
		{
			get { return this.editor; }
		}

		public PropertyEditorEventArgs(PropertyEditor e)
		{
			this.editor = e;
		}
	}

	public class PropertyEditorValueEventArgs : EventArgs
	{
		private	PropertyEditor	editor	= null;
		private	object			value	= null;

		public PropertyEditor Editor
		{
			get { return this.editor; }
		}
		public object Value
		{
			get { return this.value; }
		}

		public PropertyEditorValueEventArgs(PropertyEditor editor, object value)
		{
			this.editor = editor;
			this.value = value;
		}
	}

	public enum FinishReason
	{
		Unknown,

		LostFocus,
		LeapValue,
		UserAccept
	}

	public class PropertyEditingFinishedEventArgs : PropertyEditorValueEventArgs
	{
		private	FinishReason	reason	= FinishReason.Unknown;

		public FinishReason Reason
		{
			get { return this.reason; }
		}

		public PropertyEditingFinishedEventArgs(PropertyEditor editor, object value, FinishReason reason) : base(editor, value)
		{
			this.reason = reason;
		}
	}
	
	public abstract class PropertyEditor : IDisposable
	{
		[Flags]
		public enum HintFlags
		{
			None			= 0x00,

			HasPropertyName	= 0x01,
			HasButton		= 0x02,
			HasExpandCheck	= 0x04,
			HasActiveCheck	= 0x08,

			ButtonEnabled	= 0x10,
			ExpandEnabled	= 0x20,
			ActiveEnabled	= 0x40,

			All = HasPropertyName | HasButton | HasExpandCheck | HasActiveCheck | ButtonEnabled | ExpandEnabled | ActiveEnabled,
			Default = HasPropertyName
		}

		[Flags]
		private enum StateFlags
		{
			None			= 0x0,

			ButtonHovered	= 0x1,
			ButtonPressed	= 0x2,
		}

		private static readonly PropertyEditor[] EmptyPropertyEditors = new PropertyEditor[0];

		private	PropertyGrid	parentGrid		= null;
		private	PropertyEditor	parentEditor	= null;
		private	Type			editedType		= null;
		private	MemberInfo		editedMember	= null;
		private	string			propertyName	= AdamsLair.WinForms.Properties.Resources.PropertyName_Default;
		private	string			propertyDesc	= null;
		private	object			configureData	= null;
		private	bool			forceWriteBack	= false;
		private	bool			valueModified	= false;
		private	bool			mutableValue	= false;
		private	bool			memberNonPublic	= false;
		private	bool			readOnly		= false;
		private	int				updateLockCount	= 0;
		private	bool			disposed		= false;
		private	HintFlags		hints			= HintFlags.Default;
		private	Rectangle		rect			= new Rectangle(0, 0, 0, 20);
		private	Rectangle		clientRect		= Rectangle.Empty;
		private	Rectangle		nameLabelRect	= Rectangle.Empty;
		private	Rectangle		buttonRect		= Rectangle.Empty;
		private	StateFlags		stateFlags		= StateFlags.None;
		private	IconImage		buttonIcon		= new IconImage(AdamsLair.WinForms.Properties.ResourcesCache.ImageDelete);
		private	Func<IEnumerable<object>>	getter	= null;
		private	Action<IEnumerable<object>>	setter	= null;


		public event EventHandler	SizeChanged		= null;
		public event EventHandler	LocationChanged	= null;
		public event EventHandler	ButtonPressed	= null;
		public event EventHandler<PropertyEditingFinishedEventArgs>	EditingFinished = null;
		public event EventHandler<PropertyEditorValueEventArgs>		ValueChanged	= null;


		public bool Disposed
		{
			get { return this.disposed; }
		}
		public PropertyGrid ParentGrid
		{
			get { return this.parentGrid; }
			internal set
			{
				bool lastReadOnly = this.ReadOnly;
				this.parentGrid = value;
				if (this.parentGrid == null) this.parentEditor = null;
				if (this.ReadOnly != lastReadOnly) this.OnReadOnlyChanged();
				this.OnParentEditorChanged();
			}
		}
		public PropertyEditor ParentEditor
		{
			get { return this.parentEditor; }
			internal set
			{
				bool lastReadOnly = this.ReadOnly;
				this.parentEditor = value;
				if (this.parentEditor != null) this.parentGrid = this.parentEditor.ParentGrid;
				if (this.ReadOnly != lastReadOnly) this.OnReadOnlyChanged();
				this.OnParentEditorChanged();
			}
		}
		public virtual bool AreChildEditorsVisible
		{
			get { return false; }
		}
		public virtual IReadOnlyList<PropertyEditor> ChildEditors
		{
			get { return EmptyPropertyEditors; }
		}
		public IReadOnlyList<PropertyEditor> VisibleChildEditors
		{
			get { return this.AreChildEditorsVisible ? this.ChildEditors : EmptyPropertyEditors; }
		}
		
		/// <summary>
		/// [GET / SET] The Type of values that this PropertyEditor is able to edit.
		/// </summary>
		public Type EditedType
		{
			get { return this.editedType; }
			set 
			{
				if (this.editedType != value)
				{
					this.editedType = value;
					this.OnEditedTypeChanged();
				}
			}
		}
		/// <summary>
		/// [GET / SET] The underlying reflected MemberInfo, which is edited by this PropertyEditor.
		/// This is usually null for PropertyEditors that haven't been instantiated by <see cref="MemberwisePropertyEditor"/>
		/// </summary>
		public MemberInfo EditedMember
		{
			get { return this.editedMember; }
			set 
			{
				if (this.editedMember != value)
				{
					this.editedMember = value;
					this.OnEditedMemberChanged();
				}
			}
		}
		public string PropertyName
		{
			get { return this.propertyName; }
			set 
			{
				if (this.propertyName != value)
				{
					this.propertyName = value;
					this.Invalidate();
				}
			}
		}
		public string PropertyDesc
		{
			get { return this.propertyDesc; }
			set { this.propertyDesc = value; }
		}
		public object ConfigureData
		{
			get { return this.configureData; }
		}
		public bool ForceWriteBack
		{
			get { return this.forceWriteBack; }
			set { this.forceWriteBack = value; }
		}
		public bool ValueModified
		{
			get { return this.valueModified; }
			set { this.valueModified = value; }
		}
		/// <summary>
		/// [GET / SET] Specifies whether this PropertyEditor can be modified, even when its parents are set to <see cref="ReadOnly"/> mode.
		/// </summary>
		public bool ValueMutable
		{
			get { return this.mutableValue; }
			set { this.mutableValue = value; }
		}
		/// <summary>
		/// [GET / SET] Specifies whether this PropertyEditor represents a non-public value. It will
		/// usually be displayed "greyed out", so the user is able to make a distinction between
		/// public and non-public data, which is only displayed for debugging purposes.
		/// </summary>
		public bool NonPublic
		{
			get { return this.memberNonPublic; }
			set { this.memberNonPublic = value; }
		}
		public Func<IEnumerable<object>> Getter
		{
			set { this.getter = value; }
		}
		public Action<IEnumerable<object>> Setter
		{
			set
			{ 
				bool lastReadOnly = this.ReadOnly;
				this.setter = value;
				if (this.ReadOnly != lastReadOnly) this.OnReadOnlyChanged();
			}
		}
		public abstract object DisplayedValue { get; }
		public bool ReadOnly
		{
			get { return this.readOnly || this.setter == null || (!this.mutableValue && this.parentEditor != null && this.parentEditor.ReadOnly); }
			set
			{
				bool lastReadOnly = this.ReadOnly;
				this.readOnly = value;
				if (this.ReadOnly != lastReadOnly) this.OnReadOnlyChanged();
			}
		}
		public bool Enabled
		{
			get { return this.parentGrid != null && this.parentGrid.Enabled; }
		}
		public bool Focused
		{
			get
			{
				if (this.parentGrid == null) return false;
				return this.parentGrid.Focused && this.parentGrid.FocusEditor == this;
			}
		}
		public virtual bool FocusOnClick
		{
			get { return this.CanGetFocus; }
		}
		public virtual bool CanGetFocus
		{
			get { return this.Height > 0; }
		}
		public HintFlags Hints
		{
			get { return this.hints; }
			set
			{
				if (this.hints != value)
				{
					this.hints = value;
					if (this.parentGrid != null) this.UpdateGeometry();
				}
			}
		}
		public Image ButtonIcon
		{
			get { return this.buttonIcon.SourceImage; }
			set
			{
				if (value == null) value = AdamsLair.WinForms.Properties.ResourcesCache.ImageDelete;
				if (this.buttonIcon == null || this.buttonIcon.SourceImage != value)
				{
					this.buttonIcon = new IconImage(value);
					this.Invalidate();
				}
			}
		}
		/// <summary>
		/// [GET] Returns whether or not this editor is currently performing a refresh operation.
		/// </summary>
		protected bool IsUpdating
		{
			get { return this.updateLockCount > 0; }
		}

		public Rectangle EditorRectangle
		{
			get { return this.rect; }
			set
			{
				this.Location = value.Location;
				this.Size = value.Size;
			}
		}
		public Point Location
		{
			get { return this.rect.Location; }
			set
			{
				if (this.rect.Location != value)
				{
					this.rect.Location = value;
					this.OnLocationChanged();
				}
			}
		}
		public Size Size
		{
			get { return this.rect.Size; }
			set
			{
				if (this.rect.Size != value)
				{
					this.rect.Size = value;
					this.OnSizeChanged();
				}
			}
		}
		public int Width
		{
			get { return this.rect.Width; }
			set { this.Size = new Size(value, this.rect.Height); }
		}
		public int Height
		{
			get { return this.rect.Height; }
			set { this.Size = new Size(this.rect.Width, value); }
		}
		
		public Rectangle ClientRectangle
		{
			get { return this.clientRect; }
			protected set { this.clientRect = value; }
		}
		protected Rectangle NameLabelRectangle
		{
			get { return this.nameLabelRect; }
			set { this.nameLabelRect = value; }
		}
		protected Rectangle ButtonRectangle
		{
			get { return this.buttonRect; }
			set { this.buttonRect = value; }
		}
		protected int NameLabelWidth
		{
			get
			{
				if (this.parentGrid == null) return 0;
				return Math.Max(this.parentGrid.SplitterPosition - this.rect.X, 0);
			}
		}
		internal protected ControlRenderer ControlRenderer
		{
			get { return this.parentGrid != null ? this.parentGrid.Renderer : null; }
		}
		

		~PropertyEditor()
		{
			this.Dispose(false);
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool manually)
		{
			if (this.disposed) return;

			this.OnDisposing(manually);
			this.disposed = true;
		}
		protected virtual void OnDisposing(bool manually) {}


		public void PerformGetValue()
		{
			if (this.Disposed) return;
			this.OnGetValue();
		}
		public void PerformSetValue()
		{
			if (this.Disposed) return;
			if (this.ReadOnly) return;
			this.OnSetValue();
		}

		/// <summary>
		/// Performs a get operation using the PropertyEditors <see cref="Getter"/>.
		/// </summary>
		/// <returns></returns>
		protected IEnumerable<object> GetValue()
		{
			// Retrieve raw value from getter
			IEnumerable<object> result = null;
			if (this.getter != null) result = this.getter();

			// Perform a safety check, whether the EditedType matches the received value
			if (this.editedType != null && result != null)
				result = result.Where(v => v == null || this.editedType.IsInstanceOfType(v));
			
			return result;
		}
		/// <summary>
		/// Performs a set operation using the PropertyEditors <see cref="Setter"/>.
		/// </summary>
		/// <param name="objEnum"></param>
		protected void SetValues(IEnumerable<object> objEnum)
		{
			if (this.setter == null) return;
			this.parentGrid.PrepareSetValue();

			this.setter(objEnum);

			this.OnValueChanged();
			this.parentGrid.PostSetValue();

			// If setting the value changed the reflected type of a member value,
			// this property editor might no longer be appropriate. Let the parent
			// editor check to be sure. Might remove and dispose this editor, so
			// it should happen after the set operation is considered "done".
			if (this.parentEditor != null)
				this.parentEditor.VerifyReflectedTypeEditors(this.parentEditor.GetValue());
		}
		/// <summary>
		/// Performs a set operation using the PropertyEditors <see cref="Setter"/>.
		/// </summary>
		/// <param name="obj"></param>
		protected void SetValue(object obj)
		{
			this.SetValues(new object[] { obj });
		}

		protected virtual void OnGetValue() {}
		protected virtual void OnSetValue()
		{
			this.SetValue(this.DisplayedValue);
		}

		/// <summary>
		/// This method is called in order to determine whether all of the editors children
		/// are still valid regarding their dynamically reflected member Types. When a child
		/// editor of an typeof(object) member has been dynamically typed to typeof(int) because
		/// of its content, this method allows to switch re-initialize or re-create the editor
		/// with an updated Type after the members value has changed from typeof(int) to typeof(float).
		/// </summary>
		/// <param name="values"></param>
		protected virtual void VerifyReflectedTypeEditors(IEnumerable<object> values) {}

		public void Invalidate()
		{
			if (this.parentGrid == null) return;
			Rectangle invalidateRect = new Rectangle(
				this.rect.X + this.parentGrid.AutoScrollPosition.X, 
				this.rect.Y + this.parentGrid.AutoScrollPosition.Y, 
				this.rect.Width, 
				this.rect.Height);
			this.parentGrid.Invalidate(invalidateRect);
		}
		public void Invalidate(Rectangle targetRect)
		{
			if (this.parentGrid == null) return;
			Rectangle invalidateRect = new Rectangle(
				this.parentGrid.AutoScrollPosition.X + targetRect.X, 
				this.parentGrid.AutoScrollPosition.Y + targetRect.Y, 
				targetRect.Width, 
				targetRect.Height);
			this.parentGrid.Invalidate(invalidateRect);
		}
		public void Focus()
		{
			if (this.parentGrid != null) this.parentGrid.Focus(this);
		}
		public bool IsChildOf(PropertyEditor parent)
		{
			if (this.parentEditor == parent) return true;
			if (this.parentEditor == null) return false;
			return this.parentEditor.IsChildOf(parent);
		}
		public IEnumerable<PropertyEditor> GetChildEditorsDeep(bool visibleOnly)
		{
			if (visibleOnly && !this.AreChildEditorsVisible) yield break;

			foreach (PropertyEditor child in this.ChildEditors)
			{
				yield return child;
				foreach (PropertyEditor subChild in child.GetChildEditorsDeep(visibleOnly))
				{
					yield return subChild;
				}
			}
		}

		protected virtual void UpdateGeometry()
		{
			if ((this.hints & HintFlags.HasPropertyName) != HintFlags.None)
				this.nameLabelRect = new Rectangle(this.rect.X, this.rect.Y, this.NameLabelWidth, this.rect.Height);
			else
				this.nameLabelRect = Rectangle.Empty;

			if ((this.hints & HintFlags.HasButton) != HintFlags.None)
			{
				Size buttonSize = this.buttonIcon != null ? this.buttonIcon.Size : new Size(10, 10);
				this.buttonRect.Height = this.Size.Height;
				this.buttonRect.Width = Math.Min(this.rect.Height, buttonSize.Height + 2);
				this.buttonRect.X = this.rect.Right - buttonRect.Width - 1;
				this.buttonRect.Y = this.rect.Y;
			}
			else
				this.buttonRect = Rectangle.Empty;

			this.clientRect = this.rect;
			this.clientRect.X += this.nameLabelRect.Width;
			this.clientRect.Width -= this.nameLabelRect.Width;
			this.clientRect.Width -= this.buttonRect.Width;
		}
		/// <summary>
		/// Begins a refresh operation on this editor.
		/// </summary>
		/// <returns>
		/// Returns whether this method call initialized the current refresh operation. 
		/// False, if it already has been initialized by a previous call.
		/// </returns>
		public virtual bool BeginUpdate()
		{
			return (this.updateLockCount++) == 0;
		}
		/// <summary>
		/// Ends a the current refresh operation on this editor.
		/// </summary>
		/// <returns>
		/// Returns whether this method call terminated the current refresh operation. 
		/// False, if termination will occur by one of the subsequent calls of this method.
		/// </returns>
		public virtual bool EndUpdate()
		{
			if (this.updateLockCount == 0) throw new InvalidOperationException("The PropertyEditor was not updating");
			return (--this.updateLockCount) == 0;
		}
		
		protected void PaintBackground(Graphics g)
		{
			bool focusBg = this.Focused || (this is IPopupControlHost && (this as IPopupControlHost).IsDropDownOpened);
			Color bgColor = this.ControlRenderer.GetBackgroundColor(focusBg, this.rect.X);
			g.FillRectangle(new SolidBrush(bgColor), this.rect);
		}
		protected void PaintButton(Graphics g)
		{
			if (!this.hints.HasFlag(HintFlags.HasButton) || this.buttonIcon == null) return;

			Size buttonSize = new Size(
				Math.Min(this.buttonIcon.Width, this.buttonRect.Width),
				Math.Min(this.buttonIcon.Height, this.buttonRect.Height));
			Point buttonCenter = new Point(this.buttonRect.X + this.buttonRect.Width / 2, this.buttonRect.Y + this.buttonRect.Height / 2);

			Image buttonImage;
			if ((this.Hints & HintFlags.ButtonEnabled) == HintFlags.None || this.ReadOnly || !this.Enabled)
				buttonImage = this.buttonIcon.Disabled;
			else if (this.stateFlags.HasFlag(StateFlags.ButtonPressed))
				buttonImage = this.buttonIcon.Active;
			else if (this.stateFlags.HasFlag(StateFlags.ButtonHovered) || this.Focused)
				buttonImage = this.buttonIcon.Normal;
			else
				buttonImage = this.buttonIcon.Passive;
				
			if (this.stateFlags.HasFlag(StateFlags.ButtonHovered))
			{
				Rectangle buttonBgRect = this.buttonRect;
				buttonBgRect.Height = Math.Min(buttonBgRect.Height, buttonBgRect.Width) - 1;
				buttonBgRect.Width = buttonBgRect.Height;
				buttonBgRect.X = this.buttonRect.X + this.buttonRect.Width / 2 - buttonBgRect.Width / 2 - 1;
				buttonBgRect.Y = this.buttonRect.Y + this.buttonRect.Height / 2 - buttonBgRect.Height / 2 - 1;
				g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.White)), buttonBgRect);
			}
				
			g.DrawImage(buttonImage, buttonCenter.X - buttonSize.Width / 2, buttonCenter.Y - buttonSize.Height / 2, buttonSize.Width, buttonSize.Height);
		}
		protected void PaintNameLabel(Graphics g)
		{
			if ((this.hints & HintFlags.HasPropertyName) == HintFlags.None) return;
			ControlRenderer.DrawStringLine(g, 
				this.propertyName, 
				this.ValueModified ? ControlRenderer.FontBold : ControlRenderer.FontRegular, 
				this.nameLabelRect, 
				this.Enabled && !this.NonPublic ? ControlRenderer.ColorText : ControlRenderer.ColorGrayText);
		}
		internal protected virtual void OnPaint(PaintEventArgs e)
		{
			this.PaintBackground(e.Graphics);
			this.PaintNameLabel(e.Graphics);
			this.PaintButton(e.Graphics);
		}
		
		internal protected virtual void OnMouseEnter(EventArgs e) {}
		internal protected virtual void OnMouseLeave(EventArgs e)
		{
			if (this.stateFlags.HasFlag(StateFlags.ButtonHovered)) this.Invalidate();
			this.stateFlags &= ~StateFlags.ButtonHovered;
		}
		internal protected virtual void OnMouseMove(MouseEventArgs e)
		{
			bool lastHovered = this.stateFlags.HasFlag(StateFlags.ButtonHovered);
			bool buttonHovered = (this.Hints & HintFlags.ButtonEnabled) != HintFlags.None && !this.ReadOnly && this.ButtonRectangle.Contains(e.Location);
			if (buttonHovered && !lastHovered)
			{
				this.stateFlags |= StateFlags.ButtonHovered;
				this.Invalidate();
			}
			else if (!buttonHovered && lastHovered)
			{
				this.stateFlags &= ~StateFlags.ButtonHovered;
				this.Invalidate();
			}
		}
		internal protected virtual void OnMouseDown(MouseEventArgs e)
		{
			if (this.FocusOnClick && this.rect.Contains(e.Location))
				this.Focus();
			if (this.stateFlags.HasFlag(StateFlags.ButtonHovered) && (e.Button & MouseButtons.Left) != MouseButtons.None)
			{
				this.stateFlags |= StateFlags.ButtonPressed;
				this.Invalidate();
			}
		}
		internal protected virtual void OnMouseUp(MouseEventArgs e)
		{
			if (this.stateFlags.HasFlag(StateFlags.ButtonPressed) && (e.Button & MouseButtons.Left) != MouseButtons.None)
			{
				this.stateFlags &= ~StateFlags.ButtonPressed;
				this.Invalidate();
				if (this.stateFlags.HasFlag(StateFlags.ButtonHovered)) this.OnButtonPressed();
			}
		}
		internal protected virtual void OnMouseClick(MouseEventArgs e) {}
		internal protected virtual void OnMouseDoubleClick(MouseEventArgs e) {}

		internal protected virtual void OnKeyDown(KeyEventArgs e) {}
		internal protected virtual void OnKeyUp(KeyEventArgs e) {}
		internal protected virtual void OnKeyPress(KeyPressEventArgs e) {}

		internal protected virtual void OnDragEnter(DragEventArgs e) {}
		internal protected virtual void OnDragLeave(EventArgs e) {}
		internal protected virtual void OnDragOver(DragEventArgs e) {}
		internal protected virtual void OnDragDrop(DragEventArgs e) {}

		internal protected virtual void OnGotFocus(EventArgs e)
		{
			this.Invalidate();
		}
		internal protected virtual void OnLostFocus(EventArgs e)
		{
			this.Invalidate();
		}

		internal protected virtual void OnReadOnlyChanged()
		{
			this.Invalidate();
		}
		internal protected virtual void OnGridSplitterChanged()
		{
			this.UpdateGeometry();
		}
		protected virtual void OnEditedTypeChanged()
		{
			this.Invalidate();
		}
		protected virtual void OnEditedMemberChanged()
		{
			this.Invalidate();
			if (this.editedMember != null)
			{
				bool flaggedForceWriteBack = false;
				this.forceWriteBack = flaggedForceWriteBack;
			}
			else
				this.forceWriteBack = false;
		}
		protected virtual void OnLocationChanged()
		{
			if (this.parentGrid != null) this.UpdateGeometry();
			if (this.LocationChanged != null)
				this.LocationChanged(this, EventArgs.Empty);
		}
		protected virtual void OnSizeChanged()
		{
			if (this.parentGrid != null) this.UpdateGeometry();
			if (this.SizeChanged != null)
				this.SizeChanged(this, EventArgs.Empty);
		}
		protected virtual void OnButtonPressed()
		{
			if (this.ButtonPressed != null)
				this.ButtonPressed(this, EventArgs.Empty);
		}
		protected virtual void OnParentEditorChanged() {}
		protected virtual void OnValueChanged(object sender, PropertyEditorValueEventArgs args)
		{
			if (this.ValueChanged != null)
				this.ValueChanged(sender, args);
		}
		protected virtual void OnEditingFinished(object sender, PropertyEditingFinishedEventArgs args)
		{
			if (this.EditingFinished != null)
				this.EditingFinished(sender, args);
		}

		internal protected virtual void ConfigureEditor(object configureData)
		{
			this.configureData = configureData;
		}

		protected void OnValueChanged()
		{
			this.OnValueChanged(this, new PropertyEditorValueEventArgs(this, this.DisplayedValue));
		}
		protected void OnEditingFinished(FinishReason reason)
		{
			this.OnEditingFinished(this, new PropertyEditingFinishedEventArgs(this, this.DisplayedValue, reason));
		}

		public override string ToString()
		{
			return string.Format("{0} Editor of {1}", 
				this.editedType != null ? this.editedType.GetTypeCSCodeName(true) : "null", 
				this.editedMember != null ? this.editedMember.Name : "null");
		}
		
		/// <summary>
		/// Determines the most specific shared Type of all the specified objects.
		/// The specified static Type will be used as a shared fallback, if no other
		/// common root is found.
		/// </summary>
		/// <param name="staticType"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		protected static Type ReflectDynamicType(Type staticType, IEnumerable<object> values)
		{
			return ReflectDynamicType(staticType, values.Where(v => v != null).Select(v => v.GetType()));
		}
		/// <summary>
		/// Determines the most specific shared Type of all the specified Types.
		/// The specified static Type will be used as a shared fallback, if no other
		/// common root is found.
		/// </summary>
		/// <param name="staticType"></param>
		/// <param name="dynamicTypes"></param>
		/// <returns></returns>
		protected static Type ReflectDynamicType(Type staticType, IEnumerable<Type> dynamicTypes)
		{
			if (staticType.IsSealed) return staticType;
			if (!staticType.IsClass && !staticType.IsInterface) return staticType;

			Type commonBaseType = dynamicTypes.GetCommonBaseClass();
			if (staticType.IsDerivedFrom(commonBaseType) || (staticType.IsInterface && commonBaseType == typeof(object)))
				return staticType;
			else
				return commonBaseType;
		}
	}
}
