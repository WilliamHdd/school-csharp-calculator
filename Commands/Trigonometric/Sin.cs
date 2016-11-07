using System;

namespace SuperCalculator.Commands
{
	public enum AngleUnit {
		Degrees,
		Radians,
	}

	public class Sin : Trigonometric
	{
		public Sin(double angle, AngleUnit unit) {
			this.angle = angle;
			this.unit = unit;
		}

		public override double execute() {
			if (this.unit == AngleUnit.Degrees) {
				return Math.Sin(this.to_radians());
			} else {
				return Math.Sin(this.angle);
			}
		}
	}
}

