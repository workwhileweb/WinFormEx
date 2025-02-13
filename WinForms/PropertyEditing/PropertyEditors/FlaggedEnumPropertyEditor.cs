using System;
using System.Linq;

namespace AdamsLair.WinForms.PropertyEditing.PropertyEditors
{
	public class FlaggedEnumPropertyEditor : BitmaskPropertyEditor
	{
		public override object DisplayedValue
		{
			get { return Enum.ToObject(this.EditedType, Convert.ChangeType(this.BitmaskValue, Enum.GetUnderlyingType(this.EditedType))); }
		}
		protected override void OnEditedTypeChanged()
		{
			base.OnEditedTypeChanged();
			this.Items = Enum.GetNames(this.EditedType).Select(n => 
				new BitmaskItem((ulong)Convert.ToUInt64(Enum.Parse(this.EditedType, n)), n));
		}
	}
}
