using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoASPNETMVCP2.Startup))]
namespace CursoASPNETMVCP2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
