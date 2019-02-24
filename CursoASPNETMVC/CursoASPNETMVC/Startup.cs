using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoASPNETMVC.Startup))]
namespace CursoASPNETMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
