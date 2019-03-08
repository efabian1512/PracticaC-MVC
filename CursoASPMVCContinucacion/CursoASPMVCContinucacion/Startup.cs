using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoASPMVCContinucacion.Startup))]
namespace CursoASPMVCContinucacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
