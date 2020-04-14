using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokemonCollection.WebMVC.Startup))]
namespace PokemonCollection.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
