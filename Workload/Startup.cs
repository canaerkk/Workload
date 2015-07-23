using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Workload.Startup))]
namespace Workload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
