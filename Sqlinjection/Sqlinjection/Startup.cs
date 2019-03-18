using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sqlinjection.Startup))]
namespace Sqlinjection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
