using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DOSCursoASPNET.Startup))]
namespace DOSCursoASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
