using NetFrameworkWebStarter.Web.Class;
using System.Web.Mvc;

namespace NetFrameworkWebStarter.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new EncryptedActionParameterAttribute());
        }
    }
}
