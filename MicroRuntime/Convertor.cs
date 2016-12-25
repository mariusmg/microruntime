using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace Microruntime
{
    public static class Convertor
    {
        /// <summary>
        /// Converts to data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enm">Enumerable.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static DataTable ConvertToDataTable<T>(IEnumerable<T> enm)
        {
            IEnumerator<T> ienum = enm.GetEnumerator();

            DataTable table = new DataTable();


            int index = -1;


            while (ienum.MoveNext())
            {
                ++index;

                if (index == 0)
                {
                    BuildSchema<T>(ienum.Current, ref table);
                }


                Fill<T>(ienum.Current, ref table);
            }


            return table;
        }


        /// <summary>
        /// Builds the schema.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="table">The table.</param>
        private static void BuildSchema<T>(T t, ref DataTable table)
        {
            PropertyInfo[] propertyInfos = t.GetType().GetProperties();

            foreach (PropertyInfo info in propertyInfos)
            {
                table.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
        }

        /// <summary>
        /// Fills the type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="table">The table.</param>
        private static void Fill<T>(T t, ref DataTable table)
        {
            PropertyInfo[] propertyInfos = t.GetType().GetProperties();

            DataRow row = table.NewRow();

            foreach (PropertyInfo info in propertyInfos)
            {
                row[info.Name] = info.GetValue(t, new object[] { });
            }


            table.Rows.Add(row);
        }
    }
}