using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agregator.Startup))]
namespace Agregator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
