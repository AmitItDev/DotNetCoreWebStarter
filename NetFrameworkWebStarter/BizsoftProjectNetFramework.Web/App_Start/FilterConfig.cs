using BizsoftProjectNetFramework.Web.Class;
using System.Web.Mvc;

namespace BizsoftProjectNetFramework.Web
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
