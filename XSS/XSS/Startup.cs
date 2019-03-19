using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XSS.Startup))]
namespace XSS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
