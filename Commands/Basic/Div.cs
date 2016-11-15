﻿using System;

namespace SuperCalculator.Commands
{
	public class Div : Basic
	{
		// See Add.cs

		public Div(string args) : base(args, (a, b) => a / b) {
		}
	}
}
