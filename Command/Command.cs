using System;

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
	public abstract class Command<T>
	{
		public abstract T Execute();
	}
}



