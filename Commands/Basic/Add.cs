using System;

namespace SuperCalculator.Commands
{
	public class Add : Basic
	{
		public Add(string args) : base(args, (a, b) => a + b) {
		}
	}
}

