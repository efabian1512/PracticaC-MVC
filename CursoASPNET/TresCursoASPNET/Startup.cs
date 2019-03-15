using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TresCursoASPNET.Startup))]
namespace TresCursoASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
