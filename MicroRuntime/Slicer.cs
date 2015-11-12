using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace voidsoft.MicroRuntime
{
    public class Slicer
    {
        /// <summary>
        /// Slices the data table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public DataTable SliceDataTable(DataTable table, int pageIndex, int count)
        {
            int startIndex;
            int endIndex;

            if (pageIndex == 1)
            {
                startIndex = 0;
                endIndex = count;
            }
            else
            {
                startIndex = (pageIndex * count) - count;
                endIndex = startIndex + count;
            }


            //extra check
            if (endIndex > table.Rows.Count)
            {
                endIndex = table.Rows.Count;
            }


            DataTable result = table.Clone();

            for (int i = startIndex; i < endIndex; i++)
            {
                result.ImportRow(table.Rows[i]);
            }

            return result;
        }



        /// <summary>
        /// Slices the specified m.
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="m">Data source to slice</param>
        /// <param name="t">Type</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public List<T> Slice<M, T>(M m, T t, int pageIndex, int count) where M : IEnumerable
        {
            int startIndex;
            int endIndex;

            List<T> list = new List<T>();


            //get count
            int counter = m.Cast<T>().Count();

	        if (pageIndex == 1)
            {
                startIndex = 0;
                endIndex = count;
            }
            else
            {
                startIndex = (pageIndex * count) - count;
                endIndex = startIndex + count;
            }


            //extra check for ending
            if (endIndex > count)
            {
                endIndex = count;
            }


            int currentIndex = -1;

            foreach (T current in m)
            {
                ++currentIndex;


                if (currentIndex >= startIndex && currentIndex <= endIndex)
                {
                    list.Add(current);
                }
            }
            return list;
        }

    }
}