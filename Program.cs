using System;
using Command;

namespace SuperCalculator
{
	class MainClass
	{
		static void Main(string[] args)
		{
			Calculator calculator = new Calculator();

			Console.WriteLine("Type \"help\" for more guidance\n");

			while (true) {
				Console.Write("\n>>> ");
				var input = Console.ReadLine().Trim();


				// Display help
				if (input.ToLower().StartsWith("help")) {
					var help_for = input.Substring(4).Trim();
					if (help_for.Length > 0) {
						MainClass.Help(help_for);
					} else {
						MainClass.Help(null);
					}

					continue;
				}

				// Split input in the command and the arguments
				// The command is lower cased, with the first letter capitalised
				string[] splitted_input = input.Split(new char[]{' '}, 2);

				if (splitted_input[0] == "") {
					Console.WriteLine("No command given, type \"help\" to see how to use this app");
					continue;
				}
				string command = splitted_input[0].ToLower().FirstLetterToUpper();

				if (splitted_input.Length < 2) {
					Console.WriteLine("No arguments were given for this command...");
					continue;
				}
				string command_args = splitted_input[1];


				// Run the command with the arguments and handle errors
				try {
					Console.WriteLine(calculator.EvaluateCommand(command, command_args ));
				} catch (CommandNotFoundException) {
					Console.WriteLine("The command \"" + command + "\" does not exist");
				} catch (InvalidArgumentException e) {
					Console.WriteLine(e);
					Console.WriteLine("The arguments given to this command were invalid");
				}

			}
		}

		// This function prints the help message for a specific command or
		// the general usage. Set the parameter to null if you want to display 
		// the main help message
		static void Help(string command) {
			if (command == null) {
				// Main help message
				Console.WriteLine("No one is going to help you here! Cry baby!");
			} else {
				// Command specific help message
				Console.WriteLine("Help for command: " + command);
			}
		}
	}
}
