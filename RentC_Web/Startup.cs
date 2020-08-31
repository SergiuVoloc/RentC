using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentC_Web.Startup))]
namespace RentC_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
