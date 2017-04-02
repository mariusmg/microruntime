using System;
using System.IO;
using System.Reflection;
using System.Security.Policy;

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
			TypeDescriptor typeDescriptor = ParseDescriptor<T>(descriptor);

			Assembly assembly;

			if (File.Exists(typeDescriptor.AssemblyName))
			{
				assembly = Assembly.LoadFrom(typeDescriptor.AssemblyName);
			}
			else
			{
				string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				path += @"\" + typeDescriptor.AssemblyName;

				assembly = Assembly.LoadFrom(path);
			}

			Type tp = assembly.GetType(typeDescriptor.ClassName, false);

			return (T)Activator.CreateInstance(tp);
		}


		//public T CreateInstanceInAppDomain<T>(string descriptor) where T : class
		//{
		//	TypeDescriptor typeDescriptor = ParseDescriptor<T>(descriptor);

		//	AppDomainSetup domaininfo = new AppDomainSetup();
		//	domaininfo.ApplicationBase = System.Environment.CurrentDirectory;
		//	Evidence evidence = AppDomain.CurrentDomain.Evidence;
		//	AppDomain appDomain = AppDomain.CreateDomain(descriptor, evidence, domaininfo);

		//	Assembly assembly;

		//	if (File.Exists(typeDescriptor.AssemblyName))
		//	{
		//		assembly = appDomain.Load(typeDescriptor.AssemblyName);
		//	}
		//	else
		//	{
		//		string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		//		path += @"\" + typeDescriptor.AssemblyName;

		//		assembly = appDomain.Load(path);
		//	}

		//	Type tp = assembly.GetType(typeDescriptor.ClassName, false);

		//	return (T)Activator.CreateInstance(tp); ;
		//}


		private TypeDescriptor ParseDescriptor<T>(string descriptor) where T : class
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

			return new TypeDescriptor() { AssemblyName = assemblyName, ClassName = className };
		}


	}
}