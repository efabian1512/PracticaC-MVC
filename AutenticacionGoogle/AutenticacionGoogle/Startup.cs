using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutenticacionGoogle.Startup))]
namespace AutenticacionGoogle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
