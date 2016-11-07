using System;

namespace SuperCalculator.Commands
{
	public abstract class Command<T>
	{
		public abstract T execute();
	}
}

