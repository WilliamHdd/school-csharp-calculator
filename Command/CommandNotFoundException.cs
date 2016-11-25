using System;

namespace SuperCalculator
{
	public class CommandNotFoundException : Exception
	{
		private string command;

		public CommandNotFoundException(string command) : base() {
			this.command = command;
		}

		public override string ToString() {
			return "Command \"" + this.command + "\" not found";
		}
	}
}

