using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelecashSample.Startup))]
namespace TelecashSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
