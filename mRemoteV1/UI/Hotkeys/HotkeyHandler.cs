using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mRemoteNG.UI.Hotkeys
{
	public class HotkeyHandler
	{
		private readonly IDictionary<Keys, ICommand> _configuredHotkeys;

		public HotkeyHandler(IDictionary<Keys, ICommand> configuredHotkeys)
		{
			if (configuredHotkeys == null)
				throw new ArgumentNullException(nameof(configuredHotkeys));

			_configuredHotkeys = configuredHotkeys;
		}

		/// <summary>
		/// Executes the command associated with a key-press.
		/// </summary>
		/// <param name="keyPressed">
		/// The key that was pressed.
		/// </param>
		public void HandleHotkeyPressed(Keys keyPressed)
		{
			if (!_configuredHotkeys.ContainsKey(keyPressed))
				return;

			_configuredHotkeys[keyPressed].Execute();
		}

		/// <summary>
		/// Executes the command associated with a key-press.
		/// This overload is for convenient event handling.
		/// Use <see cref="HandleHotkeyPressed(Keys)"/> for general use.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		public void HandleHotkeyPressed(object sender, KeyEventArgs args)
		{
			if (!_configuredHotkeys.ContainsKey(args.KeyData))
				return;

			HandleHotkeyPressed(args.KeyData);
			args.Handled = true;
		}
	}
}
