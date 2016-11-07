using System;

namespace SuperCalculator
{
	class MainClass
	{
		static void Main(string[] args)
		{
			Calculator calculator = new Calculator();
			Console.WriteLine(calculator.EvaluateCommand("Sin", "30deg" ));
			Console.WriteLine(calculator.EvaluateCommand("Add", "1 2 3" ));
			//Console.WriteLine(calculator.EvaluateCommand("Cos", "45deg"));
		}
	}
}
