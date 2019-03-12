using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoASPNET.Startup))]
namespace CursoASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
