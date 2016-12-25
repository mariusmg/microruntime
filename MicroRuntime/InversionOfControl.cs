using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;

namespace Microruntime
{
    public class InversionOfControl
    {
        //  private const char VALUE_SPLITTER = ';';
        private const char CONFIGURATION_VALUES = ',';


        private static NameValueCollection nvCollection = null;


        private const int CLASS_INDEX = 2;
        // private const int ASSEMBLY_INDEX = 3;
        private const int CLASS_NAME_INDEX = 0;
        private const int ASSEMBLY_NAME_INDEX = 1;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        public object GetInstance(string keyName)
        {

            if(nvCollection == null)
            {
                nvCollection = (NameValueCollection) ConfigurationManager.GetSection("Microruntime.IOC");
            }

            string var = nvCollection.Get(keyName);
            return CreateInstance(var);
        }

        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified var.
        /// </summary>
        /// <value></value>
        public object this[string var]
        {
            get
            {
                return GetInstance(var);
            }
        }


        /// <summary>
        /// Determines whether the specified key name has key.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified key name has key; otherwise, <c>false</c>.
        /// </returns>
        public bool HasKey(string keyName)
        {
            try
            {
                if(nvCollection != null)
                {
                    nvCollection = (NameValueCollection) ConfigurationManager.GetSection("Microruntime.IOC");
                }
                string value = nvCollection.Get(keyName);
                return (value != null) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        #region internal implementation

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private object CreateInstance(string value)
        {
            string[] vars = value.Split(new char[] { CONFIGURATION_VALUES }, StringSplitOptions.RemoveEmptyEntries);


            string className, assemblyName;
            // string[] classConstructorParameters;

            if (vars.Length == CLASS_INDEX)
            {
                className = vars[CLASS_NAME_INDEX];
                assemblyName = vars[ASSEMBLY_NAME_INDEX];
            }
            //else if (vars.Length == ASSEMBLY_INDEX)
            //{
            //    className = vars[CLASS_NAME_INDEX];
            //    classConstructorParameters = vars[ASSEMBLY_NAME_INDEX].Split(new char[] { VALUE_SPLITTER }, StringSplitOptions.RemoveEmptyEntries);
            //    assemblyName = vars[CLASS_INDEX];
            //}
            else
            {
                throw new ArgumentException("Invalid config file value " + value);
            }

            Assembly asm = Assembly.Load(assemblyName);

            Type tp = asm.GetType(className, false);

            if (tp == null)
            {
                throw new ArgumentException("Invalid class name");
            }

            return Activator.CreateInstance(tp);
        }

        #endregion
    }
}