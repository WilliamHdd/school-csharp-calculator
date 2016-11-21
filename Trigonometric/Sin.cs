using System;

namespace Commands
{
	public class Sin : Trigonometric
	{
		public Sin(){}

		// The parsing of the input is already done in the parent
		// class, we just have to forward the argument
		public Sin(string arg) : base(arg) { }

		// The Execute function checks if the angle is in degrees or radians
		// and returns the result of Math.Sin
		public override double Execute() {
			if (this.unit == AngleUnit.Degrees) {
				return Math.Sin(this.to_radians());
			} else {
				return Math.Sin(this.angle);
			}
		}
	}
}

