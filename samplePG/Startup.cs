using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(samplePG.Startup))]
namespace samplePG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
