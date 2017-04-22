using System.Web;
using System.Web.Mvc;
using TrackPerformanceWebApp.Filters;

namespace TrackPerformanceWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TrackPerformanceAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
