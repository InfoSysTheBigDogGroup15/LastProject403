using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LastProject403.Startup))]
namespace LastProject403
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
