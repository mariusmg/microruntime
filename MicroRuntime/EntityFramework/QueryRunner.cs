using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Reflection;


namespace voidsoft.MicroRuntime.EntityFramework
{

    /// <summary>
    /// 
    /// </summary>
    public class QueryRunner
    {
        /// <summary>
        /// Gets the lookup data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="objectQuery">The object query.</param>
        /// <param name="primaryKeyField">The primary key field.</param>
        /// <param name="sortingField">The sorting field.</param>
        /// <param name="disposeContext">if set to <c>true</c> [dispose context].</param>
        /// <returns></returns>
        public Dictionary<int, string> GetDictionaryLookupData<T>(T t, ObjectQuery objectQuery, string primaryKeyField, string sortingField, bool disposeContext) where T : ObjectContext
        {
            try
            {
                ObjectResult result = objectQuery.Execute(MergeOption.NoTracking);
                IEnumerator enumerator = result.AsQueryable().GetEnumerator();

                Dictionary<int, string> dictionary = new Dictionary<int, string>();

                while (enumerator.MoveNext())
                {
                    PropertyInfo primaryKeyProperty = enumerator.Current.GetType().GetProperty(primaryKeyField);
                    PropertyInfo sortingFieldProperty = enumerator.Current.GetType().GetProperty(sortingField);
                    dictionary.Add(Convert.ToInt32(primaryKeyProperty.GetValue(enumerator.Current, null)), sortingFieldProperty.GetValue(enumerator.Current, null).ToString());
                }

                return dictionary;
            }
            finally
            {
                if (disposeContext)
                {
                    t.Dispose();
                }
            }
        }


        /// <summary>
        /// Gets the lookup data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="objectQuery">The object query.</param>
        /// <param name="primaryKeyField">The primary key field.</param>
        /// <param name="sortingField">The sorting field.</param>
        /// <param name="disposeContext">if set to <c>true</c> [dispose context].</param>
        /// <returns></returns>
        public List<KeyValuePair<int, string>> GetLookupData<T>(T t, ObjectQuery objectQuery, string primaryKeyField, string sortingField, bool disposeContext) where T : ObjectContext
        {
            try
            {
                ObjectResult result = objectQuery.Execute(MergeOption.NoTracking);
                IEnumerator enumerator = result.AsQueryable().GetEnumerator();

                List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();

                while (enumerator.MoveNext())
                {
                    PropertyInfo primaryKeyProperty = enumerator.Current.GetType().GetProperty(primaryKeyField);
                    PropertyInfo sortingFieldProperty = enumerator.Current.GetType().GetProperty(sortingField);
                    list.Add(new KeyValuePair<int, string>(Convert.ToInt32(primaryKeyProperty.GetValue(enumerator.Current, null)), sortingFieldProperty.GetValue(enumerator.Current, null).ToString()));
                }

                return list;
            }
            finally
            {
                if (disposeContext)
                {
                    t.Dispose();
                }
            }
        }


        /// <summary>
        /// Executes the specified specified query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="oq">The oq.</param>
        /// <param name="disposeContext">if set to <c>true</c> [dispose context].</param>
        /// <returns></returns>
        public E[] Execute<T, E>(T t, ObjectQuery<E> oq, bool disposeContext) where T : ObjectContext
        {
            try
            {
                ObjectResult<E> res = oq.Execute(MergeOption.AppendOnly);
                IEnumerable<E> enumerable = res.AsEnumerable();

                return enumerable.ToArray();
            }
            finally
            {
                if (disposeContext)
                {
                    t.Dispose();
                }
            }
        }


        /// <summary>
        /// Executes the data table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="objectQuery">The object query.</param>
        /// <param name="disposeContext">if set to <c>true</c> [dispose context].</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable<T>(T t, ObjectQuery objectQuery, bool disposeContext) where T : ObjectContext
        {
            try
            {
                ObjectResult result = objectQuery.Execute(MergeOption.NoTracking);

                PropertyInfo[] properties = result.ElementType.GetProperties();


                DataTable dt = new DataTable();

                foreach (PropertyInfo info in properties)
                {
                    dt.Columns.Add(info.Name, info.PropertyType);
                }

                IEnumerator enumerator = result.AsQueryable().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    PropertyInfo[] infos = enumerator.Current.GetType().GetProperties();

                    DataRow row = dt.NewRow();

                    foreach (PropertyInfo info in infos)
                    {
                        row[info.Name] = info.GetValue(enumerator.Current, null);
                    }


                    dt.Rows.Add(row);
                }

                return dt;
            }
            finally
            {
                if (disposeContext)
                {
                    t.Dispose();
                }
            }
        }




        /// <summary>
        /// Doeses the field value exists.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="o">The o.</param>
        /// <param name="entityProperty">The entity property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool IsFieldValueAlreadyUsed(string entityName, ObjectContext o, string entityProperty, string value)
        {
            string query = "SELECT VALUE COUNT(c." + entityProperty + " ) FROM " + o.DefaultContainerName + "." + entityName + " as c where c." + entityProperty + " == " + value;


            ObjectQuery<int> oq = new ObjectQuery<int>(query, o);

            ObjectResult<int> objectResult = oq.Execute(MergeOption.NoTracking);

            IEnumerator<int> enumerator = objectResult.GetEnumerator();


            while (enumerator.MoveNext())
            {

                return true;
            }

            return false;
        }
    }
}