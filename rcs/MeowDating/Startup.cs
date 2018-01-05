using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeowDating.Startup))]
namespace MeowDating
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
