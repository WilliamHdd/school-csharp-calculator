using System;
using System.Collections.Generic;
using System.Linq;
using Command;

namespace Commands

{
	public abstract class Derivatives : Command<List<int>>
	{
		protected string data;
		public Derivatives() { }
		public Derivatives(string arg) {
			arg.Trim();

			try {
				this.data = arg;
			} catch (FormatException) {
				throw new ArgumentException();
			}
		}

	}
}