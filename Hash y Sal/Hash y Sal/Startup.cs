using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hash_y_Sal.Startup))]
namespace Hash_y_Sal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
