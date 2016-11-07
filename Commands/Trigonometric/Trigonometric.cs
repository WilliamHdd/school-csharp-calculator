using System;

namespace SuperCalculator.Commands
{
	public enum AngleUnit {
		Degrees,
		Radians,
	}

	public abstract class Trigonometric : Command<double>
	{
		protected double angle;
		protected AngleUnit unit;

		public Trigonometric(string arg) {
			this.unit = AngleUnit.Radians;

			arg.Trim();
			if (arg.EndsWith("rad")) {
				arg = arg.Substring(0, arg.Length - 3).Trim();
				this.unit = AngleUnit.Radians;
			} else if (arg.EndsWith("deg")) {
				arg = arg.Substring(0, arg.Length - 3).Trim();
				this.unit = AngleUnit.Degrees;
			}

			try {
				this.angle = Double.Parse(arg);
			} catch (FormatException) {
				throw new ArgumentException();
			}
		}

		protected double to_radians() {
			return this.angle * Math.PI / 180;
		}
	}
}

