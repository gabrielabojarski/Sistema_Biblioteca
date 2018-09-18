using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaMundoNovo.Startup))]
namespace SistemaMundoNovo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
