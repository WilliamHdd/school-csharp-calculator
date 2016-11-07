using System;

namespace SuperCalculator.Commands
{
	public class Sin : Trigonometric
	{
		public Sin(string arg) : base(arg) { }

		public override double Execute() {
			if (this.unit == AngleUnit.Degrees) {
				return Math.Sin(this.to_radians());
			} else {
				return Math.Sin(this.angle);
			}
		}
	}
}

