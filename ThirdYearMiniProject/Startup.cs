using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThirdYearMiniProject.Startup))]
namespace ThirdYearMiniProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
