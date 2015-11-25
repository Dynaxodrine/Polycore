using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Polycore.Startup))]
namespace Polycore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
