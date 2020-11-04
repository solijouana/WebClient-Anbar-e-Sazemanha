using System.Web;
using System.Web.Mvc;

namespace Anbare_Sazemanha.Webapi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
