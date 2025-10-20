using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetFrameworkWebStarter.Web.Startup))]

namespace NetFrameworkWebStarter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           ConfigureAuth(app);
        }
    }
}