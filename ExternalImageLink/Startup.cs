using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExternalImageLink.Startup))]
namespace ExternalImageLink
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
