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

		public Trigonometric(double angle, AngleUnit unit) {
			this.angle = angle;
			this.unit = unit;
		}

		protected double to_radians() {
			return this.angle * 180 / Math.PI;
		}
	}
}

