using System;

namespace SuperCalculator.Commands
{
	public class Sub : Basic
	{
		// See Add.cs class
		public Sub(string args) : base(args, (a, b) => a - b) {
		}
	}
}

