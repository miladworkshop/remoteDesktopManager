using System.Collections.Generic;
using System.Windows.Forms;
using mRemoteNG.UI.Hotkeys;
using NSubstitute;
using NUnit.Framework;

namespace mRemoteNGTests.UI.Hotkeys
{
	public class HotkeyHandlerTests
	{
		private HotkeyHandler _hotkeyHandler;
		private IDictionary<Keys, ICommand> _configuredHotkeys;

		[OneTimeSetUp]
		public void Setup()
		{
			_configuredHotkeys = new Dictionary<Keys, ICommand>();
			_hotkeyHandler = new HotkeyHandler(_configuredHotkeys);
		}

		[Test]
		public void CommandCalledWhenRegisteredHotkeyPressed()
		{
			var mockCommand = Substitute.For<ICommand>();
			_configuredHotkeys.Add(Keys.A, mockCommand);
			_hotkeyHandler.HandleHotkeyPressed(Keys.A);
			mockCommand.Received(1).Execute();
		}

		[Test]
		public void CommandNotCalledWhenDifferentHotkeyPressed()
		{
			var mockCommand1 = Substitute.For<ICommand>();
			var mockCommand2 = Substitute.For<ICommand>();
			_configuredHotkeys.Add(Keys.A, mockCommand1);
			_configuredHotkeys.Add(Keys.B, mockCommand2);
			_hotkeyHandler.HandleHotkeyPressed(Keys.A);
			mockCommand2.DidNotReceive().Execute();
		}
	}
}
