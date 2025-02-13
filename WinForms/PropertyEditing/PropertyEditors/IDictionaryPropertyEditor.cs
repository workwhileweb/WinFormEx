﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AdamsLair.WinForms.Internal;
using IDictionary = System.Collections.IDictionary;

namespace AdamsLair.WinForms.PropertyEditing.PropertyEditors
{
	public class IDictionaryPropertyEditor : GroupedPropertyEditor
	{
		public delegate void KeyValueSetter(PropertyInfo property, IEnumerable<object> targetObjects, IEnumerable<object> values, object key);
		public delegate void KeyAdder(IEnumerable<IDictionary> targetDictionaries, object key, Type valueType);
		public delegate void KeyRemover(IEnumerable<IDictionary> targetDictionaries, object key);

		private	bool					buttonIsCreate		= false;
		private	PropertyEditor			addKeyEditor		= null;
		private	object					addKey				= null;
		private	NumericPropertyEditor	offsetEditor		= null;
		private	int						offset				= 0;
		private	int						internalEditors		= 0;
		private	KeyValueSetter			dictKeySetter		= null;
		private KeyAdder				dictKeyAdder		= null;
		private KeyRemover				dictKeyRemover		= null;
		private	object[]				displayedKeys		= null;

		public override object DisplayedValue
		{
			get { return this.GetValue(); }
		}
		public KeyValueSetter DictionaryKeySetter
		{
			get { return this.dictKeySetter; }
			set
			{
				if (value == null) value = DefaultPropertySetter;
				this.dictKeySetter = value;
			}
		}
		public KeyAdder DictionKeyAdder
		{
			get { return this.dictKeyAdder; }
			set
			{
				if (value == null) value = DefaultKeyAdder;
				this.dictKeyAdder = value;
			}
		}
		public KeyRemover DictionKeyRemover
		{
			get { return this.dictKeyRemover; }
			set
			{
				if (value == null) value = DefaultKeyRemover;
				this.dictKeyRemover = value;
			}
		}

		public IDictionaryPropertyEditor()
		{
			this.Hints |= HintFlags.HasButton | HintFlags.ButtonEnabled;
			this.dictKeySetter = DefaultPropertySetter;
			this.dictKeyAdder = DefaultKeyAdder;
			this.dictKeyRemover = DefaultKeyRemover;

			this.offsetEditor = new NumericPropertyEditor();
			this.offsetEditor.EditedType = typeof(int);
			this.offsetEditor.Minimum = 0;
			this.offsetEditor.PropertyName = "Offset";
			this.offsetEditor.Getter = this.OffsetValueGetter;
			this.offsetEditor.Setter = this.OffsetValueSetter;
			this.offsetEditor.ValueMutable = true;
		}

		public override void InitContent()
		{
			base.InitContent();

			if (this.EditedType != null)
			{
				Type keyType = GetIDictionaryKeyType(this.EditedType);
				this.addKeyEditor = this.ParentGrid.CreateEditor(keyType, this);
				this.addKeyEditor.Hints |= HintFlags.HasButton | HintFlags.ButtonEnabled;
				this.addKeyEditor.ButtonIcon = Properties.ResourcesCache.ImageAdd;
				this.addKeyEditor.EditedType = keyType;
				this.addKeyEditor.PropertyName = "Add Entry";
				this.addKeyEditor.Getter = this.AddKeyValueGetter;
				this.addKeyEditor.Setter = this.AddKeyValueSetter;
				this.addKeyEditor.ButtonPressed += this.AddKeyButtonPressed;
				this.addKeyEditor.EditingFinished += this.AddKeyEditingFinished;

				this.PerformGetValue();
			}
			else
				this.ClearContent();
		}
		public override void ClearContent()
		{
			base.ClearContent();
			if (this.addKeyEditor != null)
			{
				this.addKeyEditor.ButtonPressed -= this.AddKeyButtonPressed;
				this.addKeyEditor.EditingFinished -= this.AddKeyEditingFinished;
				this.addKeyEditor = null;
			}
			this.offset = 0;
		}

		protected override void OnGetValue()
		{
			base.OnGetValue();
			IDictionary[] values = this.GetValue().Cast<IDictionary>().ToArray();

			string valString = null;
			if (!values.Any() || values.All(o => o == null))
			{
				this.ClearContent();

				this.Hints &= ~HintFlags.ExpandEnabled;
				this.ButtonIcon = AdamsLair.WinForms.Properties.ResourcesCache.ImageAdd;
				this.buttonIsCreate = true;
				this.Expanded = false;
					
				valString = "null";
			}
			else
			{
				if (this.ContentInitialized)
				{
					if (this.Expanded)
						this.UpdateElementEditors(values, false);
					else
						this.ClearContent();
				}
				
				this.Hints |= HintFlags.ExpandEnabled;
				if (!this.CanExpand) this.Expanded = false;
				this.ButtonIcon = AdamsLair.WinForms.Properties.ResourcesCache.ImageDelete;
				this.buttonIsCreate = false;
				
				IDictionary firstValue = values.First();
				int valueCount = values.Count();
				
				if (valueCount == 1 && firstValue != null)
				{
					valString = string.Format(
						"{0}, Count = {1}", 
						this.EditedType.GetTypeCSCodeName(true), 
						firstValue.Count);
				}
				else
				{
					valString = string.Format(
						Properties.Resources.PropertyGrid_N_Objects, 
						valueCount);
				}
			}

			this.HeaderValueText = valString;

			foreach (PropertyEditor e in this.ChildEditors)
				e.PerformGetValue();
		}
		protected override void OnSetValue()
		{
			if (this.ReadOnly) return;
			if (!this.ChildEditors.Any()) return;
			base.OnSetValue();

			foreach (PropertyEditor e in this.ChildEditors)
				e.PerformSetValue();
		}
		protected override void VerifyReflectedTypeEditors(IEnumerable<object> values)
		{
			base.VerifyReflectedTypeEditors(values);
			if (!this.ContentInitialized) return;
			if (!this.Expanded) return;

			IDictionary[] valuesCast = this.GetValue().Cast<IDictionary>().ToArray();
			if (values.Any() && values.Any(o => o != null))
			{
				this.UpdateElementEditors(valuesCast, true);
			}
		}
		
		protected void UpdateElementEditors(IDictionary[] values, bool getValueOnNewEditors)
		{
			PropertyInfo indexer = typeof(IDictionary).GetProperty("Item");
			IEnumerable<IDictionary> valuesNotNull = values.Where(v => v != null);
			int visibleElementCount = valuesNotNull.Min(o => (int)o.Count);
			bool showOffset = false;
			if (visibleElementCount > 10)
			{
				this.offset = Math.Min(this.offset, visibleElementCount - 10);
				this.offsetEditor.Maximum = visibleElementCount - 10;
				this.offsetEditor.ValueBarMaximum = this.offsetEditor.Maximum;
				visibleElementCount = 10;
				showOffset = true;
			}
			else
			{
				this.offset = 0;
			}

			if (this.addKeyEditor.ParentEditor == null) this.AddPropertyEditor(this.addKeyEditor, 0);
			if (showOffset && this.offsetEditor.ParentEditor == null) this.AddPropertyEditor(this.offsetEditor, 1);
			else if (!showOffset && this.offsetEditor.ParentEditor != null) this.RemovePropertyEditor(this.offsetEditor);

			this.internalEditors = showOffset ? 2 : 1;
			
			// Determine which keys are currently displayed
			int elemIndex = 0;
			this.displayedKeys = new object[visibleElementCount];
			foreach (object key in valuesNotNull.First().Keys)
			{
				if (elemIndex >= this.offset + visibleElementCount) break;
				if (elemIndex >= this.offset)
				{
					this.displayedKeys[elemIndex - this.offset] = key;
				}
				elemIndex++;
			}

			this.BeginUpdate();

			// Add missing editors
			Type dictValueType = GetIDictionaryValueType(this.EditedType);
			Type reflectedDictValueType = PropertyEditor.ReflectDynamicType(dictValueType, valuesNotNull.Select(a => GetIDictionaryValueType(a.GetType())));
			for (int i = this.internalEditors; i < visibleElementCount + this.internalEditors; i++)
			{
				object elementKey = this.displayedKeys[i - this.internalEditors];
				Type reflectedElementValueType = PropertyEditor.ReflectDynamicType(
					reflectedDictValueType, 
					valuesNotNull.Select(v => indexer.GetValue(v, new object[] { elementKey })));
				bool elementEditorIsNew = false;
				PropertyEditor elementEditor;

				// Retrieve and Update existing editor
				if (i < this.ChildEditors.Count())
				{
					elementEditor = this.ChildEditors.ElementAt(i);
					if (elementEditor.EditedType != reflectedElementValueType)
					{
						// If the editor has the wrong type, we'll need to create a new one
						PropertyEditor oldEditor = elementEditor;
						elementEditor = this.ParentGrid.CreateEditor(reflectedElementValueType, this);
						elementEditorIsNew = true;
						
						this.AddPropertyEditor(elementEditor, oldEditor);
						this.RemovePropertyEditor(oldEditor);
						this.ParentGrid.ConfigureEditor(elementEditor);
					}
				}
				// Create a new editor
				else
				{
					elementEditor = this.ParentGrid.CreateEditor(reflectedElementValueType, this);
					elementEditorIsNew = true;

					this.AddPropertyEditor(elementEditor);
					this.ParentGrid.ConfigureEditor(elementEditor);

					if (!elementEditor.Hints.HasFlag(HintFlags.HasButton))
					{
						elementEditor.Hints |= HintFlags.HasButton | HintFlags.ButtonEnabled;
						elementEditor.ButtonPressed += this.elementEditor_ButtonPressed;
					}
				}
				elementEditor.Getter = this.CreateElementValueGetter(indexer, elementKey);
				elementEditor.Setter = this.CreateElementValueSetter(indexer, elementKey);
				elementEditor.PropertyName = "[" + elementKey.ToString() + "]";

				// Immediately retrieve a valid value for the newly created editor when requested
				if (elementEditorIsNew && getValueOnNewEditors)
					elementEditor.PerformGetValue();
			}

			// Remove overflowing editors
			for (int i = this.ChildEditors.Count() - (this.internalEditors + 1); i >= visibleElementCount; i--)
			{
				PropertyEditor child = this.ChildEditors.Last();
				this.RemovePropertyEditor(child);
				child.ButtonPressed -= this.elementEditor_ButtonPressed;
			}

			this.EndUpdate();
		}
		
		protected IEnumerable<object> AddKeyValueGetter()
		{
			//if (this.addKey == null) this.addKey = ReflectionHelper.CreateInstanceOf(this.GetKeyType());
			return new object[] { this.addKey };
		}
		protected void AddKeyValueSetter(IEnumerable<object> keys)
		{
			this.addKey = keys.FirstOrDefault();
		}
		protected void AddKeyButtonPressed(object sender, EventArgs e)
		{
			if (this.addKey == null) return;

			// Add new key
			this.AddKeyToDictionary(this.addKey);

			// Focus-Unfocus to trigger some kind of "select all" / "reset" behaivor in the "Add Key" field.
			this.ParentGrid.Focus(this);
			this.addKeyEditor.Focus();

			// Reset add key editor and update sub-editors
			this.addKey = null;
			this.PerformGetValue();
		}
		protected void AddKeyEditingFinished(object sender, PropertyEditingFinishedEventArgs e)
		{
			if (e.Reason == FinishReason.UserAccept)
				AddKeyButtonPressed(sender, e);
		}
		protected IEnumerable<object> OffsetValueGetter()
		{
			yield return this.offset;
		}
		protected void OffsetValueSetter(IEnumerable<object> values)
		{
			this.offset = (int)values.First();
			this.PerformGetValue();
		}
		protected Func<IEnumerable<object>> CreateElementValueGetter(PropertyInfo indexer, object key)
		{
			return () => this.GetValue().Select(o => o != null ? indexer.GetValue(o, new object[] {key}) : null);
		}
		protected Action<IEnumerable<object>> CreateElementValueSetter(PropertyInfo indexer, object key)
		{
			return delegate(IEnumerable<object> values)
			{
				// Explicitly setting the values to null: Remove corresponding source list entry
				if (values.All(v => v == null))
				{
					this.RemoveKeyFromDictionary(key);
					this.PerformGetValue();
				}
				// Assign values
				else
				{
					object[] targetArray = this.GetValue().ToArray();
					this.dictKeySetter(indexer, targetArray, values, key);
					if (this.ForceWriteBack) this.SetValues(targetArray);
				}
			};
		}

		protected override void OnEditedTypeChanged()
		{
			base.OnEditedTypeChanged();
			this.Expanded = false;
			this.ClearContent();
		}
		protected override void OnButtonPressed()
		{
			base.OnButtonPressed();

			if (this.buttonIsCreate)
			{
				bool anyCreated = false;

				int objectsToCreate = this.GetValue().Count();
				IDictionary[] createdObjects = new IDictionary[objectsToCreate];
				for (int i = 0; i < createdObjects.Length; i++)
				{
					createdObjects[i] = this.ParentGrid.CreateObjectInstance(this.EditedType) as IDictionary;
					if (createdObjects[i] != null)
					{
						anyCreated = true;
					}
				}

				if (anyCreated)
				{
					this.SetValues(createdObjects);
					this.Expanded = true;
				}
			}
			else
			{
				this.SetValue(null);
			}

			this.PerformGetValue();
		}

		protected internal override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if ((this.Hints & HintFlags.HasButton) != HintFlags.None &&
				(this.Hints & HintFlags.ButtonEnabled) != HintFlags.None)
			{
				if (!this.buttonIsCreate && e.KeyCode == Keys.Delete)
				{
					this.OnButtonPressed();
					e.Handled = true;
				}
				else if (this.buttonIsCreate && e.KeyCode == Keys.Return)
				{
					this.OnButtonPressed();
					e.Handled = true;
				}
			}
		}

		private void elementEditor_ButtonPressed(object sender, EventArgs e)
		{
			PropertyEditor elementEditor = sender as PropertyEditor;

			// Determine key
			int clickedIndex = -this.internalEditors;
			foreach (PropertyEditor editor in this.ChildEditors)
			{
				if (editor == elementEditor) break;
				clickedIndex++;
			}
			object clickedKey = this.displayedKeys[clickedIndex];

			// Remove key
			this.RemoveKeyFromDictionary(clickedKey);

			// Update sub-editors
			this.PerformGetValue();
		}

		private void AddKeyToDictionary(object key)
		{
			IDictionary[] targetArray = this.GetValue().Cast<IDictionary>().Where(v => v != null).ToArray();
			Type valueType = GetIDictionaryValueType(this.EditedType);
			Type reflectedValueType = PropertyEditor.ReflectDynamicType(valueType, targetArray.Select(a => GetIDictionaryValueType(a.GetType())));

			this.dictKeyAdder(targetArray, key, reflectedValueType);
		}
		private void RemoveKeyFromDictionary(object key)
		{
			IDictionary[] targetArray = this.GetValue().Cast<IDictionary>().Where(v => v != null).ToArray();

			this.dictKeyRemover(targetArray, key);
		}
		
		protected static Type GetIDictionaryValueType(Type dictType)
		{
			Type idictionaryInterface = null;
			if (dictType.IsGenericType && dictType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
				return dictType.GetGenericArguments()[1];
			else if ((idictionaryInterface = dictType.GetInterfaces().Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>)).FirstOrDefault()) != null)
				return idictionaryInterface.GetGenericArguments()[1];
			else
				return typeof(object);
		}
		protected static Type GetIDictionaryKeyType(Type dictType)
		{
			Type idictionaryInterface = null;
			if (dictType.IsGenericType && dictType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
				return dictType.GetGenericArguments()[0];
			else if ((idictionaryInterface = dictType.GetInterfaces().Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>)).FirstOrDefault()) != null)
				return idictionaryInterface.GetGenericArguments()[0];
			else
				return typeof(object);
		}
		protected static void DefaultPropertySetter(PropertyInfo property, IEnumerable<object> targetObjects, IEnumerable<object> values, object key)
		{
			IEnumerator<object> valuesEnum = values.GetEnumerator();
			object curValue = null;

			if (valuesEnum.MoveNext()) curValue = valuesEnum.Current;
			foreach (object target in targetObjects)
			{
				if (target != null) property.SetValue(target, curValue, new object[] {key});
				if (valuesEnum.MoveNext()) curValue = valuesEnum.Current;
			}
		}
		protected static void DefaultKeyAdder(IEnumerable<IDictionary> targetDictionaries, object key, Type valueType)
		{
			foreach (IDictionary target in targetDictionaries)
			{
				if (target != null)
				{
					if (!target.IsFixedSize && !target.IsReadOnly)
					{
						if (!target.Contains(key))
						{
							// Add a new key value pair
							object addedValue = valueType.IsValueType ? valueType.CreateInstanceOf() : null;
							target.Add(key, addedValue);
						}
					}
					else
					{
						// Just some read-only container? Well, can't do anything here.
					}
				}
			}
		}
		protected static void DefaultKeyRemover(IEnumerable<IDictionary> targetDictionaries, object key)
		{
			foreach (IDictionary target in targetDictionaries)
			{
				if (target != null)
				{
					if (!target.IsFixedSize && !target.IsReadOnly)
					{
						if (target.Contains(key))
						{
							target.Remove(key);
						}
					}
					else
					{
						// Just some read-only container? Well, can't do anything here.
					}
				}
			}
		}
	}
}
