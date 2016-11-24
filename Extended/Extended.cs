using System;
using Command;

namespace Commands

{
	public abstract class Extended : Command<double>
	{
		protected double data;
		public Extended() { }
		public Extended(string arg) {
			arg.Trim();

			try {
				this.data = Double.Parse(arg);
			} catch (FormatException) {
				throw new ArgumentException();
			}
		}

	}
}
