using System;
namespace Commands
{
	public class Ln : Extended
	{
		public Ln() { }
		public Ln(string args) : base(args) { }

		public override double Execute() {
			return Math.Log(this.data);

		}
	}
}