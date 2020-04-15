using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gepv.Startup))]
namespace gepv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
