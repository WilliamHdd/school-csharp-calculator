using System;
using System.Reflection;

namespace Computer
{
	public interface Computer
	{
		double Execute (params string[] values);

	}
}

namespace Command
{

	// This is the abstract class from which all commands will inherit
	// It has a generic type parameter to allow different commands to
	// return different types. For example, Sin will return a double but
	// Derive should return a polynomial
	//
	// Each class inheriting from command should have a constructor taking
	// a string as argument. The command will have to parse that string to 
	// extract the data it has to work on.
	public abstract class Command<T> : Computer.Computer
	{
		public Command(){}
		
		public abstract T Execute();


		public double Execute (params string[] values)
		{
			Type type = this.GetType();

			var ctor = type.GetConstructor(new[] { values[0].GetType() });
			object instance = ctor.Invoke(new object[] { values[0] });

			var method = instance.GetType().GetMethod("Execute", new Type[] {});
			var result = method.Invoke(instance, null);
			return (double)result;
		}

	}
}



