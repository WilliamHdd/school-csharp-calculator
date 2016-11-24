using System;
namespace Commands;
{
	public class Log : Extended
	{
		public Log() { }
		public Log(string args) : base(args) { }

		public override double Execute() {
			return Math.Log10(this.data);

		}
	}
}