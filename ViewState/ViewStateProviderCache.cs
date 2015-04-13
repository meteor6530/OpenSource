using System;
using System.Collections.Generic;
using System.Text;

using System.Web.Caching;
using System.Web;
using System.Web.SessionState;

namespace DoFactory.Framework.ViewState
{
    /// <summary>
    /// Viewstate provider that is implemented using a cache.
    /// 
    /// Gof Design Pattern: Strategy.
    /// </summary>
    /// <remarks>
    /// The Strategy Design Pattern ensures that this class is 'pluggable' and 
    /// can fully function as a viewstate provider.
    /// </remarks>
    public class ViewStateProviderCache : ViewStateProviderBase
    {
        /// <summary>
        /// Saves view state information for the web page in cache.
        /// </summary>
        /// <param name="name">Name of the viewstate.</param>
        /// <param name="viewState">Viewstate.</param>
        public override void SavePageState(string name, object viewState)
        {
            // Access cache and session state
            Cache cache = HttpContext.Current.Cache;
            HttpSessionState session = HttpContext.Current.Session;

            // Add to cache.
            cache.Add(name, viewState, null, DateTime.Now.AddMinutes(session.Timeout), TimeSpan.Zero, CacheItemPriority.Default, null);
        }

        /// <summary>
        /// Retrieves viewstate information for the web page from cache.
        /// </summary>
        /// <param name="name">Name of the viewstate.</param>
        /// <returns>Viewstate.</returns>
        public override object LoadPageState(string name)
        {
            // Get cached entry.
            return HttpContext.Current.Cache[name];
        }
    }
}
