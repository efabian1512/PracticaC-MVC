using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxActionLink.Startup))]
namespace AjaxActionLink
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
