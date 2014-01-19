using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AF.WebApplication.MVC.Startup))]
namespace AF.WebApplication.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
