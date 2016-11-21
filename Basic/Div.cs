using System;
using System.Linq;

using Command;

namespace Commands
{
	public class Div : Basic
	{
		// See Add.cs
		public Div() {}

		public Div(string args) : base(args,(a,b) => a/b) {
			if (this.values.Skip(1).Any((a) => a == 0)) {
				throw new InvalidArgumentException(" positive or negative b", " b = 0 ");
			}
		}
	}
}

