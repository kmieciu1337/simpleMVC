using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(simpleMVC.Startup))]
namespace simpleMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
