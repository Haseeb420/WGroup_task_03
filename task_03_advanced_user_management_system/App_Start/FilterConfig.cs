using System.Web;
using System.Web.Mvc;

namespace task_03_advanced_user_management_system
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
