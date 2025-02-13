﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using AdamsLair.WinForms.Internal;

namespace AdamsLair.WinForms.PropertyEditing
{
	public class MemberwisePropertyEditor : GroupedPropertyEditor
	{
		public delegate bool AutoMemberPredicate(MemberInfo member, bool showNonPublic);
		public delegate void PropertyValueSetter(PropertyInfo property, IEnumerable<object> targetObjects, IEnumerable<object> values);
		public delegate void FieldValueSetter(FieldInfo field, IEnumerable<object> targetObjects, IEnumerable<object> values);

		private	bool	buttonIsCreate	= false;
		private	AutoMemberPredicate				memberPredicate			= null;
		private	Predicate<MemberInfo>			memberAffectsOthers		= null;
		private	PropertyValueSetter				memberPropertySetter	= null;
		private	FieldValueSetter				memberFieldSetter		= null;

		public override object DisplayedValue
		{
			get { return this.GetValue().FirstOrDefault(); }
		}
		public AutoMemberPredicate MemberPredicate
		{
			get { return this.memberPredicate; }
			set
			{
				if (value == null) value = DefaultMemberPredicate;
				if (this.memberPredicate != value)
				{
					this.memberPredicate = value;
					if (this.ContentInitialized) this.InitContent();
				}
			}
		}
		public Predicate<MemberInfo> MemberAffectsOthers
		{
			get { return this.memberAffectsOthers; }
			set
			{
				if (value == null) value = DefaultMemberAffectsOthers;
				if (this.memberAffectsOthers != value)
				{
					this.memberAffectsOthers = value;
					if (this.ContentInitialized) this.InitContent();
				}
			}
		}
		public PropertyValueSetter MemberPropertySetter
		{
			get { return this.memberPropertySetter; }
			set
			{
				if (value == null) value = DefaultPropertySetter;
				this.memberPropertySetter = value;
			}
		}
		public FieldValueSetter MemberFieldSetter
		{
			get { return this.memberFieldSetter; }
			set
			{
				if (value == null) value = DefaultFieldSetter;
				this.memberFieldSetter = value;
			}
		}

		public MemberwisePropertyEditor()
		{
			this.Hints |= HintFlags.HasButton | HintFlags.ButtonEnabled;
			this.memberPredicate = DefaultMemberPredicate;
			this.memberAffectsOthers = DefaultMemberAffectsOthers;
			this.memberPropertySetter = DefaultPropertySetter;
			this.memberFieldSetter = DefaultFieldSetter;
		}

		public override void InitContent()
		{
			this.BeginUpdate();
			{
				// Clear previous contents and invoke base method
				this.ClearContent();
				base.InitContent();

				// Generate and add property editors for the current type
				if (this.EditedType != null)
				{
					IEnumerable<object> valueQuery = this.GetValue();
					object[] values = (valueQuery != null ? valueQuery.ToArray() : null);
					this.BeforeAutoCreateEditors();
					foreach (MemberInfo member in this.QueryEditedMembers())
					{
						this.AddEditorForMember(member, values);
					}
				}
			}
			this.EndUpdate();

			// Update all values for this editor and its children
			this.PerformGetValue();
		}
		protected void ReInitContent(IEnumerable<PropertyEditor> updateEditors)
		{
			if (this.EditedType == null) return;

			this.BeginUpdate();
			{
				object[] values = this.GetValue().ToArray();
				foreach (PropertyEditor editor in updateEditors)
				{
					this.AddEditorForMember(editor.EditedMember, values, editor);
				}
			}
			this.EndUpdate();

			// Update all values for this editor and its children
			this.PerformGetValue();
		}

		public PropertyEditor AddEditorForMember(MemberInfo member, IEnumerable<object> values = null, PropertyEditor replaceOld = null)
		{
			if (!(member is FieldInfo) && !(member is PropertyInfo))
			{
				throw new ArgumentException("Only PropertyInfo and FieldInfo members are supported");
			}

			PropertyEditor e;
			Type editType = ReflectTypeForMember(member, values ?? this.GetValue());
			e = this.AutoCreateMemberEditor(member);
			if (e == null) e = this.ParentGrid.CreateEditor(editType, this);
			if (e == null) return null;

			e.BeginUpdate();
			{
				if (member is PropertyInfo)
				{
					PropertyInfo property = member as PropertyInfo;
					e.Getter = this.CreatePropertyValueGetter(property);
					e.Setter = property.CanWrite ? this.CreatePropertyValueSetter(property) : null;
					e.PropertyName = property.Name;
					e.EditedMember = property;
					e.NonPublic = !this.memberPredicate(property, false);
				}
				else if (member is FieldInfo)
				{
					FieldInfo field = member as FieldInfo;
					e.Getter = this.CreateFieldValueGetter(field);
					e.Setter = this.CreateFieldValueSetter(field);
					e.PropertyName = field.Name;
					e.EditedMember = field;
					e.NonPublic = !this.memberPredicate(field, false);
				}

				if (replaceOld != null)
				{
					this.AddPropertyEditor(e, replaceOld);
					this.RemovePropertyEditor(replaceOld);
					replaceOld.Dispose();
				}
				else
				{
					this.AddPropertyEditor(e);
				}
				this.ParentGrid.ConfigureEditor(e);
			}
			e.EndUpdate();

			return e;
		}
		protected override void VerifyReflectedTypeEditors(IEnumerable<object> values)
		{
			if (this.EditedType == null) return;
			if (!this.ContentInitialized) return;

			List<PropertyEditor> invalidEditors = null;
			foreach (PropertyEditor editor in this.ChildEditors)
			{
				if (editor.EditedMember == null) continue;
				if (editor.EditedType == null) continue;
				if (!this.IsAutoCreateMember(editor.EditedMember)) continue;

				Type reflectedType = this.ReflectTypeForMember(editor.EditedMember, values);
				if (reflectedType != editor.EditedType)
				{
					if (invalidEditors == null) invalidEditors = new List<PropertyEditor>();
					invalidEditors.Add(editor);
				}
			}

			if (invalidEditors != null)
			{
				this.ReInitContent(invalidEditors);
			}
		}
		/// <summary>
		/// Determines the Type to use as a basis for generating a PropertyEditor for the specified member
		/// by evaluating the members current value and static Type.
		/// </summary>
		/// <param name="member"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		protected Type ReflectTypeForMember(MemberInfo member, IEnumerable<object> values)
		{
			if (member is FieldInfo)
			{
				FieldInfo field = member as FieldInfo;
				if (values != null)
					return PropertyEditor.ReflectDynamicType(field.FieldType, values.Where(v => v != null).Select(v => field.GetValue(v)));
				else
					return field.FieldType;
			}
			else if (member is PropertyInfo)
			{
				PropertyInfo property = member as PropertyInfo;
				if (values != null)
				{
					List<object> propertyValues = new List<object>();
					foreach (object obj in values)
					{
						if (obj == null) continue;
						try
						{
							object value = property.GetValue(obj, null);
							propertyValues.Add(value);
						}
						catch (TargetInvocationException) { }
					}
					return PropertyEditor.ReflectDynamicType(property.PropertyType, propertyValues);
				}
				else
				{
					return property.PropertyType;
				}
			}
			else
				throw new ArgumentException("Only PropertyInfo and FieldInfo members are supported");
		}

		protected IEnumerable<MemberInfo> QueryEditedMembers()
		{
			PropertyInfo[] propArr = this.EditedType.GetProperties(
				BindingFlags.Instance | 
				BindingFlags.Public | 
				BindingFlags.NonPublic);
			FieldInfo[] fieldArr = this.EditedType.GetFields(
				BindingFlags.Instance | 
				BindingFlags.Public | 
				BindingFlags.NonPublic);

			if (ParentGrid.SortEditorsByName)
			{
				return (

					from p in propArr
					where p.CanRead && p.GetIndexParameters().Length == 0 && this.IsAutoCreateMember(p)
					orderby GetTypeHierarchyLevel(p.DeclaringType) ascending, p.Name
					select p

					).Concat((IEnumerable<MemberInfo>)

					from f in fieldArr
					where this.IsAutoCreateMember(f)
					orderby GetTypeHierarchyLevel(f.DeclaringType) ascending, f.Name
					select f

					);
			}
			else
			{
				return (

					from p in propArr
					where p.CanRead && p.GetIndexParameters().Length == 0 && this.IsAutoCreateMember(p)
					orderby GetTypeHierarchyLevel(p.DeclaringType) ascending
					select p

					).Concat((IEnumerable<MemberInfo>)

					from f in fieldArr
					where this.IsAutoCreateMember(f)
					orderby GetTypeHierarchyLevel(f.DeclaringType) ascending
					select f

					);
			}
		}
		protected IEnumerable<FieldInfo> QueryEditedFields()
		{
			FieldInfo[] fieldArr = this.EditedType.GetFields(
				BindingFlags.Instance | 
				BindingFlags.Public | 
				BindingFlags.NonPublic);
			return
				from f in fieldArr
				where this.IsAutoCreateMember(f)
				orderby GetTypeHierarchyLevel(f.DeclaringType) ascending, f.Name
				select f;
		}

		protected override void OnGetValue()
		{
			base.OnGetValue();
			IEnumerable<object> valueQuery = this.GetValue();
			object[] values = (valueQuery != null ? valueQuery.ToArray() : null);

			this.VerifyReflectedTypeEditors(values);
			this.BeginUpdate();
			if (values == null)
			{
				this.HeaderValueText = null;
				return;
			}
			this.OnUpdateFromObjects(values);
			this.EndUpdate();

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
		protected virtual void OnUpdateFromObjects(object[] values)
		{
			string valString = null;

			if (values == null || !values.Any() || values.All(o => o == null))
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
				this.Hints |= HintFlags.ExpandEnabled;
				if (!this.CanExpand) this.Expanded = false;
				this.ButtonIcon = AdamsLair.WinForms.Properties.ResourcesCache.ImageDelete;
				this.buttonIsCreate = false;

				object firstValue = values.First();
				int valueCount = values.Count();

				if (valueCount == 1 && firstValue != null)
				{
					Type displayedType = firstValue.GetType();
					MethodInfo[] methods = displayedType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
					bool customToStringImplementation = methods.Any(m => m.DeclaringType != typeof(object) && m.Name == "ToString");

					if (customToStringImplementation)
						valString = firstValue.ToString();
					else
						valString = displayedType.GetTypeCSCodeName(true);
				}
				else
				{
					valString = string.Format(
						Properties.Resources.PropertyGrid_N_Objects, 
						valueCount);
				}
			}

			this.HeaderValueText = valString;
		}
		protected override void OnEditedTypeChanged()
		{
			base.OnEditedTypeChanged();
			if (this.EditedType.IsValueType)
				this.Hints &= ~HintFlags.HasButton;
			else
				this.Hints |= HintFlags.HasButton;
			if (this.ContentInitialized) this.InitContent();
		}
		protected override void OnEditedMemberChanged()
		{
			base.OnEditedTypeChanged();
			if (this.ContentInitialized) this.InitContent();
		}
		protected override void OnButtonPressed()
		{
			base.OnButtonPressed();
			if (this.EditedType.IsValueType)
			{
				this.SetValue(this.ParentGrid.CreateObjectInstance(this.EditedType));
			}
			else
			{
				if (this.buttonIsCreate)
				{
					int objectsToCreate = this.GetValue().Count();
					object[] createdObjects = new object[objectsToCreate];
					for (int i = 0; i < createdObjects.Length; i++)
					{
						createdObjects[i] = this.ParentGrid.CreateObjectInstance(this.EditedType);
					}
					this.SetValues(createdObjects);
					this.Expanded = true;
				}
				else
				{
					this.SetValue(null);
				}
			}

			this.PerformGetValue();
		}

		protected virtual void BeforeAutoCreateEditors() {}
		protected virtual bool IsAutoCreateMember(MemberInfo info)
		{
			return this.memberPredicate(info, this.ParentGrid.ShowNonPublic);
		}
		protected virtual PropertyEditor AutoCreateMemberEditor(MemberInfo info)
		{
			return null;
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

		protected Func<IEnumerable<object>> CreatePropertyValueGetter(PropertyInfo property)
		{
			return () =>
			{
				List<object> propertyValues = new List<object>();
				foreach (object obj in this.GetValue())
				{
					if (obj == null)
					{
						propertyValues.Add(null);
					}
					else
					{
						try
						{
							object value = property.GetValue(obj, null);
							propertyValues.Add(value);
						}
						catch (TargetInvocationException)
						{
							propertyValues.Add(null);
						}
					}
				}
				return propertyValues;
			};
		}
		protected Func<IEnumerable<object>> CreateFieldValueGetter(FieldInfo field)
		{
			return () => this.GetValue().Select(o => o != null ? field.GetValue(o) : null);
		}
		protected Action<IEnumerable<object>> CreatePropertyValueSetter(PropertyInfo property)
		{
			bool affectsOthers = this.ParentGrid.ShowNonPublic || this.memberAffectsOthers(property);
			return delegate(IEnumerable<object> values)
			{
				object[] targetArray = this.GetValue().ToArray();

				// Set value
				this.memberPropertySetter(property, targetArray, values);

				// Fixup struct values by assigning the modified struct copy to its original member
				if (this.EditedType.IsValueType || this.ForceWriteBack) this.SetValues((IEnumerable<object>)targetArray);

				this.OnPropertySet(property, targetArray);
				if (affectsOthers)
					this.PerformGetValue();
				else
					this.OnUpdateFromObjects(this.GetValue().ToArray());
			};
		}
		protected Action<IEnumerable<object>> CreateFieldValueSetter(FieldInfo field)
		{
			bool affectsOthers = this.ParentGrid.ShowNonPublic || this.memberAffectsOthers(field);
			return delegate(IEnumerable<object> values)
			{
				object[] targetArray = this.GetValue().ToArray();

				// Set value
				this.memberFieldSetter(field, targetArray, values);

				// Fixup struct values by assigning the modified struct copy to its original member
				if (this.EditedType.IsValueType || this.ForceWriteBack) this.SetValues((IEnumerable<object>)targetArray);

				this.OnFieldSet(field, targetArray);
				if (affectsOthers)
					this.PerformGetValue();
				else
					this.OnUpdateFromObjects(this.GetValue().ToArray());
			};
		}

		protected virtual void OnPropertySet(PropertyInfo property, IEnumerable<object> targets) {}
		protected virtual void OnFieldSet(FieldInfo property, IEnumerable<object> targets) {}

		protected static bool DefaultMemberPredicate(MemberInfo info, bool showNonPublic)
		{
			if (showNonPublic)
			{
				return true;
			}
			else if (info is PropertyInfo)
			{
				PropertyInfo property = info as PropertyInfo;
				MethodInfo getter = property.GetGetMethod(true);
				return getter != null && getter.IsPublic;
			}
			else if (info is FieldInfo)
			{
				FieldInfo field = info as FieldInfo;
				return field.IsPublic;
			}
			else
			{
				return false;
			}
		}
		protected static bool DefaultMemberAffectsOthers(MemberInfo info)
		{
			return false;
		}
		protected static void DefaultPropertySetter(PropertyInfo property, IEnumerable<object> targetObjects, IEnumerable<object> values)
		{
			IEnumerator<object> valuesEnum = values.GetEnumerator();
			object curValue = null;

			if (valuesEnum.MoveNext()) curValue = valuesEnum.Current;
			foreach (object target in targetObjects)
			{
				if (target != null)
				{
					try
					{
						property.SetValue(target, curValue, null);
					}
					catch (TargetInvocationException) { }
				}
				if (valuesEnum.MoveNext()) curValue = valuesEnum.Current;
			}
		}
		protected static void DefaultFieldSetter(FieldInfo field, IEnumerable<object> targetObjects, IEnumerable<object> values)
		{
			IEnumerator<object> valuesEnum = values.GetEnumerator();
			object curValue = null;

			if (valuesEnum.MoveNext()) curValue = valuesEnum.Current;
			foreach (object target in targetObjects)
			{
				if (target != null) field.SetValue(target, curValue);
				if (valuesEnum.MoveNext()) curValue = valuesEnum.Current;
			}
		}

		private static int GetTypeHierarchyLevel(Type t)
		{
			int level = 0;
			while (t.BaseType != null) { t = t.BaseType; level++; }
			return level;
		}
	}
}
