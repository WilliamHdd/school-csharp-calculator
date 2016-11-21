using System;

namespace Commands
{
	public class Sub : Basic
	{
		// See Add.cs class
		public Sub() {}

		public Sub(string args) : base(args, (a, b) => a - b) {
		}
	}
}

