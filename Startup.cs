using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeeChat.Startup))]
namespace WeeChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
