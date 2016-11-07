using System;

namespace SuperCalculator.Commands
{
	// Enum to handle both angles in degrees and radians
	public enum AngleUnit {
		Degrees,
		Radians,
	}

	// Base class for trig functions, it inherits from command
	// with the generic type set to double, this means it will 
	// evaluate to a double.
	public abstract class Trigonometric : Command<double>
	{
		protected double angle;
		protected AngleUnit unit;


		// The constructor takes a string and parses it. It checks if the string
		// ends with "deg" or "rad" to know the unit of the angle.
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

		// Simple helper function to convert degrees into radians
		protected double to_radians() {
			return this.angle * Math.PI / 180;
		}
	}
}

