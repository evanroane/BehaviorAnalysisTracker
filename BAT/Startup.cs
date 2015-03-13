using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BAT.Startup))]
namespace BAT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
