using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Calc.Startup))]
namespace Calc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
