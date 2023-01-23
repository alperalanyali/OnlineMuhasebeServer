using System;
using System.Reflection;

namespace Persistence
{
	public static class AssemblyReference
	{
		public static readonly Assembly Assembly = typeof(Assembly).Assembly;
	}
}

