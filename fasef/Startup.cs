using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UNBK_Client.Startup))]
namespace UNBK_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
