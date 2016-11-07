using System;
using SuperCalculator.Commands;

namespace SuperCalculator
{
	public class Calculator
	{
		public Calculator() {
		}

		public string EvaluateCommand(string commandName, string args) {
			// Namespace of the commands module
			string commandNameSpace = "SuperCalculator.Commands";

			// Type.GetType takes a string and tries to find a Type with
			// the *fully qualified name* - which includes the Namespace
			// and possibly also the Assembly if it's in another assembly
			Type commandType = Type.GetType(commandNameSpace + "." + commandName);

			if (commandType != null)
			{
				// Activator.CreateInstance calls the parameterless constructor
				// of the given Type to create an instace. As this returns object
				// you need to cast it to the desired type, Command
				var command = Activator.CreateInstance(commandType, args );
				var method = command.GetType().GetMethod("Execute");

				var result = method.Invoke(command, null);

				return result.ToString();
			}
			else
			{
				// If the Type was not found, you need to handle that. 
				throw new CommandNotFoundException(commandName);
			}
		}
	}
}

