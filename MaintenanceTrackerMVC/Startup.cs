using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaintenanceTrackerMVC.Startup))]
namespace MaintenanceTrackerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
