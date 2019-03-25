using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxForm.Startup))]
namespace AjaxForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
