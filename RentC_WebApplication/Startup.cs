using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentC_WebApplication.Startup))]
namespace RentC_WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
