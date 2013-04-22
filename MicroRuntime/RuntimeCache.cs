using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Caching;

namespace voidsoft.MicroRuntime
{
    public static class RuntimeCache
    {
        private static HttpRuntime httpRuntime = null;

        /// <summary>
        /// Initializes the <see cref="RuntimeCache"/> class.
        /// </summary>
        static RuntimeCache()
        {
            if (httpRuntime == null)
            {
                httpRuntime = new HttpRuntime();
            }
        }

        /// <summary>
        /// Gets the internal cache.
        /// </summary>
        /// <value>The internal cache.</value>
        public static Cache InternalCache
        {
            get
            {
                return HttpRuntime.Cache;
            }
        }


        /// <summary>
        /// Gets a item cache
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static object GetFromCache(string key)
        {
            return InternalCache.Get(key);
        }

        /// <summary>
        /// Determines whether [is in cache] [the specified key].
        /// </summary>
        /// <param name="key">The key.</p-aram>
        /// <param name="resource">The resource.</param>
        /// <returns>
        /// 	<c>true</c> if [is in cache] [the specified key]; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool IsInCache(string key, out object resource)
        {
            resource = InternalCache.Get(key);
            return (resource != null);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool IsInCache(string key)
        {
            object resource = InternalCache.Get(key);
            return (resource != null);
        }


        /// <summary>
        /// Adds to cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="span">The span.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void AddToCache(string key, object value, TimeSpan span)
        {
            InternalCache.Add(key, value, null, Cache.NoAbsoluteExpiration, span, CacheItemPriority.High, null);
        }


        /// <summary>
        /// Adds to cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeSpan">The time span.</param>
        /// <param name="priority">The priority.</param>
        public static void AddToCache(string key, object value, TimeSpan timeSpan, CacheItemPriority priority)
        {
            InternalCache.Add(key, value, null, Cache.NoAbsoluteExpiration, timeSpan, priority, null);
        }


        public static void AddToCache(string key, object value, int minutes = 10, CacheItemPriority priority = CacheItemPriority.Low)
        {
            InternalCache.Add(key, value, null, DateTime.Now.Add(new TimeSpan(0, minutes, 0)), Cache.NoSlidingExpiration, priority, null);
        }

        /// <summary>
        /// Removes a item from the cache
        /// </summary>
        /// <param name="key">The key.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Remove(string key)
        {
            InternalCache.Remove(key);
        }

    }
}