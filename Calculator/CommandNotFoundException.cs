using System;

namespace SuperCalculator
{
	public class CommandNotFoundException : Exception
	{
		private string command;
		private string args;

		public CommandNotFoundException(string command) : base() {
			this.command = command;
			this.args = args;
		}

		public override string ToString() {
			return "Command \"" + this.command + "\" not found";
		}
	}
}

