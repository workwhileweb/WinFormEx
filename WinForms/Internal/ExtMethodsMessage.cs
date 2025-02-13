using System.Windows.Forms;

namespace AdamsLair.WinForms.Internal
{
	internal static class ExtMethodsMessage
	{
		public static WindowMessage GetWindowMessage(this Message msg)
		{
			return (WindowMessage)msg.Msg;
		}
	}
}
