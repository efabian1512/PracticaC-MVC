using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OverPosting.Startup))]
namespace OverPosting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
