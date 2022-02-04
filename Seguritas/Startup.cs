using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Seguritas.Startup))]
namespace Seguritas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
