using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Microruntime
{
    public class DataTableConverter
    {
        /// <summary>
        /// Converts to data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">Enumerable.</param>
        /// <returns></returns>
        public DataTable ConvertToDataTable<T>(IEnumerable<T> enumerable)
        {
            IEnumerator<T> ienum = enumerable.GetEnumerator();

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