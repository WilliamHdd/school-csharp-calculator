using System;

namespace Commands
{
	public class Exp : Extended
	{
		public Exp(){}

		public Exp(string args) : base(args) { }

		public override double Execute() {
			return Math.Exp(this.data);

		}
	}
}