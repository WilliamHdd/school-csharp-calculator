﻿using System;
namespace Commands
{
	public class Tan : Trigonometric
	{
		//See Sin.cs
		public Tan() {}

		public Tan(string arg) : base(arg) { }

		public override double Execute() {
			if (this.unit == AngleUnit.Degrees) {
				return Math.Tan(this.to_radians());
			} else {
				return Math.Tan(this.angle);
			}
		}
	}
}
