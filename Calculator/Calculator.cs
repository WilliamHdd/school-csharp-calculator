using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using Command;

namespace SuperCalculator
{
	public class Calculator
	{
		private Dictionary<string, Type> commands = new Dictionary<string, Type>();

		public Calculator() {
			List<Assembly> allAssemblies = new List<Assembly>();
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			foreach (string dll in Directory.GetFiles(path, "*.dll"))
				allAssemblies.Add(Assembly.LoadFile(dll));

			foreach (Assembly asm in allAssemblies) {
				string nspace = "Commands";

				var q = from t in asm.GetTypes()
						where t.IsClass && t.Namespace == nspace && !t.IsAbstract
						select t;

				foreach (var command in q) {
					Console.WriteLine("Command found: " + command.Name);
					this.commands.Add(command.Name, command);
				}
			}
		}

		public string EvaluateCommand(string commandName, string args) {

			Type commandType;
			if (!this.commands.TryGetValue(commandName, out commandType)) {
				throw new CommandNotFoundException(commandName);
			}
				
			try {
				// Activator.CreateInstance calls the parameterless constructor
				// of the given Type to create an instace.
				var command = Activator.CreateInstance(commandType, args );

				// Since CreateInstance returns an "object" we need to explore
				// the object to get the right method: "Execute"
				var method = command.GetType().GetMethod("Execute", new Type[] {});

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

