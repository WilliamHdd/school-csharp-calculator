using System;
using System.Linq;

namespace SuperCalculator.Commands
{
	public abstract class Basic : Command<double>
	{
		protected double[] values;
		protected Func<double, double, double> operation;

		public Basic(string args, Func<double, double, double> operation) {
			this.values = args.Trim()
							  .Split(' ')
							  .Select(s => Double.Parse(s))
							  .ToArray();

			this.operation = operation;
		}

		public override double Execute() {
			return this.values.Aggregate(this.operation);
		}
	}
}

