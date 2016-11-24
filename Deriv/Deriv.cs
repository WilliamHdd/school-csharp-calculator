using System;
using System.Collections.Generic;

namespace Commands
{
	public class Deriv : Derivatives
	{
		public Deriv() { }
		public Deriv(string args) : base(args) { }
		public override List<int> Execute() {
			List<string> un = new List<string>(this.data.Split('+'));
			List<int> ReturnValue = new List<int>();
			foreach (string element in un) {
				List<int> ToBeSent = new List<int>();
				int new_exp = 0;
				if (element.Length == 1) {
					un.Remove(element);
				} else {
					List<string> deux = new List<string>(element.Split('^'));
					foreach (string piece in deux) {
						if (piece.Length == 1) {
							try {
								int value = Int32.Parse(piece);
								new_exp = value - 1;

							} catch {
								Console.WriteLine("l'exposant doit être un entier");
							}
						} else {
							List<string> multiplicateur = new List<string>(piece.Split('x'));
							int mult = 0;

							foreach (string chiffre in multiplicateur) {
								try {
									mult = Int32.Parse(chiffre);
								} catch {
									if (chiffre.GetType() != typeof(int)) {
										continue;}
								}
								ToBeSent.Add(mult);
							}
						}
					}
					ToBeSent.Add(new_exp);
				}
				foreach (int morceau in ToBeSent) { ReturnValue.Add(morceau);}
			}
			return ReturnValue;

		}
	}
}
