using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BizsoftProjectNetFramework.Web.Startup))]

namespace BizsoftProjectNetFramework.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           ConfigureAuth(app);
        }
    }
}