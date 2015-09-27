using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAspNet.Startup))]
namespace TestAspNet
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
