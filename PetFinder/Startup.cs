using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetFinder.Startup))]
namespace PetFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
