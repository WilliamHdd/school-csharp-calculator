using System;

namespace SuperCalculator.Commands
{
	public class Add : Basic
	{
		// All the logic is implemented in the operation generic parent class
		// we just have to forward the argument and define the transformation
		// in this case, just addition between two numbers.
		public Add(string args) : base(args, (a, b) => a + b) {
		}
	}
}

