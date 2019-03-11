using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autenticacion.Startup))]
namespace Autenticacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
