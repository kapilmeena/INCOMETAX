using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INCOMETAX.Startup))]
namespace INCOMETAX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
