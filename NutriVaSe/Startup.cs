using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NutriVaSe.Startup))]
namespace NutriVaSe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
