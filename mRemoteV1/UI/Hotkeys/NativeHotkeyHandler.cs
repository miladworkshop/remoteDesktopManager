using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using mRemoteNG.App;

namespace mRemoteNG.UI.Hotkeys
{
	/// <summary>
	/// Class to handle global Windows hotkeys.
	/// Partially taken from https://stackoverflow.com/questions/2450373/set-global-hotkeys-using-c-sharp
	/// </summary>
	public class NativeHotkeyHandler
	{
		private int _currentId;
		private readonly IWin32Window _window;
		private readonly List<NativeHotkey> _registeredHotkeys = new List<NativeHotkey>();

		public NativeHotkeyHandler(IWin32Window window)
		{
			_window = window;
		}

		public void HandleKeyPress(Keys key)
		{
			if (_registeredHotkeys.All(hotkey => hotkey.Hotkey != key))
				return;

			_registeredHotkeys.First(hotkey => hotkey.Hotkey == key).Command.Execute();
		}

		/// <summary>
		/// Registers a hot key in the system.
		/// </summary>
		/// <param name="modifier">The modifiers that are associated with the hot key.</param>
		/// <param name="key">The key itself that is associated with the hot key.</param>
		public void RegisterHotkey(Keys key, ICommand command)
		{
			if (_registeredHotkeys.Any(hotkey => hotkey.Hotkey == key))
				return;

			// increment the counter.
			_currentId++;
			_registeredHotkeys.Add(new NativeHotkey(_currentId, key, command));

			var modifier = GetModifierKeyFromKeys(key);
			var keyCode = GetBaseKeyFromKeys(key);

			// register the hot key.
			if (!NativeMethods.RegisterHotKey(_window.Handle, _currentId, (uint) modifier, (uint) keyCode))
				throw new InvalidOperationException("Couldn’t register the hot key.");
		}

		public void UnregisterHotkey(Keys key)
		{
			var hotkeyToUnregister = _registeredHotkeys.FirstOrDefault(hotkey => hotkey.Hotkey == key);
			if (hotkeyToUnregister == null)
				return;

			_registeredHotkeys.Remove(hotkeyToUnregister);
			NativeMethods.UnregisterHotKey(_window.Handle, hotkeyToUnregister.NativeHotkeyId);
			_currentId--;
		}

		private ModifierKeys GetModifierKeyFromKeys(Keys key)
		{
			return (ModifierKeys) (((int) key & 0xFFFF0000) >> 16);
		}

		private Keys GetBaseKeyFromKeys(Keys key)
		{
			return (Keys) ((int) key & 0x0000FFFF);
		}

		private class NativeHotkey
		{
			public int NativeHotkeyId { get; }
			public Keys Hotkey { get; }
			public ICommand Command { get; }

			public NativeHotkey(int id, Keys key, ICommand command)
			{
				NativeHotkeyId = id;
				Hotkey = key;
				Command = command;
			}
		}
	}
}