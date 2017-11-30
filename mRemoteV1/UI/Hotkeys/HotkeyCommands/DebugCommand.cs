using System.Diagnostics;

namespace mRemoteNG.UI.Hotkeys.HotkeyCommands
{
	public class DebugCommand : ICommand
	{
		public void Execute()
		{
			Debug.WriteLine("Key pressed!");
		}
	}
}
