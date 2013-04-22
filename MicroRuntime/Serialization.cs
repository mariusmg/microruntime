using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace voidsoft.MicroRuntime
{
    public class Serialization
    {

        private const int NAME_INDEX = 0;
        private const int VALUE_INDEX = 1;

        private const char TYPE_SEPARATOR = ';';
        private const char VALUE_SEPARATOR = '=';


        /// <summary>
        /// Deserializes from XML.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <param name="tp">The tp.</param>
        /// <returns></returns>
        public object DeserializeFromXml(Stream st, Type tp)
        {
            XmlSerializer deSerializer = new XmlSerializer(tp);
            return deSerializer.Deserialize(st);
        }

        /// <summary>
        /// Serializes to XML.
        /// </summary>
        /// <param name="typeInstance">The type instance.</param>
        /// <returns></returns>
        public string SerializeToXml(object typeInstance)
        {
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();

                XmlSerializer xs = new XmlSerializer(typeInstance.GetType());

                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, typeInstance);

                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

                UTF8Encoding encoding = new UTF8Encoding();

                string serializedString = encoding.GetString(memoryStream.ToArray());

                return serializedString;
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }


        /// <summary>
        /// Serializes to text.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public string SerializeToText(object instance)
        {
            FieldInfo[] fields = instance.GetType().GetFields();

            StringBuilder builder = new StringBuilder();

            foreach (FieldInfo info in fields)
            {
                builder.Append(info.Name + VALUE_SEPARATOR + info.GetValue(instance));
                builder.Append(TYPE_SEPARATOR);
            }

            PropertyInfo[] properties = instance.GetType().GetProperties();

            foreach (PropertyInfo info in properties)
            {
                builder.Append(info.Name + VALUE_SEPARATOR + info.GetValue(instance, null));
                builder.Append(TYPE_SEPARATOR);
            }

            return builder.ToString();
        }



        public string SerializeToTextUsingProvidedSeparator(object instance, string typeSeparator)
        {
            FieldInfo[] fields = instance.GetType().GetFields();

            StringBuilder builder = new StringBuilder();

            foreach (FieldInfo info in fields)
            {
                if (info.IsLiteral)
                {
                    continue;
                }
                
                builder.Append(info.Name + VALUE_SEPARATOR + info.GetValue(instance));
                builder.Append(typeSeparator);
            }

            PropertyInfo[] properties = instance.GetType().GetProperties();

            foreach (PropertyInfo info in properties)
            {
                builder.Append(info.Name + VALUE_SEPARATOR + info.GetValue(instance, null));
                builder.Append(typeSeparator);
            }

            return builder.ToString();
        }



        public object DeserializeFromTextUsingProvidedSeparator(string value, Type tp, string typeSeparator)
        {
            string[] parts = value.Split(new string[] { typeSeparator }, StringSplitOptions.RemoveEmptyEntries);

            object instance = Activator.CreateInstance(tp);


            foreach (string part in parts)
            {
                string[] vars = part.Split(new char[] { VALUE_SEPARATOR });

                SetValue(instance, vars[NAME_INDEX], vars[VALUE_INDEX]);
            }


            return instance;
        }


        /// <summary>
        /// Deserializes from text.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="tp">The tp.</param>
        /// <returns></returns>
        public object DeserializeFromText(string value, Type tp)
        {
            string[] parts = value.Split(new char[] { TYPE_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);

            object instance = Activator.CreateInstance(tp);


            foreach (string part in parts)
            {
                string[] vars = part.Split(new char[] { VALUE_SEPARATOR });

                SetValue(instance, vars[NAME_INDEX], vars[VALUE_INDEX]);
            }


            return instance;
        }


        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        private void SetValue(object instance, string fieldName, object value)
        {
            FieldInfo field = instance.GetType().GetField(fieldName);

            if (field != null)
            {
                SetValueByType(field, instance, value);

                return;
            }

            PropertyInfo prop = instance.GetType().GetProperty(fieldName);

            if (prop != null)
            {
                SetValueByType(prop, instance, value);
            }
        }


        /// <summary>
        /// Sets the type of the value by.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        private void SetValueByType(FieldInfo info, object instance, object value)
        {
            if (info.FieldType == typeof(Int32))
            {
                info.SetValue(instance, Convert.ToInt32(value));
            }
            else if (info.FieldType == typeof(DateTime))
            {
                info.SetValue(instance, Convert.ToDateTime(value));
            }
            else if (info.FieldType == typeof(Int64))
            {
                info.SetValue(instance, Convert.ToInt64(value));
            }
            else if (info.FieldType == typeof(Single))
            {
                info.SetValue(instance, Convert.ToSingle(value));
            }
            else if (info.FieldType == typeof(Double))
            {
                info.SetValue(instance, Convert.ToDouble(value));
            }
            else if (info.FieldType == typeof(Decimal))
            {
                info.SetValue(instance, Convert.ToDecimal(value));
            }
            else if (info.FieldType == typeof(Int16))
            {
                info.SetValue(instance, Convert.ToInt16(value));
            }
            else if (info.FieldType == typeof(SByte))
            {
                info.SetValue(instance, Convert.ToSByte(value));
            }
            else if (info.FieldType == typeof(Byte))
            {
                info.SetValue(instance, Convert.ToByte(value));
            }
            else if (info.FieldType == typeof(UInt16))
            {
                info.SetValue(instance, Convert.ToUInt16(value));
            }
            else if (info.FieldType == typeof(UInt32))
            {
                info.SetValue(instance, Convert.ToUInt32(value));
            }
            else if (info.FieldType == typeof(UInt64))
            {
                info.SetValue(instance, Convert.ToUInt64(value));
            }
            else if (info.FieldType == typeof(string))
            {
                info.SetValue(instance, value.ToString());
            }
        }


        /// <summary>
        /// Sets the type of the value by.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        private void SetValueByType(PropertyInfo info, object instance, object value)
        {
            if (info.PropertyType == typeof(Int32))
            {
                info.SetValue(instance, Convert.ToInt32(value), null);
            }
            else if (info.PropertyType == typeof(DateTime))
            {
                info.SetValue(instance, Convert.ToDateTime(value), null);
            }
            else if (info.PropertyType == typeof(Int64))
            {
                info.SetValue(instance, Convert.ToInt64(value), null);
            }
            else if (info.PropertyType == typeof(Single))
            {
                info.SetValue(instance, Convert.ToSingle(value), null);
            }
            else if (info.PropertyType == typeof(Double))
            {
                info.SetValue(instance, Convert.ToDouble(value), null);
            }
            else if (info.PropertyType == typeof(Decimal))
            {
                info.SetValue(instance, Convert.ToDecimal(value), null);
            }
            else if (info.PropertyType == typeof(Int16))
            {
                info.SetValue(instance, Convert.ToInt16(value), null);
            }
            else if (info.PropertyType == typeof(SByte))
            {
                info.SetValue(instance, Convert.ToSByte(value), null);
            }
            else if (info.PropertyType == typeof(Byte))
            {
                info.SetValue(instance, Convert.ToByte(value), null);
            }
            else if (info.PropertyType == typeof(UInt16))
            {
                info.SetValue(instance, Convert.ToUInt16(value), null);
            }
            else if (info.PropertyType == typeof(UInt32))
            {
                info.SetValue(instance, Convert.ToUInt32(value), null);
            }
            else if (info.PropertyType == typeof(UInt64))
            {
                info.SetValue(instance, Convert.ToUInt64(value), null);
            }
            else if (info.PropertyType == typeof(string))
            {
                info.SetValue(instance, value.ToString(), null);
            }
        }



    }
}