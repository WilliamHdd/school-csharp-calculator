using System;

namespace Commands
{
	public class Sqrt : Extended
	{
		public Sqrt() { }
		public Sqrt(string args) : base(args) { }

		public override double Execute() {

			if (this.data > 0) {
				return Math.Sqrt(this.data);
			} else { throw new Command.InvalidArgumentException("possitive integer", "nul or negative integer "); }

		}
	}
}