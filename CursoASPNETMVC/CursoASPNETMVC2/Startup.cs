using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoASPNETMVC2.Startup))]
namespace CursoASPNETMVC2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
