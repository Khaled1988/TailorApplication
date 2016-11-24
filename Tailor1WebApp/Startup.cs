using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tailor1WebApp.Startup))]
namespace Tailor1WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}


