using System;

namespace Commands
{
	public class Mul : Basic
	{
		// See Add.cs 
		public Mul() {}

		public Mul(string args) : base(args, (a, b) => a * b) {
		}
	}
}


