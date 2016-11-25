using System;
using System.Collections.Generic;
using System.Linq;
using Command;

namespace Commands

{
	public class Deriv : Command<string>
	{
		protected List<double> coefs;

		public Deriv() { }

		public Deriv(string arg) {
			// Set the polynomial to zero
			// The first coefficient is the constant term
			this.coefs = new List<double>();
			this.coefs.Add(0);

			var terms = arg.Trim().Split(new Char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

			foreach(var term in terms) {
				var splitted = term.Trim().Split(new Char[] {'x'}, 2);

				switch (splitted.Length) {
					case 1:
						try {
							this.coefs[0] += Double.Parse(splitted[0]);
						} catch (Exception) {
							throw new InvalidArgumentException(arg, "Polynomial");
						}
						break;
					case 2:
						try {
							var power = 1;
							if (splitted[1].Trim().Length > 0) {
								var p = splitted[1].Replace("^", ""); 
								power = Int32.Parse(p);
							}

							// Extend the range
							while( this.coefs.Count <= power ) {
								this.coefs.Add(0);
							}

							this.coefs[power] += Double.Parse(splitted[0]);
						} catch (Exception e) {
							Console.WriteLine(e);
							throw new InvalidArgumentException(arg, "Polynomial");
						}
						break;
					default:
						Console.WriteLine("Default");
						throw new InvalidArgumentException(arg, "Polynomial");
				}
			}


		}

		public override string Execute() {
			List<string> result = new List<string>();

			foreach ( var x in this.coefs.Select( (c,i) => new { Coef = c, Power=i }) ) {
				if (x.Coef == 0 || x.Power == 0)
					continue;

				if (x.Power == 1) {
					result.Add(x.Coef.ToString());
				} else if (x.Power == 2) {
					var c = 2 * x.Coef;
					result.Add(c + "x");
				} else {
					var c = x.Power * x.Coef;
					result.Add(c + "x^" + (x.Power - 1));  
				}
			}

			result.Reverse();

			if (result.Count == 0)
				return "0";

			return String.Join(" + ", result);
		}

	}
}