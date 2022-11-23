using System.Web;
using System.Web.Mvc;

namespace CeyhunKutahyaliWebProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
