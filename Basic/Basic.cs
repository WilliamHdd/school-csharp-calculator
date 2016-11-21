using System;
using System.Linq;
using Command;

namespace Commands
{
	// This is a base class for basic operations on a sequence of numbers.
	public abstract class Basic : Command<double>
	{
		protected double[] values;
		protected Func<double, double, double> operation;

		public Basic() {}

		// The string is parsed as a sequence of numbers separated by a space.
		// The constructor also takes a function to apply to the sequence when
		// executing (e.g. Addition between two numbers)
		public Basic(string args, Func<double, double, double> operation) {
			this.values = args.Trim()
				.Split(' ')
				.Select(s => Double.Parse(s))
				.ToArray();

			this.operation = operation;
		}

		// When executing, the operation given in the constructor will be applied
		// over and over until the sequence has been reduced to one result.
		public override double Execute() {
			return this.values.Aggregate(this.operation);
		}
	}
}

