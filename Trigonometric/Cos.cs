using System;

namespace SuperCalculator.Commands
{
	public class Cos : Trigonometric
	{
		// See Sin.cs

		public Cos(string arg) : base(arg) { }

		public override double Execute() {
			if (this.unit == AngleUnit.Degrees) {
				return Math.Cos(this.to_radians());
			} else {
				return Math.Cos(this.angle);
			}
		}
	}
}
