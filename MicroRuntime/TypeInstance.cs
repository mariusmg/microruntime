using System;
using System.Reflection;
using System.Runtime.Remoting;

namespace Microruntime
{
	public class TypeInstance
	{
		private const char VALUE_SPLITTER = ',';

		private const int PARTS_COUNT = 2;
		private const int CLASS_NAME_INDEX = 0;
		private const int ASSEMBLY_NAME_INDEX = 1;


		public T CreateInstance<T>(string descriptor) where T : class
		{
			string[] vars = descriptor.Split(new[] { VALUE_SPLITTER }, StringSplitOptions.RemoveEmptyEntries);

			string className, assemblyName;

			if (vars.Length == PARTS_COUNT)
			{
				className = vars[CLASS_NAME_INDEX];

				assemblyName = vars[ASSEMBLY_NAME_INDEX];

			}
			else
			{
				throw new ArgumentException("The descriptor in invalid");
			}


			Assembly assembly = Assembly.LoadFrom(assemblyName);

			Type tp = assembly.GetType(className, false);

			return (T)Activator.CreateInstance(tp);
		}
	}
}