using System;
using System.Reflection;
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


			// If the command is not found, an ArgumentNullException will be raised
			try {
				// Type.GetType takes a string and tries to find a Type with
				// the *fully qualified name* - which includes the Namespace
				Type commandType = Type.GetType(commandNameSpace + "." + commandName);

				// Activator.CreateInstance calls the parameterless constructor
				// of the given Type to create an instace.
				var command = Activator.CreateInstance(commandType, args );

				// Since CreateInstance returns an "object" we need to explore
				// the object to get the right method: "Execute"
				var method = command.GetType().GetMethod("Execute");

				// We call the method we found with no parameters
				var result = method.Invoke(command, null);

				return result.ToString();
			} catch (ArgumentNullException) {
				// If the command was not found, throw an exception 
				throw new CommandNotFoundException(commandName);
			} catch (TargetInvocationException) {
				throw new InvalidArgumentException(args, "");
			}
		}
	}
}

